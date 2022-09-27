using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Responses;
using MediatR;

namespace ELibrary.Application.Queries
{
    public class GetBookByIdQuery : IRequest<Either<BookResponse, IServiceException>>
    {
        public GetBookByIdQuery(long bookId)
        {
            BookId = bookId;
        }

        public long BookId { get; }
    }
}