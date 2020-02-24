using RollForContent.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollForContent.GeneratorService
{
    public interface IRecipeResolver
    {
        Task<UserContent> GenerateContent(Recipe input, IEnumerable<string> appliedTags);
        Task<UserContent> GenerateContent(string recipeId, IEnumerable<string> appliedTags);
    }
}