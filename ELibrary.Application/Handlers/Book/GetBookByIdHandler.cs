using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Errors;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Application.Queries;
using ELibrary.Infrastructure.Mapping;
using ELibrary.Infrastructure.Persistence;
using MediatR;

namespace ELibrary.Application.Handlers.Book
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Either<BookResponse,IServiceException>>
    {
        private readonly LibraryContext _context;

        public GetBookByIdHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Either<BookResponse,IServiceException>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.BookId);
            if (book == null)
            {
                return new NotFoundError();
            }

            return book.ToResponse();
        }
    }
}