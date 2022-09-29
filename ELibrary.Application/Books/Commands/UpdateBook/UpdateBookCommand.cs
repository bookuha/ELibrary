using System;
using System.Collections.Generic;
using ELibrary.Application.Contracts.Common;
using ELibrary.Application.Contracts.Exceptions;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Domain.Enums;
using MediatR;

namespace ELibrary.Application.Books.Commands.UpdateBook
{
    public record UpdateBookCommand : IRequest<Either<BookResponse, IServiceException>>
    {
        public long Id { get; init; }
        
        public string Name { get; init; }
        public Genres Genres { get; init; }
        public string BriefDescription { get; init; }
        public string FullDescription { get; init; }
        public DateTime OriginallyPublishedAt { get; init; }
        public IEnumerable<long> AuthorIds { get; init; } = new HashSet<long>();
        public IEnumerable<long> FileIds { get; init; } = new HashSet<long>();
    } 

}