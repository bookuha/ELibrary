using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Responses;
using MediatR;

namespace ELibrary.Application.Books.Commands.DeleteBook
{
    public record DeleteBookCommand(
        long Id) : IRequest<Result<BookResponse>>;
}