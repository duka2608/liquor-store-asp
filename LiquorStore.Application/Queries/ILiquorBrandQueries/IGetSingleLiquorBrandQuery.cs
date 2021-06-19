using LiquorStore.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application.Queries.ILiquorBrandQueries
{
    public interface IGetSingleLiquorBrandQuery : IQuery<int, LiquorBrandDto>
    {
    }
}
