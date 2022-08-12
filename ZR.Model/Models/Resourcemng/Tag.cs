using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace ZR.Model.Models
{
    /// <summary>
    /// 标签管理，数据实体对象
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [SugarTable("tag")]
    public class Tag
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
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述 :分类 
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "分类")]
        public string Group { get; set; }

        /// <summary>
        /// 描述 :父节点 
        /// 空值 : false  
        /// </summary>
        [EpplusTableColumn(Header = "父节点")]
        public int ParentID { get; set; }



    }
}