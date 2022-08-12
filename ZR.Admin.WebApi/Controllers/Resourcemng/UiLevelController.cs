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
    /// 菜单管理Controller
    /// 
    /// @tableName ui_level1_2
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/UiLevel")]
    public class UiLevelController : BaseController
    {
        /// <summary>
        /// 菜单管理接口
        /// </summary>
        private readonly IUiLevelService _UiLevelService;

        public UiLevelController(IUiLevelService UiLevelService)
        {
            _UiLevelService = UiLevelService;
        }

        /// <summary>
        /// 查询菜单管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:uilevel:list")]
        public IActionResult QueryUiLevel([FromQuery] UiLevelQueryDto parm)
        {
            var response = _UiLevelService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询菜单管理列表树
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("treeList")]
        [ActionPermissionFilter(Permission = "resourcemng:uilevel:list")]
        public IActionResult QueryTreeUiLevel([FromQuery] UiLevelQueryDto parm)
        {
            var response = _UiLevelService.GetTreeList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询菜单管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:uilevel:query")]
        public IActionResult GetUiLevel(int Id)
        {
            var response = _UiLevelService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加菜单管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:uilevel:add")]
        [Log(Title = "菜单管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddUiLevel([FromBody] UiLevelDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<UiLevel>().ToCreate(HttpContext);

            var response = _UiLevelService.AddUiLevel(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新菜单管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:uilevel:edit")]
        [Log(Title = "菜单管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateUiLevel([FromBody] UiLevelDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<UiLevel>().ToUpdate(HttpContext);

            var response = _UiLevelService.UpdateUiLevel(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除菜单管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:uilevel:delete")]
        [Log(Title = "菜单管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteUiLevel(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _UiLevelService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出菜单管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "菜单管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:uilevel:export")]
        public IActionResult Export([FromQuery] UiLevelQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _UiLevelService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "UiLevel", "菜单管理");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    }
}