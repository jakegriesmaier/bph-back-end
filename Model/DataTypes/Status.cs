using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DataTypes
{
    public enum Status
    {
        Draft,          //only coach can see
        Created,        //trainee and coach can see
        InProgress,     //trainee and coach can see 
        Completed       //trainee and coach will see.
    } 
}
