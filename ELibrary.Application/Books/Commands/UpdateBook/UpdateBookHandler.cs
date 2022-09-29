using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Domain.Entities;
using ELibrary.Infrastructure.Maps;
using ELibrary.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Application.Books.Commands.UpdateBook
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

            var book = await _context.Books.FindAsync(request.Id);
            if (book == null) return new NotFoundError();


            book.Name = request.Name;
            book.Genres = request.Genres;
            book.BriefDescription = request.BriefDescription;
            book.FullDescription = request.FullDescription;
            book.OriginallyPublishedAt = request.OriginallyPublishedAt;
            book.Authors = await _context.Authors.Where(author => request.AuthorIds.Contains(author.Id))
                .ToListAsync(cancellationToken);
            book.DownloadableFiles = await _context.Files.Where(file => request.FileIds.Contains(file.Id))
                .ToListAsync(cancellationToken);
            
            
            _context.Books.Update(book); // Acts as upsert if key is missing

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
    }
}