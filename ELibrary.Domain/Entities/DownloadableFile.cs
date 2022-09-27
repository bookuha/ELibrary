using ELibrary.Domain.Common;
using ELibrary.Domain.Enums;

namespace ELibrary.Domain.Entities
{
    public class DownloadableFile : BaseEntity
    {
        public FileFormat Format { get; set; }
        public string Link { get; set; } = "No link available";

        public Book Book { get; set; }
    }
}