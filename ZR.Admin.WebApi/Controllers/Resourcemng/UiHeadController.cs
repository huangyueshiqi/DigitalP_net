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
    /// 头部模板Controller
    /// 
    /// @tableName ui_head
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/UiHead")]
    public class UiHeadController : BaseController
    {
        /// <summary>
        /// 头部模板接口
        /// </summary>
        private readonly IUiHeadService _UiHeadService;

        public UiHeadController(IUiHeadService UiHeadService)
        {
            _UiHeadService = UiHeadService;
        }

        /// <summary>
        /// 查询头部模板列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:uihead:list")]
        public IActionResult QueryUiHead([FromQuery] UiHeadQueryDto parm)
        {
            var response = _UiHeadService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询头部模板详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:uihead:query")]
        public IActionResult GetUiHead(int Id)
        {
            var response = _UiHeadService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加头部模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:uihead:add")]
        [Log(Title = "头部模板", BusinessType = BusinessType.INSERT)]
        public IActionResult AddUiHead([FromBody] UiHeadDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<UiHead>().ToCreate(HttpContext);

            var response = _UiHeadService.AddUiHead(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新头部模板
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:uihead:edit")]
        [Log(Title = "头部模板", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateUiHead([FromBody] UiHeadDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<UiHead>().ToUpdate(HttpContext);

            var response = _UiHeadService.UpdateUiHead(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除头部模板
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:uihead:delete")]
        [Log(Title = "头部模板", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteUiHead(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _UiHeadService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出头部模板
        /// </summary>
        /// <returns></returns>
        [Log(Title = "头部模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:uihead:export")]
        public IActionResult Export([FromQuery] UiHeadQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _UiHeadService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "UiHead", "头部模板");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    }
}