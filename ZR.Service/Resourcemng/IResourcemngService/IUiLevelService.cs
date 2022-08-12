using System;
using ZR.Model;
using ZR.Model.Dto;
using ZR.Model.Models;
using System.Collections.Generic;

namespace ZR.Service.Resourcemng.IResourcemngService
{
    /// <summary>
    /// 菜单管理service接口
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    public interface IUiLevelService : IBaseService<UiLevel>
    {
        PagedInfo<UiLevel> GetList(UiLevelQueryDto parm);

        List<UiLevel> GetTreeList(UiLevelQueryDto parm);
        int AddUiLevel(UiLevel parm);

        int UpdateUiLevel(UiLevel parm);
    }
}
