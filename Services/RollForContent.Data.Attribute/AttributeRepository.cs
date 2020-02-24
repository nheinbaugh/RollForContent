using RollForContent.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollForContent.Data.Attribute
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly List<AttributeSelection> attributes;
        public AttributeRepository()
        {
            this.attributes = new List<AttributeSelection> { 
                new AttributeSelection { Id = "1", ParentAttributeId = "first-name", Value = "Bob", RelatedTags = new List<string> { "male" } },
                new AttributeSelection { Id = "2", ParentAttributeId = "first-name", Value = "Dave", RelatedTags = new List<string> { "male" } },
                new AttributeSelection { Id = "3", ParentAttributeId = "first-name", Value = "Joe", RelatedTags = new List<string> { "male" } },
                new AttributeSelection { Id = "4", ParentAttributeId = "first-name", Value = "Jim", RelatedTags = new List<string> { "male" } },
                new AttributeSelection { Id = "5", ParentAttributeId = "first-name", Value = "Sally", RelatedTags = new List<string> { "female" } },
                new AttributeSelection { Id = "6", ParentAttributeId = "first-name", Value = "Elizabeth", RelatedTags = new List<string> { "female" } },
                new AttributeSelection { Id = "7", ParentAttributeId = "first-name", Value = "Anna", RelatedTags = new List<string> { "female" } },
                new AttributeSelection { Id = "8", ParentAttributeId = "first-name", Value = "Taylor", RelatedTags = new List<string> { "female", "male", "non-binary" } }, 
                new AttributeSelection { Id = "8", ParentAttributeId = "first-name", Value = "Horbek", RelatedTags = new List<string> { "dwarf", "male" } },
                new AttributeSelection { Id = "8", ParentAttributeId = "first-name", Value = "Gimli", RelatedTags = new List<string> { "dwarf", "male" } },
                new AttributeSelection { Id = "8", ParentAttributeId = "first-name", Value = "Gloin", RelatedTags = new List<string> { "dwarf", "male" } },
                new AttributeSelection { Id = "8", ParentAttributeId = "first-name", Value = "Oin", RelatedTags = new List<string> { "dwarf", "male" } },
                new AttributeSelection { Id = "9", ParentAttributeId = "species", Value = "Human" }, 
                new AttributeSelection { Id = "10", ParentAttributeId = "species", Value = "Dwarf", RelatedTags = new List<string> { "dwarf" } }, 
                new AttributeSelection { Id = "11", ParentAttributeId = "species", Value = "Elf" }, 
                new AttributeSelection { Id = "12", ParentAttributeId = "species", Value = "Goblin" },
                new AttributeSelection { Id = "13", ParentAttributeId = "gender", Value = "Male" },
                new AttributeSelection { Id = "14", ParentAttributeId = "gender", Value = "Female" },
                new AttributeSelection { Id = "15", ParentAttributeId = "gender", Value = "Non-Binary" },
            };
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IEnumerable<AttributeSelection>> GetValuesByAttribute(string attributeId)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return this.attributes.Where(a => a.ParentAttributeId == attributeId);
        }

        public async Task<IEnumerable<AttributeSelection>> GetValuesByAttribute(string attributeId, IEnumerable<string> appliedTags)
        {
            var attributeValues = (await this.GetValuesByAttribute(attributeId));
            if (appliedTags.Any())
            {
                // THIS NEED TO BE CASE INSENSITIVE!!!!
                attributeValues = attributeValues.Where(a => a.RelatedTags.Intersect(appliedTags).Any());
            }
            return attributeValues;
        }
    }
}
