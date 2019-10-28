using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAuthenticated { get; }
    }
}
