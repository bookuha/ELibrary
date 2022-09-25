using System.Collections;
using System.Collections.Generic;
using ELibrary.Domain.Common;

namespace ELibrary.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; } = "Default Name";
        public string MiddleName { get; set; } = "Default MiddleName";
        public string LastName { get; set; } = "Default LastName";
        
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
        
    }
}