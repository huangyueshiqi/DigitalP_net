using System;
using ZR.Model;
using ZR.Model.Dto;
using ZR.Model.Models;
using System.Collections.Generic;

namespace ZR.Service.Resourcemng.IResourcemngService
{
    /// <summary>
    /// 部位管理service接口
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    public interface IPartService : IBaseService<Part>
    {
        PagedInfo<Part> GetList(PartQueryDto parm);

        int AddPart(Part parm);

        int UpdatePart(Part parm);
    }
}
