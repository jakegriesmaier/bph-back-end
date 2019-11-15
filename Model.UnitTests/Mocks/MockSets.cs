using System;
using Model.Entities;

namespace Model.UnitTests.Mocks
{
    public class MockSets
    {
        public static Set GetSet(string id)
        {
            if (id == Set1().SetId)
            {
                return Set1();
            }
            return new Set();
        }

        public static Set Set1()
        {
            return new Set
            {
                SetId = "pizza_party1",
                Order = 0,
                TargetRPE = 9.5,
                ActualRPE = null,
                TargetReps = 1,
                ActualReps = null,
            };
        }
    }
}
