using System;
using ZR.Model;
using ZR.Model.Dto;
using ZR.Model.Models;
using System.Collections.Generic;

namespace ZR.Service.Resourcemng.IResourcemngService
{
    /// <summary>
    /// 服装管理service接口
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    public interface IClothService : IBaseService<Cloth>
    {
        PagedInfo<Cloth> GetList(ClothQueryDto parm);

        int AddCloth(Cloth parm);

        int UpdateCloth(Cloth parm);
    }
}
