using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZR.Model.Dto;
using ZR.Model.Models;

namespace ZR.Model.Dto
{
    /// <summary>
    /// 动作管理输入对象
    /// </summary>
    public class AnimDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RaceTagID { get; set; }
        public int? AbResID { get; set; }
        public string ClipName { get; set; }
        [Required(ErrorMessage = "动画应用类型不能为空")]
        public int Type { get; set; }
        public string AudioInfo { get; set; }
        public int? SzID { get; set; }
    }

    /// <summary>
    /// 动作管理查询对象
    /// </summary>
    public class AnimQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? AbResID { get; set; }
    }
}
