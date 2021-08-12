
namespace BookStore.Business.DataTransferObjects.UserIdentityDTO
{
    public class RegisterModel
    {
        public string Role { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
