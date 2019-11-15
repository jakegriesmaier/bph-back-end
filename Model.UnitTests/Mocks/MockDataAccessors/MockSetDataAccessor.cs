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
        protected override async Task<string> CreateSetCore(Set set, string exerciseId)
        {
            return await Task.FromResult(set.SetId);
        }

        protected override async Task<bool> DeleteSetCore(string setId)
        {
            return await Task.FromResult(true);
        }

        protected override async Task<Set> GetSetCore(string setId)
        {
            var set = MockSets.GetSet(setId);
            return await Task.FromResult(set);
        }

        protected override async Task<IEnumerable<Set>> GetSetsCore(string exerciseId)
        {
            var sets = new List<Set> { MockSets.Set1() };
            return await Task.FromResult(sets);
        }

        protected override async Task<Set> UpdateSetCore(Set set)
        {
            return await Task.FromResult(set);
        }
    }
}
