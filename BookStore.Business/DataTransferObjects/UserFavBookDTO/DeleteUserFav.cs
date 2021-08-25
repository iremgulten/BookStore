using System;


namespace BookStore.Business.DataTransferObjects.UserFavBookDTO
{
    public class DeleteUserFav
    {
        public UserNameDTO UserName { get; set; }
        public BookName Title { get; set; }
    }
}
