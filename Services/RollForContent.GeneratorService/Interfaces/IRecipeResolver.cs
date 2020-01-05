using RollForContent.Data;

namespace RollForContent.GeneratorService
{
    public interface IRecipeResolver
    {
        UserContent GenerateContent(Recipe input);
    }
}