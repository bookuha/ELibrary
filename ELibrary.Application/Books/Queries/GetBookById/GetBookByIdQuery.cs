using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Responses;
using MediatR;

namespace ELibrary.Application.Books.Queries.GetBookById
{
    public record GetBookByIdQuery(long Id) : IRequest<Result<BookResponse>>;
}