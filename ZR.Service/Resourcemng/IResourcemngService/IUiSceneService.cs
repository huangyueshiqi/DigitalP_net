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
    public interface IUiSceneService : IBaseService<UiScene>
    {
        PagedInfo<UiScene> GetList(UiSceneQueryDto parm);

        int AddUiScene(UiScene parm);

        int UpdateUiScene(UiScene parm);
    }
}
