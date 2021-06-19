using LiquorStore.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquorStore.Api.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 3;

        public string Identity => "Unauthorized actor";

        public IEnumerable<int> AllowedUseCases => new List<int> { 20 }; // id use case-a koji je zaduzen za registraciju
    }
}
