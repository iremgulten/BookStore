﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System.Collections.Generic;

namespace BookStore.Entities.BookStoreEntities
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string PublisherName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}