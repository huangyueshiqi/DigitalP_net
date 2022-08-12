using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace ZR.Model.Models
{
    /// <summary>
    /// 动作管理，数据实体对象
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [SugarTable("anim")]
    public class Anim
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
        /// 描述 :物种标签 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "物种标签")]
        public int? RaceTagID { get; set; }

        /// <summary>
        /// 描述 :ab资源编号 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "ab资源编号")]
        public int? AbResID { get; set; }

        /// <summary>
        /// 描述 :动画片段的名称 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "动画片段的名称")]
        public string ClipName { get; set; }

        /// <summary>
        /// 描述 :动画应用类型 
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "动画应用类型")]
        public int Type { get; set; }

        /// <summary>
        /// 描述 :音频信息 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "音频信息")]
        public string AudioInfo { get; set; }

        /// <summary>
        /// 描述 :深圳ID 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "深圳ID")]
        public int? SzID { get; set; }



    }
}