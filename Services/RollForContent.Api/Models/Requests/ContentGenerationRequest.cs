using Newtonsoft.Json;
using System.Collections.Generic;

namespace RollForContent.Models.Requests
{
    /// <summary>
    /// API Request that is used to trigger a recipe generation
    /// </summary>
    public class ContentGenerationRequest
    {
        public ContentGenerationRequest()
        {
            this.AppliedTags = new List<string>();
        }
        public string RecipeName { get; set; }

        /// <summary>
        /// Optional set of tags that can be passed along to further limit the generated content
        /// </summary>
        public List<string> AppliedTags { get; set; }

    }
}