﻿using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Skuld.Core;
using System;
using System.IO;

namespace Skuld.Models
{
	public class SkuldDbContextFactory : IDesignTimeDbContextFactory<SkuldDbContext>
	{
		public SkuldDbContext CreateDbContext(string[] args = null)
		{
			DotEnv.Load(new DotEnvOptions(envFilePaths: new[] { Path.Combine(SkuldAppContext.BaseDirectory, ".env") }));

			var connStr = Environment.GetEnvironmentVariable("SKULD_CONNSTR");

			var serverVersion = ServerVersion.AutoDetect(connStr);

			var optionsBuilder = new DbContextOptionsBuilder<SkuldDbContext>();
			optionsBuilder.UseMySql(
				connStr,
				serverVersion,
				x =>
				{
					x.EnableRetryOnFailure();
				});

			return new SkuldDbContext(optionsBuilder.Options);
		}
	}
}