using System;
using ZR.Model;
using ZR.Model.Dto;
using ZR.Model.Models;
using System.Collections.Generic;

namespace ZR.Service.Resourcemng.IResourcemngService
{
    /// <summary>
    /// 模板管理service接口
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    public interface ITemplateService : IBaseService<Template>
    {
        PagedInfo<Template> GetList(TemplateQueryDto parm);

        int AddTemplate(Template parm);

        int UpdateTemplate(Template parm);
    }
}
