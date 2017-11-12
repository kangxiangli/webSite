
using System.ComponentModel.DataAnnotations.Schema;
using Whiskey.Core.Data.Entity;

namespace Whiskey.ZeroStore.ERP.Models
{
    public class GameRuleConfiguration : EntityConfigurationBase<GameRule, int>
    {
        public GameRuleConfiguration()
        {
            ToTable("G_GameRule");
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
