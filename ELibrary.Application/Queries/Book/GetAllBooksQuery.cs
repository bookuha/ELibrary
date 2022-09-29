using System.Collections.Generic;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Responses;
using MediatR;

namespace ELibrary.Application.Queries
{
    public record GetAllBooksQuery() : IRequest<Either<List<BookResponse>, IServiceException>>;



}