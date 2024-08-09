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
    public class BookServices : IBookServices
    {
        private readonly IUnitOfWork unitOfWork;

        public BookServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //Add
        public async Task AddBook(Book book)
        {
           await unitOfWork.Repository<Book>().AddAsync(book);
            await unitOfWork.CompleteAsync();

        }
        //Delete
        public async Task DeleteBook(Book book)
        {
            unitOfWork.Repository<Book>().DeleteAsync(book);
            await unitOfWork.CompleteAsync();
        }
        //GET All
        public async Task<IReadOnlyList<Book>> GetAllBooks()
        {
           var Books = await unitOfWork.Repository<Book>().GetAllAsync();
            return Books;
        }
        //Get By Id
        public async Task<Book> GetBookById(int id)
        {
            var Book = await unitOfWork.Repository<Book>().GetByIdAsync(id);
            return Book;
        }
        //UpdateBooks
        public async Task UpdateBook(Book book)
        {
          var boook = unitOfWork.Repository<Book>().GetByIdAsync(book.Id);
            if(boook != null)
            {
                unitOfWork.Repository<Book>().UpdateAsync(book);
                await unitOfWork.CompleteAsync();
            }
            
            
        }


    }
}

