using Core.Reposatries;
using Microsoft.EntityFrameworkCore;
using Reposiatry.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiatry.Reposatry
{
    public class GenaricReposatry<T> : IGenaricReposatry<T> where T : class
    {
        private readonly LibraryDbContext context;

        public GenaricReposatry(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        => await context.AddAsync(entity);

        public void DeleteAsync(T entity)
        =>  context.Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync();
        }

        public  void UpdateAsync(T entity)
        =>  context.Update(entity);
    }
}
