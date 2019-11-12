using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class PlanValidator
    {
        public static bool ValidateCreatePlan(Plan plan)
        {
            if (plan.PlanId != null)
            {
                return false;
            }
            if (plan.Coach == null)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateGetPlan(string planId)
        {
            if (planId == null)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateUpdatePlan(Plan plan)
        {
            if (plan.PlanId == null)
            {
                return false;
            }
            if (plan.Coach == null)
            {
                return false;
            }
            return true;
        }
    }
}
