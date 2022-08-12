using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace ZR.Model.Models
{
    /// <summary>
    /// 模板管理，数据实体对象
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [SugarTable("template")]
    public class Template
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
        /// 描述 :物种标签编号 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "物种标签编号")]
        public int? RaceTagID { get; set; }

        /// <summary>
        /// 描述 :职业标签编号 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "职业标签编号")]
        public int? JobTagID { get; set; }

        /// <summary>
        /// 描述 :模板类型 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "模板类型")]
        public int? AppType { get; set; }

        /// <summary>
        /// 描述 :数据 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "数据")]
        public string Data { get; set; }



    }
}