using System;
using System.Collections.Generic;
using ELibrary.Domain.Entities;
using ELibrary.Domain.Enums;

namespace ELibrary.Application.Contracts.Responses
{
    public record BookResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Genres Genres { get; set; }
        public string BriefDescription { get; set; }
        public string FullDescription { get; set; }

        public DateTime OriginallyPublishedAt { get; set; }
        public DateTime AppPublishedAt { get; set; }

        public ICollection<Author> Authors { get; set; } = new HashSet<Author>();
        public ICollection<DownloadableFile> Files { get; set; } = new HashSet<DownloadableFile>();
    }
}