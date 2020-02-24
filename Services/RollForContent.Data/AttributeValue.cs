using System.Collections.Generic;

namespace RollForContent.Data
{
    public class AttributeSelection: IBaseEntity
    {
        public string Id { get; set; }

        /// <summary>
        /// ID of the attribute that this is related to
        /// </summary>
        public string ParentAttributeId { get; set; }

        /// <summary>
        /// The actual Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// List of traits that this value is approve for
        /// </summary>
        /// <remarks>This may (should?) get replaced by a real object that inclues a whitelist/blacklist etc</remarks>
        public IList<string> RelatedTags { get; set; } = new List<string>();
    }
}
