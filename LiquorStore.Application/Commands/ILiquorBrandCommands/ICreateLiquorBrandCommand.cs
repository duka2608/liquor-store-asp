using LiquorStore.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application.Commands.ILiquorBrandCommands
{
    public interface ICreateLiquorBrandCommand : ICommand<LiquorBrandDto>
    {
    }
}
