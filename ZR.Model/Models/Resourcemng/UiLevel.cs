using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace ZR.Model.Models
{
    /// <summary>
    /// 菜单管理，数据实体对象
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [SugarTable("ui_level1_2")]
    public class UiLevel
    {
        /// <summary>
        /// 描述 :编号 
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "编号")]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 描述 :名称 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述 :层级 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "层级")]
        public int? Level { get; set; }

        /// <summary>
        /// 描述 :顺序 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "顺序")]
        public int? UiIndex { get; set; }

        /// <summary>
        /// 描述 :默认图标 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "默认图标")]
        public string IconRes { get; set; }

        /// <summary>
        /// 描述 :选中图标 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "选中图标")]
        public string SelectedIconRes { get; set; }

        /// <summary>
        /// 描述 :父节点 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "父节点")]
        public int? ParentID { get; set; }

        /// <summary>
        /// 描述 :部件标签编号 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "部件标签编号")]
        public int? PartTagID { get; set; }

        /// <summary>
        /// 描述 :模板名称 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "模板名称")]
        public string ShowName { get; set; }

        /// <summary>
        /// 描述 :模板遮罩高度 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "模板遮罩高度")]
        public float TemplateHeight { get; set; }

        /// <summary>
        /// 描述 :模板格子宽度 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "模板格子宽度")]
        public float TemplateGridSizeX { get; set; }

        /// <summary>
        /// 描述 :模板格子高度 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "模板格子高度")]
        public float TemplateGridSizeY { get; set; }

        /// <summary>
        /// 描述 :相机位置类型 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "相机位置类型")]
        public int? CamType { get; set; }

        /// <summary>
        /// 描述 :默认调节项数量 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "默认调节项数量")]
        public int? DefaultAdjustNum { get; set; }

        /// <summary>
        /// 描述 :资源ID 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "资源ID")]
        public int? IconResID { get; set; }

        /// <summary>
        /// 描述 :选中资源ID 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "选中资源ID")]
        public int? SelectedIconResID { get; set; }


        [SugarColumn(IsIgnore = true)]
        public List<UiLevel> Children { get; set; }


    }
}