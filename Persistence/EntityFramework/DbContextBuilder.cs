using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework
{
    internal sealed class DbContextBuilder
    {
        public BphContext BuildContext()
        {
            var options = new DbOptionsBuilder().BuildOptions();
            return new BphContext(options);
        }
    }
}
