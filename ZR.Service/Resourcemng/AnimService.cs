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
    [AppService(ServiceType = typeof(IAnimService), ServiceLifetime = LifeTime.Transient)]
    public class AnimService : BaseService<Anim>, IAnimService
    {
        private readonly AnimRepository _AnimRepository;
        public AnimService(AnimRepository repository)
        {
            _AnimRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询动作管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<Anim> GetList(AnimQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<Anim>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.AbResID != null, it => it.AbResID == parm.AbResID);
            var response = _AnimRepository
                .Queryable()
                .OrderBy("Id asc")
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加动作管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddAnim(Anim parm)
        {
            var response = _AnimRepository.Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.RaceTagID,
                it.AbResID,
                it.ClipName,
                it.Type,
                it.AudioInfo,
                it.SzID,
            });
            return response;
        }

        /// <summary>
        /// 修改动作管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateAnim(Anim parm)
        {
            var response = _AnimRepository.Update(w => w.Id == parm.Id, it => new Anim()
            {
                Name = parm.Name,
                RaceTagID = parm.RaceTagID,
                AbResID = parm.AbResID,
                ClipName = parm.ClipName,
                Type = parm.Type,
                AudioInfo = parm.AudioInfo,
                SzID = parm.SzID,
            });
            return response;
        }
        #endregion
    }
}