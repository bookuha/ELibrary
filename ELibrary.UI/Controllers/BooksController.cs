using System.Collections.Generic;
using System.Threading.Tasks;
using ELibrary.Application.Books.Commands.CreateBook;
using ELibrary.Application.Books.Commands.DeleteBook;
using ELibrary.Application.Books.Commands.UpdateBook;
using ELibrary.Application.Books.Queries.GetAllBooks;
using ELibrary.Application.Books.Queries.GetBookById;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.UI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BooksController : ApiController
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllBooksQuery();
            Result<List<BookResponse>> result = await _mediator.Send(query);

            if (result.IsFailure) return Problem(result.Errors);

            return Ok(result.Value);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromBody] GetBookByIdQuery query)
        {
            Result<BookResponse> result = await _mediator.Send(query); // Cancellation Token can be used

            if (result.IsFailure) return Problem(result.Errors);

            return Ok(result.Value);
        }

        // POST: api/books
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand query)
        {
            Result<long> result = await _mediator.Send(query); 

            if (result.IsFailure) return Problem(result.Errors);

            return CreatedAtAction(
                nameof(GetById),
                new {id = result.Value},
                result.Value);
        }

        // PUT: api/books/{id}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand query)
        {
            var result = await _mediator.Send(query);

            if (result.IsFailure) return Problem(result.Errors);

            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete]
        public async Task<IActionResult> Remove(DeleteBookCommand query) // From route/query
        {
            var result = await _mediator.Send(query);

            if (result.IsFailure) return Problem(result.Errors);

            return NoContent();
        }
    }
}