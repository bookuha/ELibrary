using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Queries;
using ELibrary.Domain.Entities;
using ELibrary.Infrastructure.Persistence;
using MediatR;

namespace ELibrary.Application.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly LibraryContext _context;

        public GetBookByIdHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.FindAsync(request.BookId);
        }
    }
}