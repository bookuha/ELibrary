using ELibrary.Domain.Entities;
using MediatR;

namespace ELibrary.Application.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public long BookId { get; }
        
        public GetBookByIdQuery(long bookId)
        {
            BookId = bookId;
        } 
    }
}