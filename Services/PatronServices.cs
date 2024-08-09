using Core.Entities;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PatronServices : IPatronServices
    {
        private readonly IUnitOfWork unitOfWork;

        public PatronServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task AddPatron(Patron patron)
        {
            await unitOfWork.Repository<Patron>().AddAsync(patron);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeletePatron(Patron patron)
        {
            
                 unitOfWork.Repository<Patron>().DeleteAsync(patron);
                await unitOfWork.CompleteAsync();

            
        }

        public async Task<IReadOnlyList<Patron>> GetAllPatrons()
        {
           var patrons = await unitOfWork.Repository<Patron>().GetAllAsync();
            return patrons;
        }

        public async Task<Patron> GetPatronById(int id)
        {
            var Patron =  await unitOfWork.Repository<Patron>().GetByIdAsync(id);
            if(Patron != null)
            {
                return Patron;
            }
            throw new Exception("Patron Not found");
            
        }

        public async Task UpdatePatron(Patron patron)
        {
            
                unitOfWork.Repository<Patron>().UpdateAsync(patron);
                await unitOfWork.CompleteAsync();
            
            
        }
    }
}
