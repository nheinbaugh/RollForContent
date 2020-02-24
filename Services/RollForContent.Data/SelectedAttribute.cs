using System;

namespace RollForContent.Data
{
    public interface ISelectedAttribute
    {
        /// <summary>
        /// The ID that is associated with the generating attribute in the database
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The friendly name for the attribute 
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The value that was selected and applied to a given piece of content
        /// </summary>
        string Value { get; set; }
    }
    /// <summary>
    /// Attribute that has an associated selection
    /// </summary>
    public class SelectedAttribute : ISelectedAttribute
    {
        public SelectedAttribute()
        {
        }

        /// <summary>
        /// Generate an attribute with a selected value
        /// </summary>
        /// <param name="attributeName">Name to assign to the attribute</param>
        /// <param name="value">The stringified value to assign to the attribute</param>
        public SelectedAttribute(string attributeName, string value) : this()
        {
            this.Name = attributeName;
            this.Value = value;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
