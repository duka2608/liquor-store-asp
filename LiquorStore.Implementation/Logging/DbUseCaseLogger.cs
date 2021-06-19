using LiquorStore.Application;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Logging
{
    public class DbUseCaseLogger : IUseCaseLogger
    {
        private readonly LiquorStoreContext _context;

        public DbUseCaseLogger(LiquorStoreContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            var log = new UseCaseLog
            {
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                Data = JsonConvert.SerializeObject(useCaseData),
                Actor = actor.Identity
            };

            _context.UseCaseLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
