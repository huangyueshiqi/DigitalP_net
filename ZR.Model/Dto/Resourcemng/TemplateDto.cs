using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZR.Model.Dto;
using ZR.Model.Models;

namespace ZR.Model.Dto
{
    /// <summary>
    /// 模板管理输入对象
    /// </summary>
    public class TemplateDto
    {
        [Required(ErrorMessage = "编号不能为空")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RaceTagID { get; set; }
        public int? JobTagID { get; set; }
        public int? AppType { get; set; }
        public string Data { get; set; }
    }

    /// <summary>
    /// 模板管理查询对象
    /// </summary>
    public class TemplateQueryDto : PagerInfo 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? AppType { get; set; }
    }
}
