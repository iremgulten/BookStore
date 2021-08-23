using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entities.BookStoreEntities;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Entities.UserIdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public ICollection<UserBook> UserBooks { get; set; }
    }
}
