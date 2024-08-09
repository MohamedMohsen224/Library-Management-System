using Core.Reposatries;
using Core.UnitOfWork;
using Reposiatry.Context;
using Reposiatry.Reposatry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiatry.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext dbContext;
        private Hashtable R;
        public UnitOfWork(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.R = new Hashtable();
        }
        public async Task<int> CompleteAsync()
        =>await dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
        => await dbContext.DisposeAsync();

        public IGenaricReposatry<T> Repository<T>() where T : class
        {
            var Key = typeof(T).Name;
            if(!R.ContainsKey(Key))
            {
                var Reposatry = new GenaricReposatry<T>(dbContext);
                R.Add(Key, Reposatry);

            }
            return R[Key] as IGenaricReposatry<T>;

        }
    }
}
