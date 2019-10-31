using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using System.Transactions;

namespace Marvin.Migrations.UnitTests.CodeMigrations
{
    public class FourthMigration : CustomBaseCodeMigration
    {
        public FourthMigration(IDbProvider dbProvider, IReadOnlyDictionary<string, string> variables) : base(dbProvider, variables)
        {
        }

        public override DbVersion Version { get; } = new DbVersion(1,3);
        
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