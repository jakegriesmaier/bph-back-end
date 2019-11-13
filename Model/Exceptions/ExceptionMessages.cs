using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Exceptions
{
    public static class ExceptionMessages
    {

        #region User Model
        public static readonly string INVALID_CREATE_ACCOUNT_PARAMS = 
            "Unable to create account. The email or password you entered do not match the required format.";

        public static readonly string INVALID_LOG_IN_PARAMS =
            "Unable to log in. The email or password you entered was incorrect.";

        public static readonly string INVALID_UPDATE_USER_PARAMS = 
            "Unable to update the user. Users email and userId must be specified";

        public static readonly string INVALID_UPDATE_PASSWORD_PARAMS =
            "Unable to update pasword. The password entered did not match the required format.";
        #endregion

        #region Coach Model
        public static readonly string INVALID_CREATE_PLAN_PARAMS = 
            "Unable to create the plan. The planId has to be unset and coach must be specified.";

        public static readonly string INVALID_GET_PLAN_PARAMS = 
            "Unable to get the plan. The planId must be specified.";

        public static readonly string INVALID_UPDATE_PLAN_PARAMS =
            "Unable to update the plan. The planId and coach must be specified.";

        public static readonly string INVALID_CREATE_WORKOUT_PARAMS = 
            "Unable to create the workout. A planId must be specified and the workoutId has to be unset.";

        public static readonly string INVALID_GET_WORKOUT_PARAMS = 
            "Unable to get the workout. The workoutId must be specified.";
        #endregion

    }
}
