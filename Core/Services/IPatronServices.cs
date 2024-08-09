using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPatronServices
    {
        Task<IReadOnlyList<Patron>> GetAllPatrons();
        Task<Patron> GetPatronById(int id);
        Task AddPatron(Patron patron);
        Task UpdatePatron(Patron patron);
        Task DeletePatron(Patron patron);
    }
}
