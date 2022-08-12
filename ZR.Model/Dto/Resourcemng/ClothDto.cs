using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZR.Model.Dto;
using ZR.Model.Models;

namespace ZR.Model.Dto
{
    /// <summary>
    /// 服装管理输入对象
    /// </summary>
    public class ClothDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RaceTagID { get; set; }
        public int? JobTagID { get; set; }
        public int? PartTagID { get; set; }
        public int? PartIndex { get; set; }
        public int? Style { get; set; }
        public int? ResID { get; set; }
        public string Constraint2Body { get; set; }
        public string Constraint2Cloth { get; set; }
        public int? VipLevel { get; set; }
        public string OwnerUserID { get; set; }
    }

    /// <summary>
    /// 服装管理查询对象
    /// </summary>
    public class ClothQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? PartTagID { get; set; }
        public int? ResID { get; set; }
    }
}
