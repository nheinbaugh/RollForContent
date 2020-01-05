using RollForContent.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RollForContent.Data.Attribute
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly List<AttributeSelection> attributes;
        public AttributeRepository()
        {
            this.attributes = new List<AttributeSelection> { 
                new AttributeSelection { Id = "1", ParentAttributeId = "name", Value = "Bob" },
                new AttributeSelection { Id = "2", ParentAttributeId = "name", Value = "Dave" },
                new AttributeSelection { Id = "3", ParentAttributeId = "name", Value = "Joe" },
                new AttributeSelection { Id = "4", ParentAttributeId = "name", Value = "Jim" },
                new AttributeSelection { Id = "5", ParentAttributeId = "name", Value = "Sally" },
                new AttributeSelection { Id = "6", ParentAttributeId = "name", Value = "Elizabeth" },
                new AttributeSelection { Id = "7", ParentAttributeId = "name", Value = "Anna" },
                new AttributeSelection { Id = "8", ParentAttributeId = "name", Value = "Taylor" }, 
                new AttributeSelection { Id = "9", ParentAttributeId = "species", Value = "Human" }, 
                new AttributeSelection { Id = "10", ParentAttributeId = "species", Value = "Dwarf" }, 
                new AttributeSelection { Id = "11", ParentAttributeId = "species", Value = "Elf" }, 
                new AttributeSelection { Id = "12", ParentAttributeId = "species", Value = "Goblin" }
            };
        }
        public IEnumerable<AttributeSelection> GetValuesByAttribute(string attributeId)
        {
            return this.attributes.Where(a => a.ParentAttributeId == attributeId);
        }
    }
}
