using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Domain
{
    public class Liquor : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int TypeId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual LiquorType Type { get; set; }
        public virtual ICollection<LiquorSizes> LiquorSizes { get; set; } = new HashSet<LiquorSizes>();
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
    }
}
