using System.Collections.Generic;
using ELibrary.Domain.Enums;
using ELibrary.Domain.Common;

namespace ELibrary.Domain.Entities
{
    public class DownloadableFile : BaseEntity
    {
        public FileFormat Format { get; set; }
        public string Link { get; set; } = "No link available";
        
        public Book Book { get; set; }
    }
}