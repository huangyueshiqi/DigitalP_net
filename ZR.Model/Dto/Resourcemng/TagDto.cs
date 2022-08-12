using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZR.Model.Dto;
using ZR.Model.Models;

namespace ZR.Model.Dto
{
    /// <summary>
    /// 标签管理输入对象
    /// </summary>
    public class TagDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }
        [Required(ErrorMessage = "分类不能为空")]
        public string Group { get; set; }
        [Required(ErrorMessage = "父节点不能为空")]
        public int ParentID { get; set; }
    }

    /// <summary>
    /// 标签管理查询对象
    /// </summary>
    public class TagQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
    }
}
