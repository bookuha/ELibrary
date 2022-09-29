using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Commands;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Domain.Entities;
using ELibrary.Infrastructure.Persistence;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Infrastructure.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Application.Handlers
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand,Either<BookResponse,IServiceException>>
    {
        private readonly LibraryContext _context;

        public CreateBookHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Either<BookResponse, IServiceException>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.Book.ToEntity();

            book.Authors = await _context.Authors.Where(a => request.Book.AuthorIds.Contains(a.Id))
                .ToListAsync(cancellationToken);
            book.DownloadableFiles = await _context.Files.Where(f => request.Book.FileIds.Contains(f.Id))
                .ToListAsync(cancellationToken);
            
            _context.Books.Add(book);
            
            await _context.SaveChangesAsync(cancellationToken);
            return book.ToResponse();

        }
    }
}