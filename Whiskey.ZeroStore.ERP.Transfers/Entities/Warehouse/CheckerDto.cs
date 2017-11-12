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
using System.ComponentModel;
using Whiskey.ZeroStore.ERP.Models;

namespace Whiskey.ZeroStore.ERP.Transfers
{
    public class CheckerDto : IAddDto, IEditDto<int>
    {

        [Display(Name = "盘点标识符")]
        [StringLength(20)]
        public string CheckGuid { get; set; }

        [Display(Name = "盘点店铺")]
        public int StoreId { get; set; }

        [Display(Name = "所属仓库")]
        public int StorageId { get; set; }

        [Display(Name = "配货")]
        [Description("配货的标识,为null时表示对店铺的盘点，不为null时是针对配货的盘点")]
        public int? OrberblankId { get; set; }

        [Display(Name = "品牌")]
        [Description("商品的品牌")]
        public int? BrandId { get; set; }

        [Display(Name = "分类")]
        [Description("外套，裤子，大衣等分类")]
        public int? CategoryId { get; set; }

        [Display(Name = "盘点名称")]
        [StringLength(30)]
        public string CheckerName { get; set; }

        [Display(Name = "盘点前数量")]
        [Description("记录盘点前，库存的总数量")]
        public int BeforeCheckQuantity { get; set; }

        [Display(Name = "盘点后数量")]
        [Description("记录盘点后，库存的总数量")]
        public int AfterCheckQuantity { get; set; }

        /// <summary>
        /// 待盘数量
        /// </summary>

        [Display(Name = "待盘数量")]
        public int CheckQuantity { get; set; }

        /// <summary>
        /// 无效数量
        /// </summary>

        [Display(Name = "无效数量")]
        public int InvalidQuantity { get; set; }
        /// <summary>
        /// 已盘数量
        /// </summary>

        [Display(Name = "已盘数量")]
        public int CheckedQuantity { get; set; }

        /// <summary>
        /// 有效数量
        /// </summary>

        [Display(Name = "有效数量")]
        public int ValidQuantity { get; set; }

        /// <summary>
        /// 缺货数量
        /// </summary>

        [Display(Name = "缺货数量")]
        public int MissingQuantity { get; set; }

        /// <summary>
        /// 余货数量
        /// </summary>

        [Display(Name = "余货数量")]
        public int ResidueQuantity { get; set; }

        [Display(Name = "盘点状态")]
        [Description("参照CheckerFlag")]
        public CheckerFlag CheckerState { get; set; }

        [Display(Name = "盘点备注")]
        [StringLength(200)]
        public string Notes { get; set; }


        [Display(Name = "标识")]
        public int Id { get; set; }

        [Display(Name = "操作人")]
        public virtual int? OperatorId { get; set; }
    }
}