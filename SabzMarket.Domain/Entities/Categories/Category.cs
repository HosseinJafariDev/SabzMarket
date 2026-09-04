using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        private Category()
        {
        }

        public Category(long id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(CategoryMessages.NameRequired);

            Id = id;
            Name = name;
        }
    }
}