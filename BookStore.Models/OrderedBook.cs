using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class OrderedBook
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }

        public virtual BooksTable Book { get; set; }
        public virtual OrdersTable Order { get; set; }
    }
}
