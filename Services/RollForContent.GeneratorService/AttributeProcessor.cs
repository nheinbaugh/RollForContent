using RollForContent.Common;
using RollForContent.Data;
using RollForContent.Data.Interfaces;
using RollForContent.GeneratorService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollForContent.GeneratorService
{
    public class AttributeProcessor : IAttributeProcessor
    {
        private readonly IAttributeRepository attributeRepo;
        private readonly GlobalRandom random;

        public AttributeProcessor(IAttributeRepository _attributeRepo, GlobalRandom _random)
        {
            this.attributeRepo = _attributeRepo;
            this.random = _random;
        }

        public async Task<SelectedAttribute> DetermineValue(RecipeAttribute input, IEnumerable<string> appliedTags)
        {
            var values = await this.attributeRepo.GetValuesByAttribute(input.Id, appliedTags);

            // make sure to honor the traits selected in the recipe (not impelemented yet)
            var possibleValues = values.ToList();


            var selection = possibleValues[this.random.Instance.Next(possibleValues.Count)];

            // pull to some factory probably
            return new SelectedAttribute
            {
                Id = Guid.NewGuid().ToString(),
                Name = input.Name,
                Value = selection.Value
            };
        }
    }
}
