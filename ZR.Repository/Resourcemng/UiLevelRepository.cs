using System;
using Infrastructure.Attribute;
using ZR.Repository.System;
using ZR.Model.Models;

namespace ZR.Repository
{
    /// <summary>
    /// 菜单管理仓储
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class UiLevelRepository : BaseRepository<UiLevel>
    {
        #region 业务逻辑代码
        #endregion
    }
}