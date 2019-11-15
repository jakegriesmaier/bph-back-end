using Model.Entities;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Validators
{
    public class SetValidatorTest
    {

        Set filledOutSet = MockSets.Set1();
        Set emptySet = new Set();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateCreateSet_HappyPath()
        {
            Assert.AreEqual(true, SetValidator.ValidateCreateSet(emptySet, "20103"), "Marked a good set as bad");
        }
        [Test]
        public void ValidateCreateSet_NullExerciseId()
        {
            Assert.AreEqual(false, SetValidator.ValidateCreateSet(filledOutSet, null), "Marked a bad set (no Exercise Id) as good");
        }

        [Test]
        public void ValidateCreateSet_NonNullSetId()
        {
            Assert.AreEqual(false, SetValidator.ValidateCreateSet(filledOutSet, "2124"), "Marked a bad set (Non-null Set ID) as good");
        }

        [Test]
        public void ValidateGetSet_HappyPath()
        {
            Assert.AreEqual(true, SetValidator.ValidateGetSet(filledOutSet.SetId), "Marked a good ValidateGetSet as bad");
        }

        [Test]
        public void ValidateGetSet_NullSetId()
        {
            Assert.AreEqual(false, SetValidator.ValidateGetSet(null), "Marked a bad set (no set Id) as good");
        }

        [Test]
        public void ValidateDeleteSet_HappyPath()
        {
            Assert.AreEqual(true, SetValidator.ValidateDeleteSet(filledOutSet.SetId), "Marked a good ValidateDeleteSet as bad");
        }

        [Test]
        public void ValidateDeleteSet_NullSetId()
        {
            Assert.AreEqual(false, SetValidator.ValidateDeleteSet(null), "Validator did not catch Null set id while deleting.");
        }

    }
}
