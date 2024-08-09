using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBorrowingServices
    {
        public Task<Borrowing_Record> BorrowBook(int bookId, int patronId);
        //public Task<Borrowing_Record> ReturnBook(int bookId, int patronId);

    }
}
