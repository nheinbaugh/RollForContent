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
    public class Attribute : ISelectedAttribute
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
