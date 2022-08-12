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
    /// 服装管理Controller
    /// 
    /// @tableName cloth
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/cloth")]
    public class ClothController : BaseController
    {
        /// <summary>
        /// 服装管理接口
        /// </summary>
        private readonly IClothService _ClothService;

        public ClothController(IClothService ClothService)
        {
            _ClothService = ClothService;
        }

        /// <summary>
        /// 查询服装管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:cloth:list")]
        public IActionResult QueryCloth([FromQuery] ClothQueryDto parm)
        {
            var response = _ClothService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询服装管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:cloth:query")]
        public IActionResult GetCloth(int Id)
        {
            var response = _ClothService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加服装管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:cloth:add")]
        [Log(Title = "服装管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddCloth([FromBody] ClothDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<Cloth>().ToCreate(HttpContext);

            var response = _ClothService.AddCloth(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新服装管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:cloth:edit")]
        [Log(Title = "服装管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateCloth([FromBody] ClothDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<Cloth>().ToUpdate(HttpContext);

            var response = _ClothService.UpdateCloth(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除服装管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:cloth:delete")]
        [Log(Title = "服装管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteCloth(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _ClothService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出服装管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "服装管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:cloth:export")]
        public IActionResult Export([FromQuery] ClothQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _ClothService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "Cloth", "服装管理");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    }
}