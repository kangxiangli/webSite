﻿
//   This file was generated by T4 code generator Configuration_Creator.tt.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Whiskey.Core.Data.Entity;

namespace Whiskey.ZeroStore.ERP.Models
{
    /// <summary>
    /// 实体配置
    /// </summary>
    public class StoreConfiguration : EntityConfigurationBase<Store, int>
    {
        public StoreConfiguration() {
            ToTable("S_Store");
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(o => o.Administrators).WithMany(p => p.Stores).Map(m =>
            {
                m.ToTable("A_Store_Administrator_Relation");
                m.MapLeftKey("StoreId");
                m.MapRightKey("AdministratorId");
            });
        }
    }
}