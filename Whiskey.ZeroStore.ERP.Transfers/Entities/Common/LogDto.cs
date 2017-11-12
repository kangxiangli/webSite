﻿
//   This file was generated by T4 code generator Dto_Creater.tt.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Whiskey.Core.Data;

namespace Whiskey.ZeroStore.ERP.Transfers
{
    public class LogDto : IAddDto, IEditDto<int>
    {
		[Display(Name = "日志标题")]
		[Required(ErrorMessage = "不能为空")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "至少{2}～{1}个字符")]
		public String LogName { get; set; }

		[Display(Name = "日志内容")]
		public String Description { get; set; }

		[Display(Name = "页面地址")]
		public String PageUrl { get; set; }

		[Display(Name = "IP地址")]
		public String IPAddress { get; set; }

		[Display(Name = "实体标识")]
		public Int32 Id { get; set; }

		[Display(Name = "排序序号")]
		public Int32 Sequence { get; set; }

    }
}