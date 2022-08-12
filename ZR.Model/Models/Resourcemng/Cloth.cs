using System;
using System.Collections.Generic;
using SqlSugar;
using OfficeOpenXml.Attributes;

namespace ZR.Model.Models
{
    /// <summary>
    /// 服装管理，数据实体对象
    ///
    /// @author admin
    /// @date 2022-08-12
    /// </summary>
    [SugarTable("cloth")]
    public class Cloth
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
        /// 描述 :职业标签编号 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "职业标签编号")]
        public int? JobTagID { get; set; }

        /// <summary>
        /// 描述 :部位标签编号 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "部位标签编号")]
        public int? PartTagID { get; set; }

        /// <summary>
        /// 描述 :部位序号 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "部位序号")]
        public int? PartIndex { get; set; }

        /// <summary>
        /// 描述 :服装版型 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "服装版型")]
        public int? Style { get; set; }

        /// <summary>
        /// 描述 :资源编号 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "资源编号")]
        public int? ResID { get; set; }

        /// <summary>
        /// 描述 :服装和身体约束 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "服装和身体约束")]
        public string Constraint2Body { get; set; }

        /// <summary>
        /// 描述 :服装和服装约束 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "服装和服装约束")]
        public string Constraint2Cloth { get; set; }

        /// <summary>
        /// 描述 :VIP等级 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "VIP等级")]
        public int? VipLevel { get; set; }

        /// <summary>
        /// 描述 :专属ID 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "专属ID")]
        public string OwnerUserID { get; set; }



    }
}