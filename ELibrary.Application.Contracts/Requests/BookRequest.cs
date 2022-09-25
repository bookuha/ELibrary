using System;
using ELibrary.Domain.Enums;

namespace ELibrary.Application.Contracts.Requests
{
    public record BookRequest()
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Genres Genres { get; set; }
        public string BriefDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime OriginallyPublishedAt { get; set; } = new DateTime(1995, 11, 1);
        public DateTime AppPublishedAt { get; set; } = DateTime.Now;
    }
}