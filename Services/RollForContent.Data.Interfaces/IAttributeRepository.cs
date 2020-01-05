using System.Collections.Generic;

namespace RollForContent.Data.Interfaces
{
    public interface IAttributeRepository
    {
        IEnumerable<AttributeSelection> GetValuesByAttribute(string attributeId);
    }
}
