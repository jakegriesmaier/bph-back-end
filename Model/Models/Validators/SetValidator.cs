using Model.Entities;

namespace Model.Models.Validators
{
    public class SetValidator
    {
        public static bool ValidateCreateSet(Set set, string exerciseId)
        {
            if (set.SetId != null || exerciseId == null)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateGetSet(string setId)
        {
            if (setId == null)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUpdateSet(Set set)
        {
            if (set.SetId == null)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDeleteSet(string setId)
        {
            if (setId == null)
            {
                return false;
            }
            return true;
        }

    }
}
