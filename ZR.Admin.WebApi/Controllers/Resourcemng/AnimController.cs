using Infrastructure;
using Infrastructure.Attribute;
using Infrastructure.Enums;
using Infrastructure.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ZR.Model.Dto;
using ZR.Model.Models;
using ZR.Service.Resourcemng.IResourcemngService;
using ZR.Admin.WebApi.Extensions;
using ZR.Admin.WebApi.Filters;
using ZR.Common;

namespace ZR.Admin.WebApi.Controllers
{
    /// <summary>
    /// 动作管理Controller
    /// 
    /// @tableName anim
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/anim")]
    public class AnimController : BaseController
    {
        /// <summary>
        /// 动作管理接口
        /// </summary>
        private readonly IAnimService _AnimService;

        public AnimController(IAnimService AnimService)
        {
            _AnimService = AnimService;
        }

        /// <summary>
        /// 查询动作管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:anim:list")]
        public IActionResult QueryAnim([FromQuery] AnimQueryDto parm)
        {
            var response = _AnimService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询动作管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:anim:query")]
        public IActionResult GetAnim(int Id)
        {
            var response = _AnimService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加动作管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:anim:add")]
        [Log(Title = "动作管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddAnim([FromBody] AnimDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<Anim>().ToCreate(HttpContext);

            var response = _AnimService.AddAnim(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新动作管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:anim:edit")]
        [Log(Title = "动作管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateAnim([FromBody] AnimDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<Anim>().ToUpdate(HttpContext);

            var response = _AnimService.UpdateAnim(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除动作管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:anim:delete")]
        [Log(Title = "动作管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteAnim(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _AnimService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出动作管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "动作管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:anim:export")]
        public IActionResult Export([FromQuery] AnimQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _AnimService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "Anim", "动作管理");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    }
}