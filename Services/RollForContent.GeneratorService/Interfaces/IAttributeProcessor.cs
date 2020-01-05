using RollForContent.Data;

namespace RollForContent.GeneratorService.Interfaces
{
    public interface IAttributeProcessor
    {
        SelectedAttribute DetermineValue(RecipeAttribute input);
    }
}
