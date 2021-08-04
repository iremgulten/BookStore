using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class UsersTable
    {
        public UsersTable()
        {
            OrdersTables = new HashSet<OrdersTable>();
        }

        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<OrdersTable> OrdersTables { get; set; }
    }
}
