using MediaParser.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaParser.Data.Context
{
    public class SqlDbContext : DbContext
    {
        public DbSet<InputLinkHistoryEntity> InputLinkHistory { get; set; }

        public SqlDbContext()
           : base("name = SqlConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqlDbContext, Migration.Configuration>());
        }
    }
}
