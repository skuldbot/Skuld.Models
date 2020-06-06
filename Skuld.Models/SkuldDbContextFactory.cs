using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;

namespace Skuld.Models
{
    public class SkuldDbContextFactory : IDesignTimeDbContextFactory<SkuldDbContext>
    {
        public SkuldDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SkuldDbContext>();
            optionsBuilder.UseMySql(
                Environment.GetEnvironmentVariable("SKULD_CONNSTR"),
                x=>
                {
                    x.EnableRetryOnFailure();
                    x.CharSet(CharSet.Utf8Mb4);
                });

            return new SkuldDbContext(optionsBuilder.Options);
        }
    }
}