using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Commands;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Errors;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Infrastructure.Mapping;
using ELibrary.Infrastructure.Persistence;
using MediatR;

namespace ELibrary.Application.Handlers
{
    public class
        DeleteBookHandler : IRequestHandler<DeleteBookCommand,
            Either<BookResponse, IServiceException>> // Make it IRequestHandler and return Either
    {
        private readonly LibraryContext _context;

        public DeleteBookHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Either<BookResponse, IServiceException>> Handle(DeleteBookCommand request,
            CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null) return new NotFoundError();

            _context.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);

            return book.ToResponse();
        }
    }
}