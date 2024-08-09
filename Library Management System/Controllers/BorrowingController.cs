using AutoMapper;
using Core.Entities;
using Core.Services;
using Library_Management_System.Dtos;
using Library_Management_System.HandleErrors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
   
    public class BorrowingController : BaseController
    {
        private readonly IBorrowingServices borrowingServices;
        private readonly IMapper mapper;

        public BorrowingController(IBorrowingServices borrowingServices ,IMapper mapper)
        {
            this.borrowingServices = borrowingServices;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Bororowingdto>> AddBorrowingRecord(int PatronId ,int BookId)
        {
            if (PatronId == 0 || BookId == 0)
                return BadRequest(new ApiErrorResponse("No borrowing ",404));

            var Result = await borrowingServices.BorrowBook(PatronId, BookId);
            if(Result == null)
                return BadRequest(new ApiErrorResponse("No borrowing ", 404));

            return Ok(Result);
        }


    }
}
