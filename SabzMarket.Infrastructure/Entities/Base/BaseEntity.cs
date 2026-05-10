using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Entities.Base
{
    public abstract class BaseEntity<T> : IEntity
    {
        public T Id { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {

    }
}
