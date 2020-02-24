using RollForContent.Common;
using RollForContent.Data;
using RollForContent.Data.Interfaces;
using RollForContent.GeneratorService.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollForContent.GeneratorService
{
    public class RecipeResolver : IRecipeResolver
    {
        private readonly INumericalAttributeProcessor numericalProcessor;
        private readonly IAttributeProcessor attributeProcessor;
        private readonly IRecipeRepository recipeRepository;

        public RecipeResolver(INumericalAttributeProcessor _numericalProcessor, IAttributeProcessor _attributeProcessor, IRecipeRepository _recipeRepository)
        {
            this.numericalProcessor = _numericalProcessor;
            this.attributeProcessor = _attributeProcessor;
            this.recipeRepository = _recipeRepository;
        }

        public async Task<UserContent> GenerateContent(Recipe input, IEnumerable<string> appliedTags)
        {
            var content = new UserContent
            {
                Id = Guid.NewGuid().ToString(),
                RecipeName = input.RecipeName,
                SourceRecipeId = input.Id
            };
            
            foreach (var attr in input.Attributes)
            {
                var result = await this.attributeProcessor.DetermineValue(attr, appliedTags);
                content.Attributes.Add(result);
            }
            foreach (var attr in input.NumericalAttributes)
            {
                var result = this.numericalProcessor.DetermineValue(attr);
                content.Attributes.Add(result);
            }
            return content;
        }

        public async Task<UserContent> GenerateContent(string recipeId, IEnumerable<string> appliedTags)
        {
            var recipe = await this.recipeRepository.GetRecipeById(recipeId);
            return await this.GenerateContent(recipe, appliedTags);
        }
    }
}
