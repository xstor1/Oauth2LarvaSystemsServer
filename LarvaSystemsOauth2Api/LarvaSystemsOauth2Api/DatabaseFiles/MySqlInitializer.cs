using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace LarvaSystemsOauth2Api.DatabaseFiles
{
    public class MySqlInitializer : IDatabaseInitializer<LarvaSystemsOauth2Api.DatabaseFiles.AuthContext>
    {
        public void InitializeDatabase(LarvaSystemsOauth2Api.DatabaseFiles.AuthContext context)
        {
            if (!context.Database.Exists())
            {
                // if database did not exist before - create it
                context.Database.Create();
            }
            else
            {
                // query to check if MigrationHistory table is present in the database
                var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                string.Format(
                  "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
                  "oauth"));

                // if MigrationHistory table is not there (which is the case first time we run) - create it
                if (migrationHistoryTableExists.FirstOrDefault() == 0)
                {
                    context.Database.Delete();
                    context.Database.Create();
                }
            }
        }
    }
}