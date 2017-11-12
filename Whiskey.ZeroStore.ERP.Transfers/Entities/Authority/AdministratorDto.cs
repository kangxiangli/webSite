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
    public class AdministratorDto : IAddDto, IEditDto<int>
    {
        //[Display(Name = "员工编号")]
        //[Required(ErrorMessage = "不能为空")]
        //[StringLength(10, ErrorMessage = "最多{1}个字符")]
        //public virtual string AdminNum { get; set; }

        //[Display(Name = "员工昵称")]
        //[Required(ErrorMessage = "不能为空")]
        //[StringLength(50, MinimumLength = 1, ErrorMessage = "至少{2}～{1}个字符")]
        //public virtual string AdminName { get; set; }

        //[Display(Name = "员工密码")]
        //[StringLength(16, ErrorMessage = "最多{1}个字符")]
        //public virtual string AdminPass { get; set; }

        [Display(Name = "入职时间")]
        [Required(ErrorMessage="请选择入职时间")]
        public virtual DateTime EntryTime { get; set; }

        //[Display(Name = "电子邮箱")]
        //[StringLength(32, ErrorMessage = "最多{1}个字符")]
        //public virtual string Email { get; set; }

        //[Display(Name = "手机号码")]
        //[StringLength(11, ErrorMessage = "最多{1}个字符")]
        //public virtual string MobilePhone { get; set; }

        //[Display(Name = "真实姓名")]
        //[Required(ErrorMessage = "请填写真实姓名")]
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "至少{2}～{1}个字符")]
        //public String RealName { get; set; }

        //[Display(Name = "本人性别")]
        //[Required(ErrorMessage = "请选择性别")]
        //public virtual int Gender { get; set; }

		[Display(Name = "备注信息")]
        [StringLength(1000, ErrorMessage = "最多{1}个字符")]
        public virtual string Notes { get; set; }

		[Display(Name = "登录次数")]
        public virtual long LoginCount { get; set; }

        [Display(Name = "工作时间类型是否改变")]
        public virtual bool? whetherChange { get; set; }

        [Display(Name = "改变时间")]
        public virtual DateTime? whetherDateTime { get; set; }
        [Display(Name = "登录时间")]
		public DateTime? LoginTime { get; set; }

        [Display(Name = "Mac地址")]
        [StringLength(12, ErrorMessage = "最大长度不能超过{1}个字符")]
        public virtual string MacAddress { get; set; }

		[Display(Name = "实体标识")]
		public Int32 Id { get; set; }		

        [Display(Name = "记住密码")]
        public bool Remembered { get; set; }
        public virtual bool IsPersonalTime { get; set; }
        [Display(Name = "会员")]
        public virtual int? MemberId { get; set; }

        [Display(Name = "所属部门")]
        public virtual int? DepartmentId { get; set; }

        [Display(Name = "职位")]
        [Required(ErrorMessage="请选择职位")]
        public virtual int? JobPositionId { get; set; }

        [Display(Name = "生日")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 应用程序在第一次成功注册到 JPush 服务器时，
        /// JPush 服务器会给客户端返回一个唯一的该设备的标识 - RegistrationID，
        /// 然后就可以根据 RegistrationID 来向设备推送消息或者通知。
        /// </summary>
        [Display(Name = "JPush注册ID")]
        [StringLength(100, ErrorMessage = "最大长度不能超过{1}个字符")]
        public virtual string JPushRegistrationID { get; set; }
    }
}