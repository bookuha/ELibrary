using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Domain.Entities;
using MediatR;

namespace ELibrary.Application.Queries
{
    public class GetBookByIdQuery : IRequest<Either<BookResponse,IServiceException>>
    {
        public long BookId { get; }
        
        public GetBookByIdQuery(long bookId)
        {
            BookId = bookId;
        } 
    }
}