using LarvaSystemsOauth2Api.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Web;

namespace LarvaSystemsOauth2Api.DatabaseFiles
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {

        public AuthContext() : base("AuthContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MySqlInitializer());
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}