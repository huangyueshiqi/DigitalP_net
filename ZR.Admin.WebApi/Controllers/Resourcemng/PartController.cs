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
    /// 部位管理Controller
    /// 
    /// @tableName part
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/Part")]
    public class PartController : BaseController
    {
        /// <summary>
        /// 部位管理接口
        /// </summary>
        private readonly IPartService _PartService;

        public PartController(IPartService PartService)
        {
            _PartService = PartService;
        }

        /// <summary>
        /// 查询部位管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:part:list")]
        public IActionResult QueryPart([FromQuery] PartQueryDto parm)
        {
            var response = _PartService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询部位管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:part:query")]
        public IActionResult GetPart(int Id)
        {
            var response = _PartService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加部位管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:part:add")]
        [Log(Title = "部位管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPart([FromBody] PartDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<Part>().ToCreate(HttpContext);

            var response = _PartService.AddPart(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新部位管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:part:edit")]
        [Log(Title = "部位管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePart([FromBody] PartDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<Part>().ToUpdate(HttpContext);

            var response = _PartService.UpdatePart(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除部位管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:part:delete")]
        [Log(Title = "部位管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePart(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PartService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出部位管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "部位管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:part:export")]
        public IActionResult Export([FromQuery] PartQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _PartService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "Part", "部位管理");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    
}
}