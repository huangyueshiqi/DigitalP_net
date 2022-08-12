using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace ZR.Model.Models
{
    /// <summary>
    /// 场景管理，数据实体对象
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [SugarTable("ui_scene")]
    public class UiScene
    {
        /// <summary>
        /// 描述 :编号 
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "编号")]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// 描述 :UI显示名称 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "UI显示名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述 :UI显示顺序 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "UI显示顺序")]
        public int? Index { get; set; }

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
        /// 描述 :场景编号 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "场景编号")]
        public int? SceneID { get; set; }

        /// <summary>
        /// 描述 :音频资源ID 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "音频资源ID")]
        public int? AudioResID { get; set; }

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