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
    /// 动作管理Service业务层处理
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceType = typeof(IUiAnimationService), ServiceLifetime = LifeTime.Transient)]
    public class UiAnimationService : BaseService<UiAnimation>, IUiAnimationService
    {
        private readonly UiAnimationRepository _UiAnimationRepository;
        public UiAnimationService(UiAnimationRepository repository)
        {
            _UiAnimationRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询动作管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<UiAnimation> GetList(UiAnimationQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<UiAnimation>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.IconResID != null, it => it.IconResID == parm.IconResID);
            var response = _UiAnimationRepository
                .Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加动作管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddUiAnimation(UiAnimation parm)
        {
            var response = _UiAnimationRepository.Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.UiIndex,
                it.AnimID,
                it.IconRes,
                it.SelectedIconRes,
                it.IconResID,
                it.SelectedIconResID,
            });
            return response;
        }

        /// <summary>
        /// 修改动作管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateUiAnimation(UiAnimation parm)
        {
            var response = _UiAnimationRepository.Update(w => w.Id == parm.Id, it => new UiAnimation()
            {
                Name = parm.Name,
                UiIndex = parm.UiIndex,
                AnimID = parm.AnimID,
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