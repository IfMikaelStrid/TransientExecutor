using System;
using System.Threading.Tasks;

namespace TransientExecutor.Business.Interface
{
    public interface ITransientService
    {
        void ExecuteTransientService<T>(Func<T, Task> worker);
    }
}