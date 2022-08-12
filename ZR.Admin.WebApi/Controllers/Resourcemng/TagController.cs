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
    /// 标签管理Controller
    /// 
    /// @tableName tag
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/Tag")]
    public class TagController : BaseController
    {
        /// <summary>
        /// 标签管理接口
        /// </summary>
        private readonly ITagService _TagService;

        public TagController(ITagService TagService)
        {
            _TagService = TagService;
        }

        /// <summary>
        /// 查询标签管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:tag:list")]
        public IActionResult QueryTag([FromQuery] TagQueryDto parm)
        {
            var response = _TagService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询标签管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:tag:query")]
        public IActionResult GetTag(int Id)
        {
            var response = _TagService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加标签管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:tag:add")]
        [Log(Title = "标签管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddTag([FromBody] TagDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<Tag>().ToCreate(HttpContext);

            var response = _TagService.AddTag(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新标签管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:tag:edit")]
        [Log(Title = "标签管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateTag([FromBody] TagDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<Tag>().ToUpdate(HttpContext);

            var response = _TagService.UpdateTag(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除标签管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:tag:delete")]
        [Log(Title = "标签管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteTag(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _TagService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出标签管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "标签管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:tag:export")]
        public IActionResult Export([FromQuery] TagQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _TagService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "Tag", "标签管理");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    }
}