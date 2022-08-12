using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace ZR.Model.Models
{
    /// <summary>
    /// 头部模板，数据实体对象
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [SugarTable("ui_head")]
    public class UiHead
    {
        /// <summary>
        /// 描述 :编号 
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "编号")]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// 描述 :名称 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述 :序号 
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "序号")]
        public int Index { get; set; }

        /// <summary>
        /// 描述 :物种标签编号 
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "物种标签编号")]
        public int RaceTagID { get; set; }

        /// <summary>
        /// 描述 :模板编号 
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "模板编号")]
        public int TemplateID { get; set; }

        /// <summary>
        /// 描述 :图标资源 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "图标资源")]
        public string IconRes { get; set; }

        /// <summary>
        /// 描述 :选中图标 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "选中图标")]
        public string SelectedIconRes { get; set; }

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



    }
}