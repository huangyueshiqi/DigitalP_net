using System;
using ZR.Model;
using ZR.Model.Dto;
using ZR.Model.Models;
using System.Collections.Generic;

namespace ZR.Service.Resourcemng.IResourcemngService
{
    /// <summary>
    /// 头部模板service接口
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    public interface IUiHeadService : IBaseService<UiHead>
    {
        PagedInfo<UiHead> GetList(UiHeadQueryDto parm);

        int AddUiHead(UiHead parm);

        int UpdateUiHead(UiHead parm);
    }
}
