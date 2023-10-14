using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.Request
{
    public class UserRequest
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
    }
    public class AddUserRequest: UserRequest
    {
        [Required]
        public string Username { get; set; }

    }
    public class ChangePasswordRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
