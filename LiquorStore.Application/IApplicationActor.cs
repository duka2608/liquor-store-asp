using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application
{
    public interface IApplicationActor
    {
        int Id { get; } 
        string Identity { get; } // Actor identifikacija
        IEnumerable<int> AllowedUseCases { get; } // niz useCaseId kojima korisnik moze pristupiti
    }
}
