﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiskey.Core.Data.Entity;

namespace Whiskey.ZeroStore.ERP.Models 
{
    public class PunishScoreRecordConfiguration : EntityConfigurationBase<PunishScoreRecord, int>
    {
        public PunishScoreRecordConfiguration()
        {
            ToTable("F_PunishScoreRecord");
			Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}