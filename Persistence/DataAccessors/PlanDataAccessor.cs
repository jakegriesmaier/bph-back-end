using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataAccessors
{
    public class PlanDataAccessor : PlanDataAccessorBase
    {

        private BphContext _context;

        public PlanDataAccessor(BphContext context)
        {
            _context = context;
        }

        protected override async Task CreatePlanCore(Plan plan)
        {
            var planDao = Mapper.map(plan);
            try
            {
                _context.Plans.Add(planDao);
                var result = await _context.SaveChangesAsync();
                return;
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<Plan> GetPlanCore(string planId)
        {
            try
            {
                var plan = await _context.Plans.FindAsync(planId);
                return Mapper.map(plan);
            }
            catch
            {
                throw;
            }
        }
    }
}
