using System;
using System.Linq;
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
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Application.Handlers.Book
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand,Either<BookResponse, IServiceException>>
    {
        private readonly LibraryContext _context;

        public UpdateBookHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Either<BookResponse, IServiceException>> Handle(UpdateBookCommand request, CancellationToken cancellationToken) 
        {
            if (request.Id != request.BookRequest.Id)
            {
                return new IdMismatchError();
            }
            
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null)
            {
                return new NotFoundError();
            }
            
            book = request.BookRequest.ToEntity();

            book.Authors = await _context.Authors.Where(a => request.BookRequest.AuthorIds.Contains(a.Id))
                .ToListAsync(cancellationToken);
            book.DownloadableFiles = await _context.Files.Where(f => request.BookRequest.FileIds.Contains(f.Id))
                .ToListAsync(cancellationToken);

            
            _context.Books.Update(book);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException) when (!_context.Books.Any(b => b.Id == request.Id))
            {
                throw new Exception("Not found in DbConcurrencyException");
            }

            return book.ToResponse();
        }
        // If the one that exists updated = return nothing. If new created = return 201 CREATED and URL
        // SHOULD RETURN EITHER / FLUENT RESULT IDK
    }
}