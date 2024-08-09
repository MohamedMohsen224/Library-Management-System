using Core.Reposatries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenaricReposatry<T> Repository<T>() where T : class;

        Task<int> CompleteAsync();
    }
}
