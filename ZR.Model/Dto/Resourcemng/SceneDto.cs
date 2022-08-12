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
    public class SceneDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResIDs { get; set; }
        public int? Type { get; set; }
        public float MaxRotateAngle { get; set; }
    }

    /// <summary>
    /// 场景管理查询对象
    /// </summary>
    public class SceneQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
    }
}
