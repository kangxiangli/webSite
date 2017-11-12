﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiskey.Core.Data.Entity;
using Whiskey.ZeroStore.ERP.Models.Entities.Warehouses;

namespace Whiskey.ZeroStore.ERP.Models.Configurations.Warehouses
{
    public class InventoryRecordConfiguration: EntityConfigurationBase<InventoryRecord, int>
    {
        public InventoryRecordConfiguration()
        {
            ToTable("W_InventoryRecord");
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}