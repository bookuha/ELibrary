using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Infrastructure.Maps;
using ELibrary.Infrastructure.Persistence;
using MediatR;

namespace ELibrary.Application.Books.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Result<BookResponse>>
    {
        private readonly LibraryContext _context;

        public GetBookByIdHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Result<BookResponse>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null) return Error.NullValue;

            return book.ToResponse();
        }
    }
}