using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TransientExecutor.Business.Interface;

namespace TransientExecutor.Business
{
    public class TransientService : ITransientService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TransientService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void ExecuteTransientService<T>(Func<T, Task> worker)
        {
            Task.Run(async () =>
            {
                try
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    var repository = scope.ServiceProvider.GetRequiredService<T>();
                    await worker(repository);
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }
    }
}
