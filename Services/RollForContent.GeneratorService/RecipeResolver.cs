using RollForContent.Common;
using RollForContent.Data;
using RollForContent.GeneratorService.Interfaces;
using System;

namespace RollForContent.GeneratorService
{
    public class RecipeResolver
    {
        private readonly INumericalAttributeProcessor numericalProcessor;
        private readonly IAttributeProcessor attributeProcessor;

        public RecipeResolver(INumericalAttributeProcessor _numericalProcessor, IAttributeProcessor _attributeProcessor)
        {
            this.numericalProcessor = _numericalProcessor;
            this.attributeProcessor = _attributeProcessor;
        }

        public UserContent GenerateContent(Recipe input)
        {
            var content = new UserContent();
            foreach (var  attr in input.Attributes)
            {
                var result = this.attributeProcessor.DetermineValue(attr);
                content.Attributes.Add(result);
            }
            foreach (var attr in input.NumericalAttributes)
            {
                var result = this.numericalProcessor.DetermineValue(attr);
                content.Attributes.Add(result);
            }
            return content;
        }
    }
}
