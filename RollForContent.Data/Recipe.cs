using System.Collections.Generic;

namespace RollForContent.Data
{
    public class Recipe : IBaseEntity
    {
        public string Id { get; set; }

        public string RecipeName { get; set; }

        public IList<RecipeAttribute> Attributes { get; set; }

        /// <summary>
        /// List of all attributes that are based on a number scale
        /// </summary>
        public IList<NumericalAttribute> NumericalAttributes { get; set; }
    }
}
