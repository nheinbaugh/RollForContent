using System;

namespace RollForContent.Data
{
    public interface ISelectedAttribute
    {
        string Name { get; set; }

        string Value { get; set; }
    }
    /// <summary>
    /// Attribute that has an associated selection
    /// </summary>
    public class SelectedAttribute : ISelectedAttribute
    {
        public SelectedAttribute()
        {
            this.Id = Guid.NewGuid().ToString();
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
