namespace RollForContent.Data
{
    /// <summary>
    /// Attribute that has an associated selection
    /// </summary>
    public class Attribute : IAttribute
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
