using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Skuld.Models
{
    public class SkuldDbContextFactory : IDesignTimeDbContextFactory<SkuldDbContext>
    {
        public SkuldDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SkuldDbContext>();
            optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("SKULD_CONNSTR"));

            return new SkuldDbContext(optionsBuilder.Options);
        }
    }
}