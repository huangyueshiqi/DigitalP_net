using System;
using Infrastructure.Attribute;
using ZR.Repository.System;
using ZR.Model.Models;

namespace ZR.Repository
{
    /// <summary>
    /// 标签管理仓储
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class TagRepository : BaseRepository<Tag>
    {
        #region 业务逻辑代码
        #endregion
    }
}