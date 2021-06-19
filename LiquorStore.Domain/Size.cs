using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Domain
{
    public class Size : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<LiquorSizes> LiquorSizes { get; set; } = new HashSet<LiquorSizes>();
    }
}
