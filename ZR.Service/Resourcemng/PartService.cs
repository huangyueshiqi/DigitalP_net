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
    /// 部位管理Service业务层处理
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceType = typeof(IPartService), ServiceLifetime = LifeTime.Transient)]
    public class PartService : BaseService<Part>, IPartService
    {
        private readonly PartRepository _PartRepository;
        public PartService(PartRepository repository)
        {
            _PartRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询部位管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<Part> GetList(PartQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<Part>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.PartTagID != null, it => it.PartTagID == parm.PartTagID);
            predicate = predicate.AndIF(parm.ResID != null, it => it.ResID == parm.ResID);
            var response = _PartRepository
                .Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加部位管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPart(Part parm)
        {
            var response = _PartRepository.Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.RaceTagID,
                it.PartTagID,
                it.PartIndex,
                it.ResID,
            });
            return response;
        }

        /// <summary>
        /// 修改部位管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePart(Part parm)
        {
            var response = _PartRepository.Update(w => w.Id == parm.Id, it => new Part()
            {
                Name = parm.Name,
                RaceTagID = parm.RaceTagID,
                PartTagID = parm.PartTagID,
                PartIndex = parm.PartIndex,
                ResID = parm.ResID,
            });
            return response;
        }
        #endregion
    }
}