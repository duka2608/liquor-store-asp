using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application.DataTransfer
{
    public class LiquorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public IEnumerable<LiquorSizeDto> Sizes { get; set; } = new List<LiquorSizeDto>();
    }
}
