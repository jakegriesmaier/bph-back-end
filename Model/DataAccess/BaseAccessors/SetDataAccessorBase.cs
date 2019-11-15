using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.BaseAccessors
{
    public abstract class SetDataAccessorBase
    {

        public async Task<string> CreateSet(Set set)
        {
            return await CreateSetCore(set);
        } 

        public async Task<Set> GetSet(string setId)
        {
            return await GetSetCore(setId);
        }

        public async Task<Set> UpdateSet(Set set)
        {
            return await UpdateSetCore(set);
        }

        public async Task<bool> DeleteSet(string setId)
        {
            return await DeleteSetCore(setId);
        }

        public async Task<IEnumerable<Set>> GetSets(string exerciseId)
        {
            return await GetSetsCore(exerciseId);
        }


        #region necessary implementations
        protected abstract Task<string> CreateSetCore(Set set);
        protected abstract Task<Set> GetSetCore(string setId);
        protected abstract Task<Set> UpdateSetCore(Set set);
        protected abstract Task<bool> DeleteSetCore(string setId);
        protected abstract Task<IEnumerable<Set>> GetSetsCore(string exerciseId);
        #endregion
    }
}
