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
    [SugarTable("scene")]
    public class Scene
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
        /// 描述 :资源编号列表 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "资源编号列表")]
        public string ResIDs { get; set; }

        /// <summary>
        /// 描述 :场景类型 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "场景类型")]
        public int? Type { get; set; }

        /// <summary>
        /// 描述 :最大水平旋转角度 
        /// 空值 : true  
        /// </summary>
        [EpplusTableColumn(Header = "最大水平旋转角度")]
        public float MaxRotateAngle { get; set; }



    }
}