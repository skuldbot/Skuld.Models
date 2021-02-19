﻿using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using Skuld.Core;
using System;
using System.IO;

namespace Skuld.Models
{
	public class SkuldDbContextFactory : IDesignTimeDbContextFactory<SkuldDbContext>
	{
		public SkuldDbContext CreateDbContext(string[] args = null)
		{
			DotEnv.Config(filePath: Path.Combine(SkuldAppContext.BaseDirectory, ".env"));

			var connStr = Environment.GetEnvironmentVariable("SKULD_CONNSTR");

			var optionsBuilder = new DbContextOptionsBuilder<SkuldDbContext>();
			optionsBuilder.UseMySql(
				connStr,
				x =>
				{
					x.EnableRetryOnFailure();
					x.CharSet(CharSet.Utf8Mb4);
				});

			return new SkuldDbContext(optionsBuilder.Options);
		}
	}
}