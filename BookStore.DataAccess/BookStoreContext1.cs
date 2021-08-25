using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess
{
    public partial class BookStoreContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
