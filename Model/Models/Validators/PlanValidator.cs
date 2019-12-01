using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class PlanValidator
    {
        #region Validators
        public static bool ValidateCreatePlan(Plan plan)
        {
            if (PlanExists(plan))
            {
                return false;
            }
            if (!CoachExists(plan))
            {
                return false;
            }
            return true;
        }
        public static bool ValidateGetPlan(string planId)
        {
            if (!PlanExists(planId))
            {
                return false;
            }
            return true;
        }
        public static bool ValidateUpdatePlan(Plan plan)
        {
            if (!PlanExists(plan))
            {
                return false;
            }
            if (!CoachExists(plan))
            {
                return false;
            }
            return true;
        }
        public static bool ValidateGetWorkouts(string planId)
        {
            if (!PlanExists(planId))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Helper Functions
        private static bool PlanExists(Plan plan)
        {
            return plan.PlanId != null;
        }
        private static bool PlanExists(string planId)
        {
            return planId != null;
        }
        private static bool CoachExists(Plan plan)
        {
            return (plan.CoachId != null) && (plan.CoachId != "");
        }
        #endregion
    }
}

