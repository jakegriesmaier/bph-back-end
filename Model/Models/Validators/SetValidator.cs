using Model.Entities;

namespace Model.Models.Validators
{
    public class SetValidator
    {
        #region Validators
        public static bool ValidateCreateSet(Set set, string exerciseId)
        {
            if (SetExists(set))
            {
                return false;
            }
            if (!ExerciseExists(exerciseId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateGetSet(string setId)
        {
            if (!SetExists(setId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUpdateSet(Set set)
        {
            if (!SetExists(set))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDeleteSet(string setId)
        {
            if (!SetExists(setId))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Helper Functions
        private static bool SetExists(Set set)
        {
            return (set.SetId != null) && (set.SetId != "");
        }
        private static bool SetExists(string setId)
        {
            return (setId != null) && (setId != "");
        }
        private static bool ExerciseExists(string exerciseId)
        {
            return (exerciseId != null) && (exerciseId != "");
        }
        #endregion

    }
}
