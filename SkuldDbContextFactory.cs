using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Skuld.Core.Models
{
    public class SkuldDbContextFactory : IDesignTimeDbContextFactory<SkuldDatabaseContext>
    {
        public SkuldDatabaseContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SkuldDatabaseContext>();
            optionsBuilder.UseMySql(SkuldAppContext.GetEnvVar(SkuldAppContext.ConStrEnvVar));

            return new SkuldDatabaseContext(optionsBuilder.Options);
        }
    }
}