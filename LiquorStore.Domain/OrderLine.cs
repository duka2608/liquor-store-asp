using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Domain
{
    public class OrderLine : Entity
    {
        public string LiquorName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? LiquorId { get; set; }
        public int OrderId { get; set; }

        public virtual Liquor Liquor { get; set; }
        public virtual Order Order { get; set; }
    }
}
