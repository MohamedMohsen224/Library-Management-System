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
    public class BorrowingRecord : IBorrowingServices
    {
        private readonly IUnitOfWork unitOfWork;

        public BorrowingRecord(IUnitOfWork unitOfWork )
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Borrowing_Record> BorrowBook(int bookId, int patronId)
        {
            var book = await unitOfWork.Repository<Book>().GetByIdAsync(bookId);
            var patron = await unitOfWork.Repository<Patron>().GetByIdAsync(patronId);

            if (book == null || patron == null || book.IsAvailable == false)
            {
                throw new Exception("No Borrowing");
            }
            var borrowingRecord = new Borrowing_Record
            {
                BookId = bookId,
                PatronId = patronId,
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.UtcNow.AddDays(14)
                
            };

            await unitOfWork.Repository<Borrowing_Record>().AddAsync(borrowingRecord);
            return borrowingRecord;
        }


       
        //===============================
        private async Task<bool> UpdateBookAvailabilityAsync(int bookId, bool isAvailable)
        {
            var book = await unitOfWork.Repository<Book>().GetByIdAsync(bookId);
            if (book == null)
            {
                // Handle book not found
                return false;
            }

            book.IsAvailable = isAvailable;
            unitOfWork.Repository<Book>().UpdateAsync(book);
            return true;
        }




    }
}
