using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework
{
    internal sealed class DbOptionsBuilder
    {
        private static readonly string DEFAULT_CONNECTION = "Server=(localdb)\\mssqllocaldb;Database=BphDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        private static DbContextOptionsBuilder<BphContext> OptionsBuilder =
            new DbContextOptionsBuilder<BphContext>().UseSqlServer(DEFAULT_CONNECTION);

        public DbContextOptions<BphContext> BuildOptions()
        {
            return OptionsBuilder.Options;
        }
    }
}
