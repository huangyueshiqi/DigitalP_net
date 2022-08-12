using System;
using Infrastructure.Attribute;
using ZR.Repository.System;
using ZR.Model.Models;

namespace ZR.Repository
{
    /// <summary>
    /// 服装管理仓储
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class ClothRepository : BaseRepository<Cloth>
    {
        #region 业务逻辑代码
        #endregion
    }
}