using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Requests;
using ELibrary.Application.Contracts.Responses;
using MediatR;

namespace ELibrary.Application.Commands.Book
{
    public record UpdateBookCommand(
        long Id,
        BookRequest BookRequest) : IRequest<Either<BookResponse, IServiceException>>;

}