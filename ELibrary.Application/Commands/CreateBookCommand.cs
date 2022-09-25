using ELibrary.Application.Contracts.Requests;
using ELibrary.Application.Contracts.Responses;
using MediatR;

namespace ELibrary.Application.Commands
{
    public record CreateBookCommand(
        BookRequest Book) : IRequest<BookResponse>;


}