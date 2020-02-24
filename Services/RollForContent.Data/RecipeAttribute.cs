using System.Collections.Generic;

namespace RollForContent.Data
{
    /// <summary>
    /// Description of a single facet of the recipe
    /// </summary>
    public class RecipeAttribute : IAttribute
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public AffinityList AffinityList { get; set; }

        /// <summary>
        /// The list of attributes that must be populated before this attribute can be set
        /// </summary>
        public ICollection<string> DependentAttributes { get; set; } = new List<string>();
    }
}
