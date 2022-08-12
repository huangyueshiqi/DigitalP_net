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
    /// @tableName ui_animation
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/UiAnimation")]
    public class UiAnimationController : BaseController
    {
        /// <summary>
        /// 动作管理接口
        /// </summary>
        private readonly IUiAnimationService _UiAnimationService;

        public UiAnimationController(IUiAnimationService UiAnimationService)
        {
            _UiAnimationService = UiAnimationService;
        }

        /// <summary>
        /// 查询动作管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:uianimation:list")]
        public IActionResult QueryUiAnimation([FromQuery] UiAnimationQueryDto parm)
        {
            var response = _UiAnimationService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询动作管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:uianimation:query")]
        public IActionResult GetUiAnimation(int Id)
        {
            var response = _UiAnimationService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加动作管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:uianimation:add")]
        [Log(Title = "动作管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddUiAnimation([FromBody] UiAnimationDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<UiAnimation>().ToCreate(HttpContext);

            var response = _UiAnimationService.AddUiAnimation(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新动作管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:uianimation:edit")]
        [Log(Title = "动作管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateUiAnimation([FromBody] UiAnimationDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<UiAnimation>().ToUpdate(HttpContext);

            var response = _UiAnimationService.UpdateUiAnimation(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除动作管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:uianimation:delete")]
        [Log(Title = "动作管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteUiAnimation(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _UiAnimationService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出动作管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "动作管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:uianimation:export")]
        public IActionResult Export([FromQuery] UiAnimationQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _UiAnimationService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "UiAnimation", "动作管理");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    }
}