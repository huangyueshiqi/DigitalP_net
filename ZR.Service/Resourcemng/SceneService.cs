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
    [AppService(ServiceType = typeof(ISceneService), ServiceLifetime = LifeTime.Transient)]
    public class SceneService : BaseService<Scene>, ISceneService
    {
        private readonly SceneRepository _SceneRepository;
        public SceneService(SceneRepository repository)
        {
            _SceneRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询场景管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<Scene> GetList(SceneQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<Scene>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.Type != null, it => it.Type == parm.Type);
            var response = _SceneRepository
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
        public int AddScene(Scene parm)
        {
            var response = _SceneRepository.Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.ResIDs,
                it.Type,
                it.MaxRotateAngle,
            });
            return response;
        }

        /// <summary>
        /// 修改场景管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateScene(Scene parm)
        {
            var response = _SceneRepository.Update(w => w.Id == parm.Id, it => new Scene()
            {
                Name = parm.Name,
                ResIDs = parm.ResIDs,
                Type = parm.Type,
                MaxRotateAngle = parm.MaxRotateAngle,
            });
            return response;
        }
        #endregion
    }
}