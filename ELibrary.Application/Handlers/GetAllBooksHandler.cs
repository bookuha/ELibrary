using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Application.Queries;
using ELibrary.Infrastructure.Mapping;
using ELibrary.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Application.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, Either<List<BookResponse>, IServiceException>>

    {
        private readonly LibraryContext _context;

        public GetAllBooksHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Either<List<BookResponse>, IServiceException>> Handle(GetAllBooksQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Books.Select(b => b.ToResponse()).ToListAsync(cancellationToken);
        }
    }
}