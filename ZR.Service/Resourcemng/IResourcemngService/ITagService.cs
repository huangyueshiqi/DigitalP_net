using System;
using ZR.Model;
using ZR.Model.Dto;
using ZR.Model.Models;
using System.Collections.Generic;

namespace ZR.Service.Resourcemng.IResourcemngService
{
    /// <summary>
    /// 标签管理service接口
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    public interface ITagService : IBaseService<Tag>
    {
        PagedInfo<Tag> GetList(TagQueryDto parm);

        int AddTag(Tag parm);

        int UpdateTag(Tag parm);
    }
}
