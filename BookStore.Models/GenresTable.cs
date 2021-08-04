using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class GenresTable
    {
        public GenresTable()
        {
            BooksTables = new HashSet<BooksTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BooksTable> BooksTables { get; set; }
    }
}
