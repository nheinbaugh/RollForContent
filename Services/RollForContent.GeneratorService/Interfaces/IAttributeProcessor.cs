using RollForContent.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollForContent.GeneratorService.Interfaces
{
    public interface IAttributeProcessor
    {
        Task<SelectedAttribute> DetermineValue(RecipeAttribute input, IEnumerable<string> appliedTags);
    }
}
