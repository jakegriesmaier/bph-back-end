using Model.Entities;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Validators
{
    public class ExerciseValidatorTest
    {

        Exercise filledOutExercise = MockExercises.Exercise1();
        Exercise emptyExercise = new Exercise();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateCreateExercise_HappyPath()
        {
            Assert.AreEqual(true, ExerciseValidator.ValidateCreateExercise(emptyExercise, "20103"), "Marked a good exercise as bad");
        }
        [Test]
        public void ValidateCreateExercise_NullWorkoutId()
        {
            Assert.AreEqual(false, ExerciseValidator.ValidateCreateExercise(filledOutExercise, null), "Marked a bad exercise (no Workout Id) as good");
        }

        [Test]
        public void ValidateCreateExercise_NonNullExerciseId()
        {
            Assert.AreEqual(false, ExerciseValidator.ValidateCreateExercise(filledOutExercise, "2124"), "Marked a bad exercise (Non-null Exercise ID) as good");
        }

        [Test]
        public void ValidateGetExercise_HappyPath()
        {
            Assert.AreEqual(true, ExerciseValidator.ValidateGetExercise(filledOutExercise.ExerciseId), "Marked a good ValidateGetExercise as bad");
        }

        [Test]
        public void ValidateGetExercise_NullExerciseId()
        {
            Assert.AreEqual(false, ExerciseValidator.ValidateGetExercise(null), "Marked a bad exercise (no Workout Id) as good");
        }

        [Test]
        public void ValidateGetSets_HappyPath()
        {
            Assert.AreEqual(true, ExerciseValidator.ValidateGetSets(filledOutExercise.ExerciseId), "Marked a good ValidateGetExercises as bad");
        }

        [Test]
        public void ValidateGetSets_NullExerciseId()
        {
            Assert.AreEqual(false, ExerciseValidator.ValidateGetSets(null), "Validator did not catch Null exercise ID for get exercises");
        }

        [Test]
        public void ValidateDeleteExercise_HappyPath()
        {
            Assert.AreEqual(true, ExerciseValidator.ValidateDeleteExercise(filledOutExercise.ExerciseId), "Marked a good ValidateDeleteExercise as bad");
        }

        [Test]
        public void ValidateDeleteExercise_NullExerciseId()
        {
            Assert.AreEqual(false, ExerciseValidator.ValidateDeleteExercise(null), "Validator did not catch Null exercise id while deleting.");
        }

    }
}

