using System;
using System.Collections.Generic;
using ELibrary.Domain.Enums;

namespace ELibrary.Application.Contracts.Requests
{
    public record BookRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Genres Genres { get; set; }
        public string BriefDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime OriginallyPublishedAt { get; set; } = new(1995, 11, 1);
        public ICollection<long> AuthorIds { get; set; } = new HashSet<long>();
        public ICollection<long> FileIds { get; set; } = new HashSet<long>();
    }
}