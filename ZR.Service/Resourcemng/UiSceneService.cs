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
    /// 场景管理Service业务层处理
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceType = typeof(IUiSceneService), ServiceLifetime = LifeTime.Transient)]
    public class UiSceneService : BaseService<UiScene>, IUiSceneService
    {
        private readonly UiSceneRepository _UiSceneRepository;
        public UiSceneService(UiSceneRepository repository)
        {
            _UiSceneRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询场景管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<UiScene> GetList(UiSceneQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<UiScene>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.IconResID != null, it => it.IconResID == parm.IconResID);
            var response = _UiSceneRepository
                .Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加场景管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddUiScene(UiScene parm)
        {
            var response = _UiSceneRepository.Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.Index,
                it.IconRes,
                it.SelectedIconRes,
                it.SceneID,
                it.AudioResID,
                it.IconResID,
                it.SelectedIconResID,
            });
            return response;
        }

        /// <summary>
        /// 修改场景管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateUiScene(UiScene parm)
        {
            var response = _UiSceneRepository.Update(w => w.Id == parm.Id, it => new UiScene()
            {
                Name = parm.Name,
                Index = parm.Index,
                IconRes = parm.IconRes,
                SelectedIconRes = parm.SelectedIconRes,
                SceneID = parm.SceneID,
                AudioResID = parm.AudioResID,
                IconResID = parm.IconResID,
                SelectedIconResID = parm.SelectedIconResID,
            });
            return response;
        }
        #endregion
    }
}