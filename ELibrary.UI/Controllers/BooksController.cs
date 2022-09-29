using System.Collections.Generic;
using System.Threading.Tasks;
using ELibrary.Application.Books.Commands.CreateBook;
using ELibrary.Application.Books.Commands.DeleteBook;
using ELibrary.Application.Books.Commands.UpdateBook;
using ELibrary.Application.Books.Queries.GetAllBooks;
using ELibrary.Application.Books.Queries.GetBookById;
using ELibrary.Application.Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.UI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponse>>> Get() 
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return result.Match(
                response => Ok(response),
                error => Problem(statusCode: (int) error.StatusCode, title: error.ErrorMessage));
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetById([FromBody] GetBookByIdQuery query)
        {
            var result = await _mediator.Send(query); // Cancellation Token can be used
            return result.Match(
                response => Ok(response),
                error => Problem(statusCode: (int) error.StatusCode, title: error.ErrorMessage));
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookResponse>> Create([FromBody] CreateBookCommand query)
        {
            var result = await _mediator.Send(query);
            return result.Match(
                response => CreatedAtAction(nameof(Create), new {bookId = response.Id}, response),
                error => Problem(statusCode: (int) error.StatusCode, title: error.ErrorMessage));
        }

        // PUT: api/books/{id}
        [HttpPut]
        public async Task<ActionResult<BookResponse>> Update([FromBody] UpdateBookCommand query)
        {
            var result = await _mediator.Send(query);
            return result.Match(
                response => Ok(response),
                error => Problem(statusCode: (int) error.StatusCode, title: error.ErrorMessage));
        }

        // DELETE: api/books/{id}
        [HttpDelete]
        public async Task<ActionResult> Remove(DeleteBookCommand query)
        {
            var result = await _mediator.Send(query);
            return result.Match(
                response => Ok(response),
                error => Problem(statusCode: (int) error.StatusCode, title: error.ErrorMessage));
        }
    }
}