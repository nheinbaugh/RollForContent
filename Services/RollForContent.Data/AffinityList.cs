using System.Collections.Generic;

namespace RollForContent.Data
{
    /// <summary>
    /// Description of how an attribute works with traits. For example a name may be limited to a culture group
    /// </summary>
    public class AffinityList
    {
        /// <summary>
        /// Should the attribute allow a value with no traits assigned to it
        /// </summary>
        public bool RequiresUnmarkedValues { get; set; }

        /// <summary>
        /// Should the list be restricted to only items explicity listed 
        /// </summary>
        public bool RestrictToList { get; set; }

        /// <summary>
        /// List of all traits that have a specific affinity with the parent attribute. It 
        /// </summary>
        public IDictionary<string, double> Affinities { get; set; }
    }
}
