using Model.DataAccess;
using Model.DataAccess.BaseAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UnitTests.Mocks
{
    public class MockDataAccessLocator : DataAccessLocatorBase
    {
        public override UserDataAccessorBase GetUserDataAccessorCore()
        {
            throw new NotImplementedException();
        }
    }
}
