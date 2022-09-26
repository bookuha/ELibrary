
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ELibrary.Application.Commands;
using ELibrary.Application.Queries;
using ELibrary.Application.Contracts.Requests;
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
            
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetById(long id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query); // Cancellation Token can be used
            return result.Match(
                response => Ok(response),  
                error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage));
        }

       [HttpPost]
        public async Task<ActionResult<BookResponse>> Create([FromBody] BookRequest bookRequest) 
        {
            var query = new CreateBookCommand(bookRequest);
            var result = await _mediator.Send(query);
            return result.Match(
                response => CreatedAtAction(nameof(Create), new {bookId = response.Id}, response),
                error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage));
        }

        [HttpPut]
        public async Task<ActionResult<BookResponse>> Update(int id, BookRequest bookRequest)
        {
            var query = new UpdateBookCommand(id, bookRequest);
            var result = await _mediator.Send(query);
            return result.Match(
                response=>Ok(response),
                error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage));
        }

        [HttpDelete]
        public async Task<ActionResult> Remove(long id)
        {
            var query = new DeleteBookCommand(id);
            var result = await _mediator.Send(query);
            return result.Match(
                response=>Ok(response),
                error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage));
        }
        
    }
}