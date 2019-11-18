using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using System.Transactions;

namespace SIISLtd.Migrations.UnitTests.CodeMigrations
{
    public class ThirdMigration : CodeMigration, ISpecificCodeMigrations
    {
        public override DbVersion Version { get; } = new DbVersion(1,2);
        
        public override string Comment { get; } = "comment";
        
        public override Task UpgradeAsync(DbTransaction transaction)
        {
            return DbProvider.ExecuteScriptAsync(ScriptConstants.UpScript);
        }

        public override Task DowngradeAsync(DbTransaction transaction)
        {
            return DbProvider.ExecuteScriptAsync(ScriptConstants.DownScript);
        }
    }
}