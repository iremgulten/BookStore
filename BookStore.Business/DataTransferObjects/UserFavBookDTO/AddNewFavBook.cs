namespace BookStore.Business.DataTransferObjects.UserFavBookDTO
{
    public class AddNewFavBook
    {
        public UserNameDTO UserName { get; set; }
        public BookName Title { get; set; }
    }
}
