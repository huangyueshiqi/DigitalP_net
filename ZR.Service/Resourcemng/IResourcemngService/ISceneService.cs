using System;
using ZR.Model;
using ZR.Model.Dto;
using ZR.Model.Models;
using System.Collections.Generic;

namespace ZR.Service.Resourcemng.IResourcemngService
{
    /// <summary>
    /// 场景管理service接口
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    public interface ISceneService : IBaseService<Scene>
    {
        PagedInfo<Scene> GetList(SceneQueryDto parm);

        int AddScene(Scene parm);

        int UpdateScene(Scene parm);
    }
}
