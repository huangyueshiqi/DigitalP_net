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
    /// 标签管理Service业务层处理
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceType = typeof(ITagService), ServiceLifetime = LifeTime.Transient)]
    public class TagService : BaseService<Tag>, ITagService
    {
        private readonly TagRepository _TagRepository;
        public TagService(TagRepository repository)
        {
            _TagRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询标签管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<Tag> GetList(TagQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<Tag>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Group), it => it.Group.Contains(parm.Group));
            var response = _TagRepository
                .Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加标签管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddTag(Tag parm)
        {
            var response = _TagRepository.Insert(parm, it => new
            {
                it.Id,
                it.Name,
                it.Group,
                it.ParentID,
            });
            return response;
        }

        /// <summary>
        /// 修改标签管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateTag(Tag parm)
        {
            var response = _TagRepository.Update(w => w.Id == parm.Id, it => new Tag()
            {
                Name = parm.Name,
                Group = parm.Group,
                ParentID = parm.ParentID,
            });
            return response;
        }
        #endregion
    }
}