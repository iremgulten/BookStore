using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class BooksTable
    {
        public BooksTable()
        {
            OrderedBooks = new HashSet<OrderedBook>();
        }

        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public int? NumberOfPage { get; set; }
        public decimal Price { get; set; }
        public string Summary { get; set; }
        public string ImgPath { get; set; }
        public int Stock { get; set; }

        public virtual AuthorsTable Author { get; set; }
        public virtual GenresTable Genre { get; set; }
        public virtual PublishersTable Publisher { get; set; }
        public virtual ICollection<OrderedBook> OrderedBooks { get; set; }
    }
}
