﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class PublishersTable
    {
        public PublishersTable()
        {
            BooksTables = new HashSet<BooksTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BooksTable> BooksTables { get; set; }
    }
}