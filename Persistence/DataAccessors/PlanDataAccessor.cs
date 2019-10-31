using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
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

        protected override Task CreatePlanCore(Plan plan)
        {
            throw new NotImplementedException();
        }

        protected override Task<Plan> GetPlanCore(string planId)
        {
            throw new NotImplementedException();
        }
    }
}
