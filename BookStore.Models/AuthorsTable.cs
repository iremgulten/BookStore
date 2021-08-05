using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Entities
{
    public partial class AuthorsTable
    {
        public AuthorsTable()
        {
            BooksTables = new HashSet<BooksTable>();
        }

        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Biography { get; set; }

        public virtual ICollection<BooksTable> BooksTables { get; set; }
    }
}
