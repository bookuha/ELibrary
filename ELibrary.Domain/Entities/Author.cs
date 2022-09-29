using System.Collections.Generic;
using ELibrary.Domain.Common;

namespace ELibrary.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}