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
    /// @tableName scene
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [Verify]
    [Route("resourcemng/Scene")]
    public class SceneController : BaseController
    {
        /// <summary>
        /// 场景管理接口
        /// </summary>
        private readonly ISceneService _SceneService;

        public SceneController(ISceneService SceneService)
        {
            _SceneService = SceneService;
        }

        /// <summary>
        /// 查询场景管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "resourcemng:scene:list")]
        public IActionResult QueryScene([FromQuery] SceneQueryDto parm)
        {
            var response = _SceneService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询场景管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "resourcemng:scene:query")]
        public IActionResult GetScene(int Id)
        {
            var response = _SceneService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加场景管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "resourcemng:scene:add")]
        [Log(Title = "场景管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddScene([FromBody] SceneDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var modal = parm.Adapt<Scene>().ToCreate(HttpContext);

            var response = _SceneService.AddScene(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新场景管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "resourcemng:scene:edit")]
        [Log(Title = "场景管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateScene([FromBody] SceneDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<Scene>().ToUpdate(HttpContext);

            var response = _SceneService.UpdateScene(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除场景管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "resourcemng:scene:delete")]
        [Log(Title = "场景管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteScene(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SceneService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出场景管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "场景管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "resourcemng:scene:export")]
        public IActionResult Export([FromQuery] SceneQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _SceneService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "Scene", "场景管理");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

    }
}