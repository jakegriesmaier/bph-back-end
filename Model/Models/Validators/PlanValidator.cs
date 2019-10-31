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
            //Current user is added to plan
            //So validate Curr User is a coach here. 
            return true;
        }
        public static bool ValidateGetPlan(Plan plan)
        {
            if (plan.PlanId == null)
            {
                return false;
            }
            return true;
        }
    }
}
