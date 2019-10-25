using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework
{
    public partial class BphContext
    {
        public BphContext(DbContextOptions<BphContext> options, string callerMethod = null) : base(options)
        {
                  
        }
        private void OnAfterModelCreating(ModelBuilder builder)
        {
        }
    }
}
