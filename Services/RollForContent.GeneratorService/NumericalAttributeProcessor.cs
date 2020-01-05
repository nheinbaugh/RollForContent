using RollForContent.Common;
using RollForContent.Data;
using RollForContent.GeneratorService.Interfaces;

namespace RollForContent.GeneratorService
{
    public class NumericalAttributeProcessor : INumericalAttributeProcessor
    {
        private readonly GlobalRandom random;

        public NumericalAttributeProcessor(GlobalRandom random)
        {
            this.random = random;
        }

        public ISelectedAttribute DetermineValue(NumericalAttribute input)
        {
            var minValue = input.MinimumValue;
            var maxValue = input.MaximumValue;
            if (minValue == 0 && maxValue == 0)
            {
                maxValue = 5;
            }
            var result = this.random.Instance.Next(minValue, maxValue);
            return new SelectedAttribute(input.Name, result.ToString());
        }
    }
}
