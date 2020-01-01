using RollForContent.Data;
using RollForContent.GeneratorService.Interfaces;
using System;

namespace RollForContent.GeneratorService
{
    public class RecipeResolver
    {
        private readonly INumericalAttributeProcessor numericalProcessor;

        public RecipeResolver()
        {
            this.numericalProcessor = new NumericalAttributeProcessor();
        }

        public UserContent GenerateContent(Recipe input)
        {
            var content = new UserContent();
            foreach (var attr in input.NumericalAttributes)
            {
                var result = this.numericalProcessor.DetermineValue(attr);
            }
            return content;
        }
    }
}
