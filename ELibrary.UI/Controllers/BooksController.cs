
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ELibrary.Application.Commands;
using ELibrary.Application.Queries;
using ELibrary.Application.Contracts.Requests;
using ELibrary.Application.Contracts.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.UI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponse>>> Get()
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
            
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetById(long id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query); // Cancellation Token can be used
            return result != null ? Ok(result) : NotFound();
        }

       [HttpPost]
        public async Task<ActionResult<BookResponse>> Create([FromBody] BookRequest bookRequest) // 
        {
            var query = new CreateBookCommand(bookRequest);
            var result = await _mediator.Send(query);
            return CreatedAtAction(nameof(GetById), new {bookId = result.Id}, result);
        }

        [HttpPut]
        public IActionResult Update(int id, BookRequest book)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult Patch(BookRequest bookRequest)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Remove()
        {
            throw new NotImplementedException();
        }
        
    }
}