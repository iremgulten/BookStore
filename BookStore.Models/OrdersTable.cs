using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class OrdersTable
    {
        public OrdersTable()
        {
            OrderedBooks = new HashSet<OrderedBook>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual UsersTable User { get; set; }
        public virtual ICollection<OrderedBook> OrderedBooks { get; set; }
    }
}
