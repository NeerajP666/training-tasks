using System.ComponentModel.DataAnnotations;

namespace JWTLibraryManagement.DTOs
{
    public class MemberLoginDTO
    {
        [Required]
        public string Email { get; set; }  

        [Required]
        public string Password { get; set; }
    }

}
