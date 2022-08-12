using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZR.Model.Dto;
using ZR.Model.Models;

namespace ZR.Model.Dto
{
    /// <summary>
    /// 菜单管理输入对象
    /// </summary>
    public class UiLevelDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? UiIndex { get; set; }
        public string IconRes { get; set; }
        public string SelectedIconRes { get; set; }
        public int? ParentID { get; set; }
        public int? PartTagID { get; set; }
        public string ShowName { get; set; }
        public float TemplateHeight { get; set; }
        public float TemplateGridSizeX { get; set; }
        public float TemplateGridSizeY { get; set; }
        public int? CamType { get; set; }
        public int? DefaultAdjustNum { get; set; }
        public int? IconResID { get; set; }
        public int? SelectedIconResID { get; set; }
    }

    /// <summary>
    /// 菜单管理查询对象
    /// </summary>
    public class UiLevelQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }
        public string ShowName { get; set; }
    }
}
