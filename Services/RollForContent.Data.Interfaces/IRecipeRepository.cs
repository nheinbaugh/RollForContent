using System.Threading.Tasks;

namespace RollForContent.Data.Interfaces
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeById(string recipeId);
    }
}
