namespace RollForContent.Data
{
    /// <summary>
    /// An attribute that is based on a range of numbers as opposed to a string (for example rarity may be on a five star basis)
    /// </summary>
    public class NumericalAttribute : IAttribute
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double MinimumValue { get; set; }

        public double MaximumValue { get; set; }
    }
}
