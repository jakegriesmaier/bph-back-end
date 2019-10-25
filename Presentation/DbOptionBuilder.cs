using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation
{
    internal sealed class DbOptionBuilder
    {
        private static readonly string DEFAULT_CONNECTION = "Server=(localdb)\\mssqllocaldb;Database=BphDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        private static DbContextOptionsBuilder<BphContext> OptionsBuilder =
            new DbContextOptionsBuilder<BphContext>().UseSqlServer(DEFAULT_CONNECTION);
        public DbOptionBuilder()
        {
        }
        public DbContextOptions<BphContext> BuildOptions()
        {
            return OptionsBuilder.Options;
        }

    }
}