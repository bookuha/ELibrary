using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Contracts.Common;
using ELibrary.Domain.Entities;
using ELibrary.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Application.Books.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Result<long>>
    {
        private readonly LibraryContext _context;

        public CreateBookHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Result<long>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Name = request.Name,
                Genres = request.Genres,
                BriefDescription = request.BriefDescription,
                FullDescription = request.FullDescription,
                OriginallyPublishedAt = request.OriginallyPublishedAt,
                Authors = await _context.Authors.Where(a => request.AuthorIds.Contains(a.Id))
                    .ToListAsync(cancellationToken),
                DownloadableFiles = await _context.Files.Where(f => request.FileIds.Contains(f.Id))
                    .ToListAsync(cancellationToken)
            };

            _context.Books.Add(book);

            await _context.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}