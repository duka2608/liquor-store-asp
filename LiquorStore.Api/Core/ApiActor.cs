using LiquorStore.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquorStore.Api.Core
{
    public class ApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "Fake user";

        public IEnumerable<int> AllowedUseCases => new List<int> { 15 };
    }

    public class FakeAdminActor : IApplicationActor
    {
        public int Id => 2;
        public string Identity => "Fake admin";
        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 1000);
    }
}
