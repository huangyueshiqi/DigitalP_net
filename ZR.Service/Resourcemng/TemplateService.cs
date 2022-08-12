using System;
using SqlSugar;
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Attribute;
using ZR.Model;
using ZR.Model.Dto;
using ZR.Model.Models;
using ZR.Repository;
using ZR.Service.Resourcemng.IResourcemngService;

namespace ZR.Service.Resourcemng
{
    /// <summary>
    /// 模板管理Service业务层处理
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceType = typeof(ITemplateService), ServiceLifetime = LifeTime.Transient)]
    public class TemplateService : BaseService<Template>, ITemplateService
    {
        private readonly TemplateRepository _TemplateRepository;
        public TemplateService(TemplateRepository repository)
        {
            _TemplateRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询模板管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<Template> GetList(TemplateQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<Template>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.AppType != null, it => it.AppType == parm.AppType);
            var response = _TemplateRepository
                .Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加模板管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddTemplate(Template parm)
        {
            var response = _TemplateRepository.Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.RaceTagID,
                it.JobTagID,
                it.AppType,
                it.Data,
            });
            return response;
        }

        /// <summary>
        /// 修改模板管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateTemplate(Template parm)
        {
            var response = _TemplateRepository.Update(w => w.Id == parm.Id, it => new Template()
            {
                Name = parm.Name,
                RaceTagID = parm.RaceTagID,
                JobTagID = parm.JobTagID,
                AppType = parm.AppType,
                Data = parm.Data,
            });
            return response;
        }
        #endregion
    }
}