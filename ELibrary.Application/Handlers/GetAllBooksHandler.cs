using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Queries;
using ELibrary.Domain.Entities;
using ELibrary.Infrastructure.Persistence;
using ELibrary.Application.Contracts.Responses;
using Elibrary.Infrastructure.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Application.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookResponse>>
    {
        private readonly LibraryContext _context;

        public GetAllBooksHandler(LibraryContext context)
        {
            _context = context;
        }
        
        public async Task<List<BookResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.Select(b => b.ToResponse()).ToListAsync(cancellationToken);
        }
    }
}