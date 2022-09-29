using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Infrastructure.Maps;
using ELibrary.Infrastructure.Persistence;
using MediatR;

namespace ELibrary.Application.Books.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Either<BookResponse, IServiceException>>
    {
        private readonly LibraryContext _context;

        public GetBookByIdHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Either<BookResponse,IServiceException>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null)
            {
                return new NotFoundError();
            }

            return book.ToResponse();
        }
    }
}