using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Commands;
using ELibrary.Domain.Entities;
using ELibrary.Infrastructure.Persistence;
using ELibrary.Application.Contracts.Responses;
using MapsterMapper;
using MediatR;

namespace ELibrary.Application.Handlers
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand,BookResponse>
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public CreateBookHandler(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.Book);
            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);
            var response = _mapper.Map<BookResponse>(book);
            return response;

        }
    }
}