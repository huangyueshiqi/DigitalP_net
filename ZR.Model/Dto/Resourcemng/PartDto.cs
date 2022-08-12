using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZR.Model.Dto;
using ZR.Model.Models;

namespace ZR.Model.Dto
{
    /// <summary>
    /// 部位管理输入对象
    /// </summary>
    public class PartDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RaceTagID { get; set; }
        public int? PartTagID { get; set; }
        public int? PartIndex { get; set; }
        public int? ResID { get; set; }
    }

    /// <summary>
    /// 部位管理查询对象
    /// </summary>
    public class PartQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? PartTagID { get; set; }
        public int? ResID { get; set; }
    }
}
