using Model.DataAccess.BaseAccessors;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockSetDataAccessor : SetDataAccessorBase
    {
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
