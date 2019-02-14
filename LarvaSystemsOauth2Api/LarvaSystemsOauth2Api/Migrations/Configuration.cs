namespace LarvaSystemsOauth2Api.Migrations
{
    using LarvaSystemsOauth2Api.DatabaseFiles;
    using LarvaSystemsOauth2Api.Entities;
    using LarvaSystemsOauth2Api.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LarvaSystemsOauth2Api.DatabaseFiles.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            // register mysql code generator
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());

            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
            AuthContext context = new AuthContext();
            if (context.Clients.Count() > 0)
            {
                return;
            }

            context.Clients.AddRange(BuildClientsList());
            context.SaveChanges();
        }

        protected override void Seed(LarvaSystemsOauth2Api.DatabaseFiles.AuthContext context)
        {
            if (context.Clients.Count() > 0)
            {
                return;
            }

            context.Clients.AddRange(BuildClientsList());
            context.SaveChanges();
        }
        private static List<Client> BuildClientsList()
        {

            List<Client> ClientsList = new List<Client>
            {
                new Client
                { Id = "Larva",
                    Secret= Helper.GetHash("larvaAplikace"),
                    Name="larví aplikace",
                    ApplicationType =  Models.ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "*"
                }
               
            };

            return ClientsList;
        }
    }
}
