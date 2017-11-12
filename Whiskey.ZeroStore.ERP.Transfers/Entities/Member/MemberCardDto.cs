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
    public class MemberCardDto : IAddDto, IEditDto<int>
    {
		[Display(Name = "储值卡名称")]
		[Required(ErrorMessage = "不能为空")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "至少{2}～{1}个字符")]
		public String CardName { get; set; }

		[Display(Name = "储值卡号")]
		public String CardNumber { get; set; }

		[Display(Name = "储值卡密")]
		public String CardKey { get; set; }

		[Display(Name = "储值卡简介")]
		public String Description { get; set; }

		[Display(Name = "卡内余额")]
		public Decimal Balance { get; set; }

		[Display(Name = "起始时间")]
		public DateTime StartTime { get; set; }

		[Display(Name = "结束时间")]
		public DateTime EndTime { get; set; }

		[Display(Name = "是否启用")]
		public Boolean IsUsed { get; set; }

		[Display(Name = "备注信息")]
		public String Notes { get; set; }

		[Display(Name = "实体标识")]
		public Int32 Id { get; set; }

		[Display(Name = "排序序号")]
		public Int32 Sequence { get; set; }

    }
}