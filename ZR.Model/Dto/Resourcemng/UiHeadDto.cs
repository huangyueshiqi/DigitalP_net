using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZR.Model.Dto;
using ZR.Model.Models;

namespace ZR.Model.Dto
{
    /// <summary>
    /// 头部模板输入对象
    /// </summary>
    public class UiHeadDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "序号不能为空")]
        public int Index { get; set; }
        [Required(ErrorMessage = "物种标签编号不能为空")]
        public int RaceTagID { get; set; }
        [Required(ErrorMessage = "模板编号不能为空")]
        public int TemplateID { get; set; }
        public string IconRes { get; set; }
        public string SelectedIconRes { get; set; }
        public int? IconResID { get; set; }
        public int? SelectedIconResID { get; set; }
    }

    /// <summary>
    /// 头部模板查询对象
    /// </summary>
    public class UiHeadQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? TemplateID { get; set; }
        public int? IconResID { get; set; }
    }
}
