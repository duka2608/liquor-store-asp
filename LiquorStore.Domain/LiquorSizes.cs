using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Domain
{
    public class LiquorSizes
    {
        public int SizeId { get; set; }
        public int LiquorId { get; set; }

        public virtual Size Size { get; set; }
        public virtual Liquor Liquor { get; set; }
    }
}
