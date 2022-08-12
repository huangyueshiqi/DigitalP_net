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
    /// 菜单管理Service业务层处理
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [AppService(ServiceType = typeof(IUiLevelService), ServiceLifetime = LifeTime.Transient)]
    public class UiLevelService : BaseService<UiLevel>, IUiLevelService
    {
        private readonly UiLevelRepository _UiLevelRepository;
        public UiLevelService(UiLevelRepository repository)
        {
            _UiLevelRepository = repository;
        }

        #region 业务逻辑代码

        /// <summary>
        /// 查询菜单管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<UiLevel> GetList(UiLevelQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<UiLevel>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.ParentID != null, it => it.ParentID == parm.ParentID);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ShowName), it => it.ShowName.Contains(parm.ShowName));
            var response = _UiLevelRepository
                .Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询菜单管理树列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<UiLevel> GetTreeList(UiLevelQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<UiLevel>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(parm.ParentID != null, it => it.ParentID == parm.ParentID);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ShowName), it => it.ShowName.Contains(parm.ShowName));

            var response = _UiLevelRepository.Queryable().Where(predicate.ToExpression())
                .ToTree(it => it.Children, it => it.ParentID, 0);

            return response;
        }
        /// <summary>
        /// 添加菜单管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddUiLevel(UiLevel parm)
        {
            var response = _UiLevelRepository.Insert(parm, it => new
            {
                it.Name,
                it.Level,
                it.UiIndex,
                it.IconRes,
                it.SelectedIconRes,
                it.ParentID,
                it.PartTagID,
                it.ShowName,
                it.TemplateHeight,
                it.TemplateGridSizeX,
                it.TemplateGridSizeY,
                it.CamType,
                it.DefaultAdjustNum,
                it.IconResID,
                it.SelectedIconResID,
            });
            return response;
        }

        /// <summary>
        /// 修改菜单管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdateUiLevel(UiLevel parm)
        {
            var response = _UiLevelRepository.Update(w => w.Id == parm.Id, it => new UiLevel()
            {
                Name = parm.Name,
                Level = parm.Level,
                UiIndex = parm.UiIndex,
                IconRes = parm.IconRes,
                SelectedIconRes = parm.SelectedIconRes,
                ParentID = parm.ParentID,
                PartTagID = parm.PartTagID,
                ShowName = parm.ShowName,
                TemplateHeight = parm.TemplateHeight,
                CamType = parm.CamType,
                DefaultAdjustNum = parm.DefaultAdjustNum,
                IconResID = parm.IconResID,
                SelectedIconResID = parm.SelectedIconResID,
            });
            return response;
        }
        #endregion
    }
}