namespace RollForContent.Data
{
    /// <summary>
    /// This describes a facet of a <see cref="Recipe"/> or <see cref="UserContent"/>
    /// </summary>
    public interface IAttribute : IBaseEntity
    {
        string Name { get; set; }
    }
}
