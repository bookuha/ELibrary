using System;
using System.Collections.Generic;
using ELibrary.Application.Contracts.Common;
using ELibrary.Domain.Enums;
using MediatR;

namespace ELibrary.Application.Books.Commands.CreateBook
{
    public record CreateBookCommand : IRequest<Result<long>>
    {
        public string Name { get; init; }
        public Genres Genres { get; init; }
        public string BriefDescription { get; init; }
        public string FullDescription { get; init; }
        public DateTime OriginallyPublishedAt { get; init; }
        public IEnumerable<long> AuthorIds { get; init; } = new HashSet<long>();
        public IEnumerable<long> FileIds { get; init; } = new HashSet<long>();
    }
}