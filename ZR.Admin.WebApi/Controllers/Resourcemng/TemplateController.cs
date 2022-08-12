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
    /// 模板管理Controller
    /// 
    /// @tableName template
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/Template")]
    public class TemplateController : BaseController
    {
        /// <summary>
        /// 模板管理接口
        /// </summary>
        private readonly ITemplateService _TemplateService;

        public TemplateController(ITemplateService TemplateService)
        {
            _TemplateService = TemplateService;
        }

        /// <summary>
        /// 查询模板管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:template:list")]
        public IActionResult QueryTemplate([FromQuery] TemplateQueryDto parm)
        {
            var response = _TemplateService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询模板管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:template:query")]
        public IActionResult GetTemplate(int Id)
        {
            var response = _TemplateService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加模板管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:template:add")]
        [Log(Title = "模板管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddTemplate([FromBody] TemplateDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<Template>().ToCreate(HttpContext);

            var response = _TemplateService.AddTemplate(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新模板管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:template:edit")]
        [Log(Title = "模板管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateTemplate([FromBody] TemplateDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<Template>().ToUpdate(HttpContext);

            var response = _TemplateService.UpdateTemplate(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除模板管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:template:delete")]
        [Log(Title = "模板管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteTemplate(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _TemplateService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出模板管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "模板管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:template:export")]
        public IActionResult Export([FromQuery] TemplateQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _TemplateService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "Template", "模板管理");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    }
}