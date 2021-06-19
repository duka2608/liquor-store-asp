using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Domain
{
    public class Order : Entity
    {
        public string Address { get; set; }
        public int? CustormerId { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
        public virtual User User { get; set; }
    }
}
