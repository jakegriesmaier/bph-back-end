using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataAccessors
{
    public class SetDataAccessor : SetDataAccessorBase
    {

        private BphContext _context;

        public SetDataAccessor(BphContext context)
        {
            _context = context;
        }

        protected override Task<string> CreateSetCore(Set set)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteSetCore(string setId)
        {
            throw new NotImplementedException();
        }

        protected override Task<Set> GetSetCore(string setId)
        {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<Set>> GetSetsCore(string exerciseId)
        {
            throw new NotImplementedException();
        }

        protected override Task<Set> UpdateSetCore(Set set)
        {
            throw new NotImplementedException();
        }
    }
}
