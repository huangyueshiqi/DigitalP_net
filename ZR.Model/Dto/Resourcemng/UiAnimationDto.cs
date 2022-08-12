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
    public class UiAnimationDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UiIndex { get; set; }
        public int? AnimID { get; set; }
        public string IconRes { get; set; }
        public string SelectedIconRes { get; set; }
        public int? IconResID { get; set; }
        public int? SelectedIconResID { get; set; }
    }

    /// <summary>
    /// 动作管理查询对象
    /// </summary>
    public class UiAnimationQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? IconResID { get; set; }
    }
}
