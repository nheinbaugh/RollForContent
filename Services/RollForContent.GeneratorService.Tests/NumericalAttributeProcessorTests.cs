using NUnit.Framework;
using RollForContent.Common;
using RollForContent.Data;
using RollForContent.GeneratorService.Interfaces;

namespace RollForContent.GeneratorService.Tests
{
    [TestFixture]
    public class NumericalAttributeProcessorTests
    {
        INumericalAttributeProcessor instance;

        [OneTimeSetUp]
        public void FixtureSetup()
        {
            var random = new GlobalRandom();
            this.instance = new NumericalAttributeProcessor(random);
        }


        [Test]
        public void NoMinOrMax_ReturnsValueGreaterThanZero_AndLessThanDefaultMax()
        {
            var input = new NumericalAttribute
            {
                MinimumValue = 0,
                MaximumValue = 0
            };
            var result = this.instance.DetermineValue(input);
            var convertedResult = int.Parse(result.Value);
            Assert.GreaterOrEqual(convertedResult, 0);
            Assert.LessOrEqual(convertedResult, 5);
        }

        [TestCase(0, 5)]
        [TestCase(-20, 0)]
        public void ReturnsValueWithinRange(int min, int max)
        {
            var input = new NumericalAttribute
            {
                MinimumValue = min,
                MaximumValue = max
            };
            var result = this.instance.DetermineValue(input);
            var convertedResult = int.Parse(result.Value);
            Assert.GreaterOrEqual(convertedResult, min);
            Assert.LessOrEqual(convertedResult, max);
        }
    }
}
