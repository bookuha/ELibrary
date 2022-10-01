using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Infrastructure.Maps;
using ELibrary.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, Result<List<BookResponse>>>

    {
        private readonly LibraryContext _context;

        public GetAllBooksHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Result<List<BookResponse>>> Handle(GetAllBooksQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Books.Select(b => b.ToResponse()).ToListAsync(cancellationToken);
        }
    }
}