using System.Collections.Generic;
using BookStore.Entities.BookStoreEntities;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Entities.UserIdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserBooks = new HashSet<UserBook>();
        }
        
        public virtual ICollection<UserBook> UserBooks { get; set; }
    }
}

