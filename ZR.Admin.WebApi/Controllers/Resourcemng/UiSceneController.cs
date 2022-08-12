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
    /// 场景管理Controller
    /// 
    /// @tableName ui_scene
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/UiScene")]
    public class UiSceneController : BaseController
    {
        /// <summary>
        /// 场景管理接口
        /// </summary>
        private readonly IUiSceneService _UiSceneService;

        public UiSceneController(IUiSceneService UiSceneService)
        {
            _UiSceneService = UiSceneService;
        }

        /// <summary>
        /// 查询场景管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:uiscene:list")]
        public IActionResult QueryUiScene([FromQuery] UiSceneQueryDto parm)
        {
            var response = _UiSceneService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询场景管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:uiscene:query")]
        public IActionResult GetUiScene(int Id)
        {
            var response = _UiSceneService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加场景管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:uiscene:add")]
        [Log(Title = "场景管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddUiScene([FromBody] UiSceneDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<UiScene>().ToCreate(HttpContext);

            var response = _UiSceneService.AddUiScene(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新场景管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:uiscene:edit")]
        [Log(Title = "场景管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateUiScene([FromBody] UiSceneDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<UiScene>().ToUpdate(HttpContext);

            var response = _UiSceneService.UpdateUiScene(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除场景管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:uiscene:delete")]
        [Log(Title = "场景管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteUiScene(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _UiSceneService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出场景管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "场景管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:uiscene:export")]
        public IActionResult Export([FromQuery] UiSceneQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _UiSceneService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "UiScene", "场景管理");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    }
}