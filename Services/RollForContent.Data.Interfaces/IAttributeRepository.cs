using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollForContent.Data.Interfaces
{
    public interface IAttributeRepository
    {
        Task<IEnumerable<AttributeSelection>> GetValuesByAttribute(string attributeId);
        Task<IEnumerable<AttributeSelection>> GetValuesByAttribute(string attributeId, IEnumerable<string> appliedTags);
    }
}
