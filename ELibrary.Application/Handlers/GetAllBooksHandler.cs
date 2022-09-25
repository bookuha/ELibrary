using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Queries;
using ELibrary.Domain.Entities;
using ELibrary.Infrastructure.Persistence;
using ELibrary.Application.Contracts.Responses;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Application.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookResponse>>
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;
        
        public GetAllBooksHandler(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<BookResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.ProjectToType<BookResponse>().ToListAsync();
        }
    }
}