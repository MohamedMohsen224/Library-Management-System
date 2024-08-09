using AutoMapper;
using Core.Entities;
using Core.Services;
using Library_Management_System.Dtos;
using Library_Management_System.HandleErrors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Library_Management_System.Controllers
{
  
    public class PatronController : BaseController
    {
        private readonly IPatronServices patronServices;
        private readonly IMapper mapper;

        public PatronController(IPatronServices patronServices , IMapper mapper)
        {
            this.patronServices = patronServices;
            this.mapper = mapper;
        }

        [HttpGet("books")]
        public async Task<ActionResult<IReadOnlyList<PatronDto>>> GetAllBooks()
        {
            var Patrons = await patronServices.GetAllPatrons();
            var PatronMapp = mapper.Map<IReadOnlyList<Patron>, IReadOnlyList<PatronDto>>(Patrons);

            if (!Patrons.Any())
            {
                return NotFound(new ApiErrorResponse("No Patrons Found", 404));
            }

            return Ok(PatronMapp);

        }

        //GET/api/books/{id}
        [HttpGet("books/Id")]
        public async Task<ActionResult<PatronDto>> GetBookById(int PatronId)
        {
            var Patron = await patronServices.GetPatronById(PatronId);
            var MappedPatron = mapper.Map<Patron, PatronDto>(Patron);
            if (Patron == null)
            {
                return NotFound(new ApiErrorResponse("This Patron is not avalible", 404));
            }
            return Ok(MappedPatron);
        }

        //POST/api/books
        [HttpPost]
        public async Task<ActionResult<PatronDto>> AddBook(PatronDto bookdto)
        {
            var Patrons = mapper.Map<PatronDto, Patron>(bookdto);
            await patronServices.AddPatron(Patrons);
            var mappedPatron = mapper.Map<Patron, PatronDto>(Patrons);
            return Ok(mappedPatron);

        }

        //PUT/api/books
        [HttpPut]
        public async Task<ActionResult> EditBook(Patron PatronDto, int Id)
        {
            if (PatronDto.Id != Id)
                return BadRequest(new ApiErrorResponse("Bad Request", 500));
            var Patron = await patronServices.GetPatronById(Id);
            if (Patron == null)
                return NotFound(new ApiErrorResponse("This Book Not Found", 404));
            var Result = patronServices.UpdatePatron(Patron);
            if (Result == null)
                return BadRequest(new ApiErrorResponse("Faild to Update the Patron", 500));
            return Ok(Result);

        }

        //Delete/api/books
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(Patron PatronDto, int Id)
        {
            var b = await patronServices.GetPatronById(Id);
            if (b != null)
                await patronServices.DeletePatron(b);
            return Ok("Patron Deleted Sussefully");

        }
    }
}
