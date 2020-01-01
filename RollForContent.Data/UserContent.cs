using System.Collections.Generic;

namespace RollForContent.Data
{
    public class UserContent : IBaseEntity
    {
        public string Id { get; set; }

        /// <summary>
        /// The ID of the <see cref="Recipe"/> that was used to generate the content
        /// </summary>
        public string SourceRecipeId { get; set; }

        public string RecipeName { get; set; }

        public IList<Attribute> Attributes { get; set; }
    }
}
