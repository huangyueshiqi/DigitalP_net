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
    /// 服装管理Service业务层处理
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceType = typeof(IClothService), ServiceLifetime = LifeTime.Transient)]
    public class ClothService : BaseService<Cloth>, IClothService
    {
        private readonly ClothRepository _ClothRepository;
        public ClothService(ClothRepository repository)
        {
            _ClothRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询服装管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<Cloth> GetList(ClothQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<Cloth>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.PartTagID != null, it => it.PartTagID == parm.PartTagID);
            predicate = predicate.AndIF(parm.ResID != null, it => it.ResID == parm.ResID);
            var response = _ClothRepository
                .Queryable()
                .OrderBy("Id asc")
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加服装管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddCloth(Cloth parm)
        {
            var response = _ClothRepository.Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.RaceTagID,
                it.JobTagID,
                it.PartTagID,
                it.PartIndex,
                it.Style,
                it.ResID,
                it.Constraint2Body,
                it.Constraint2Cloth,
                it.VipLevel,
                it.OwnerUserID,
            });
            return response;
        }

        /// <summary>
        /// 修改服装管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateCloth(Cloth parm)
        {
            var response = _ClothRepository.Update(w => w.Id == parm.Id, it => new Cloth()
            {
                Name = parm.Name,
                RaceTagID = parm.RaceTagID,
                JobTagID = parm.JobTagID,
                PartTagID = parm.PartTagID,
                PartIndex = parm.PartIndex,
                Style = parm.Style,
                ResID = parm.ResID,
                Constraint2Body = parm.Constraint2Body,
                Constraint2Cloth = parm.Constraint2Cloth,
                VipLevel = parm.VipLevel,
                OwnerUserID = parm.OwnerUserID,
            });
            return response;
        }
        #endregion
    }
}