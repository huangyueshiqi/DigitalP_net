using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZR.Model.Dto;
using ZR.Model.Models;

namespace ZR.Model.Dto
{
    /// <summary>
    /// 场景管理输入对象
    /// </summary>
    public class UiSceneDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Index { get; set; }
        public string IconRes { get; set; }
        public string SelectedIconRes { get; set; }
        public int? SceneID { get; set; }
        public int? AudioResID { get; set; }
        public int? IconResID { get; set; }
        public int? SelectedIconResID { get; set; }
    }

    /// <summary>
    /// 场景管理查询对象
    /// </summary>
    public class UiSceneQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? IconResID { get; set; }
    }
}
