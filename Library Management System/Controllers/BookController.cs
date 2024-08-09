using AutoMapper;
using Core.Entities;
using Core.Services;
using Library_Management_System.Dtos;
using Library_Management_System.HandleErrors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    
    public class BookController : BaseController
    {
        private readonly IBookServices bookServices;
        private readonly IMapper mapper;

        public BookController(IBookServices bookServices , IMapper mapper)
        {
            this.bookServices = bookServices;
            this.mapper = mapper;
        }

        //GET/api/books
        [HttpGet("books")]
        public async Task<ActionResult<IReadOnlyList<BookDto>>> GetAllBooks()
        {
            var Books = await bookServices.GetAllBooks();
            var bookMapp = mapper.Map<IReadOnlyList<Book>, IReadOnlyList<BookDto>>(Books);

            if (!Books.Any())
            {
                return NotFound(new ApiErrorResponse("No Books Found", 404));
            }

            return Ok(bookMapp);
            
        }

        //GET/api/books/{id}
        [HttpGet("books/Id")]
        public async Task<ActionResult<BookDto>> GetBookById(int BookId)
        {
            var book = await bookServices.GetBookById(BookId);
            var MappedBook = mapper.Map<Book , BookDto>(book);
            if(book == null)
            {
                return NotFound(new ApiErrorResponse("This Book is not avalible", 404));
            }
            return Ok(MappedBook);
        }

        //POST/api/books
        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBook(BookDto bookdto)
        {
            var Book = mapper.Map<BookDto, Book>(bookdto);
            await bookServices.AddBook(Book);
            var mappedbook = mapper.Map<Book, BookDto>(Book);
            return Ok(mappedbook);

        }

        //PUT/api/books
        [HttpPut]
        public async Task<ActionResult> EditBook(Book bookDto ,int Id)
        {
            if (bookDto.Id != Id)
                return BadRequest(new ApiErrorResponse("Bad Request",500));
            var book = await bookServices.GetBookById(Id);
            if (book == null)
                return NotFound(new ApiErrorResponse("This Book Not Found", 404));
            var Result = bookServices.UpdateBook(book);
            if (Result == null)
                return BadRequest(new ApiErrorResponse( "Faild to Update the Book",500));
            return Ok(Result);

        }

        //Delete/api/books
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(BookDto bookDto ,int Id)
        {
            var b = await bookServices.GetBookById(Id);
            if (b != null)
                await bookServices.DeleteBook(b);
            return Ok("Book Deleted Sussefully");

        }


    }
}
