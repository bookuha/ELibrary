using System.Collections.Generic;
using ELibrary.Application.Contracts.Responses;
using MediatR;

namespace ELibrary.Application.Queries
{
    public class GetAllBooksQuery : IRequest<List<BookResponse>>
    {
        
    }
}