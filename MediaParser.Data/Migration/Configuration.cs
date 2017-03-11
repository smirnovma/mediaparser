using MediaParser.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaParser.Data.Migration
{
    public class Configuration : DbMigrationsConfiguration<SqlDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MediaParser.SqlDbContext";
        }
    }
}
