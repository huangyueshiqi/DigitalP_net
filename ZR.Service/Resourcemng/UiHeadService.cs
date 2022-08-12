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
    /// 头部模板Service业务层处理
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceType = typeof(IUiHeadService), ServiceLifetime = LifeTime.Transient)]
    public class UiHeadService : BaseService<UiHead>, IUiHeadService
    {
        private readonly UiHeadRepository _UiHeadRepository;
        public UiHeadService(UiHeadRepository repository)
        {
            _UiHeadRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询头部模板列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<UiHead> GetList(UiHeadQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<UiHead>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.TemplateID != null, it => it.TemplateID == parm.TemplateID);
            predicate = predicate.AndIF(parm.IconResID != null, it => it.IconResID == parm.IconResID);
            var response = _UiHeadRepository
                .Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加头部模板
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddUiHead(UiHead parm)
        {
            var response = _UiHeadRepository.Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.Index,
                it.RaceTagID,
                it.TemplateID,
                it.IconRes,
                it.SelectedIconRes,
                it.IconResID,
                it.SelectedIconResID,
            });
            return response;
        }

        /// <summary>
        /// 修改头部模板
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateUiHead(UiHead parm)
        {
            var response = _UiHeadRepository.Update(w => w.Id == parm.Id, it => new UiHead()
            {
                Name = parm.Name,
                Index = parm.Index,
                RaceTagID = parm.RaceTagID,
                TemplateID = parm.TemplateID,
                IconRes = parm.IconRes,
                SelectedIconRes = parm.SelectedIconRes,
                IconResID = parm.IconResID,
                SelectedIconResID = parm.SelectedIconResID,
            });
            return response;
        }
        #endregion
    }
}