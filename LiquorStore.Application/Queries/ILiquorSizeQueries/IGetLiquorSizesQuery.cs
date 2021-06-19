using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application.Queries.ILiquorSizeQueries
{
    public interface IGetLiquorSizesQuery : IQuery<LiquorSizeSearch, PagedResponse<LiquorSizeDto>>
    {
    }
}
