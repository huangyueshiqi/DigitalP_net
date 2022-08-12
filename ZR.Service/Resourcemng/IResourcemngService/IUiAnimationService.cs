using System;
using ZR.Model;
using ZR.Model.Dto;
using ZR.Model.Models;
using System.Collections.Generic;

namespace ZR.Service.Resourcemng.IResourcemngService
{
    /// <summary>
    /// 动作管理service接口
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    public interface IUiAnimationService : IBaseService<UiAnimation>
    {
        PagedInfo<UiAnimation> GetList(UiAnimationQueryDto parm);

        int AddUiAnimation(UiAnimation parm);

        int UpdateUiAnimation(UiAnimation parm);
    }
}
