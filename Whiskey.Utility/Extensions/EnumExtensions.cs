﻿
//  <copyright file="AbstractBuilder.cs" company="优维拉软件设计工作室">



//  <last-date>2014:07:08 13:09</last-date>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Whiskey.Utility.Extensions
{
    /// <summary>
    /// 枚举<see cref="Enum"/>的扩展辅助操作方法
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举项上的<see cref="DescriptionAttribute"/>特性的文字描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            Type type = value.GetType();
            MemberInfo member = type.GetMember(value.ToString()).FirstOrDefault();
            return member != null ? member.ToDescription() : value.ToString();
        }
    }
}