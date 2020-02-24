using RollForContent.Common;
using RollForContent.Data;
using RollForContent.Data.Interfaces;
using RollForContent.GeneratorService.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            var attrsToApply = new Queue<RecipeAttribute>(input.Attributes.ToList());

            while (attrsToApply.Count != 0)
            {
                var attr = attrsToApply.Dequeue();
                var canApplyAttribute = this.CanAttributeBeApplied(attr, content);
                if (!canApplyAttribute)
                {
                    attrsToApply.Enqueue(attr);
                    continue;
                }
                else
                {
                    var valuesOfDependentTags = GetValueOfDependentTags(content, attr);
                    var result = await this.attributeProcessor.DetermineValue(attr, valuesOfDependentTags.Concat(appliedTags));
                    content.Attributes.Add(result);
                }
            }

            foreach (var attr in input.NumericalAttributes)
            {
                var result = this.numericalProcessor.DetermineValue(attr);
                content.Attributes.Add(result);
            }
            return content;
        }

        /// <summary>
        /// Go through and get the values of the tags we need to honor. 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        /// NOTE: THIS CAN BE SMOOSHED WITH THE OTHER CANWEAPPLYATTRIBUTE
        private static List<string> GetValueOfDependentTags(UserContent content, RecipeAttribute attr)
        {
            var valuesOfDependentTags = new List<string>();
            foreach (var dependent in attr.DependentAttributes)
            {
                var selection = content.Attributes.First(a => a.Id == dependent);
                valuesOfDependentTags.Add(selection.Value);
            }

            return valuesOfDependentTags;
        }

        /// <summary>
        /// Check if the current attribute has all required attributes already set. Returns false if the generation for this value needs to be deferred
        /// </summary>
        /// <param name="currentAttribute"></param>
        /// <param name="currentContent"></param>
        /// <returns></returns>
        private bool CanAttributeBeApplied(RecipeAttribute currentAttribute, UserContent currentContent)
        {
            if (currentAttribute.DependentAttributes.Any())
            {
                foreach (var requiredAttribute in currentAttribute.DependentAttributes)
                {
                    if (!currentContent.Attributes.Any(sa => sa.Id == requiredAttribute))
                    {
                        // the attribue we depend on has not yet been filled out. Defer it.
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<UserContent> GenerateContent(string recipeId, IEnumerable<string> appliedTags)
        {
            var recipe = await this.recipeRepository.GetRecipeById(recipeId);
            return await this.GenerateContent(recipe, appliedTags);
        }
    }
}
