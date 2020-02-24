using RollForContent.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollForContent.Data.Recipes
{
    public class RecipeRepository: IRecipeRepository
    {
        private readonly List<Recipe> recipes;

        public RecipeRepository()
        {
            this.recipes = new List<Recipe>
            {
                new Recipe
                {
                    Id = "person",
                    Attributes = new List<RecipeAttribute>
                    {
                        new RecipeAttribute
                        {
                            Id = "first-name",
                            Name = "Name",
                        },
                        new RecipeAttribute
                        {
                            Id = "species",
                            Name = "Species",
                        }
                    }
                },
                new Recipe
                {
                    Id = "place",
                    Attributes = new List<RecipeAttribute>
                    {
                        new RecipeAttribute
                        {
                            Id = "name",
                            Name = "Name",
                        }
                    }
                }
            };
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<Recipe> GetRecipeById(string recipeId)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var result = this.recipes.FirstOrDefault(r => r.Id == recipeId);
            if (result == null)
            {
                throw new Exception($"No recipe with this ID: {recipeId}");
            }
            return result;
        }
    }
}
