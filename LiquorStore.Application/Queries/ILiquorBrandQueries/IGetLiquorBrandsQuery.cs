﻿using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application.Queries.ILiquorBrandQueries
{
    public interface IGetLiquorBrandsQuery : IQuery<LiquorBrandSearch, PagedResponse<LiquorBrandDto>>
    {
    }
}
