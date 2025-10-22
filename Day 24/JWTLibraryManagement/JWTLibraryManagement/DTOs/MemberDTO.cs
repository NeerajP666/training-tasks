using System.ComponentModel.DataAnnotations;

namespace JWTLibraryManagement.DTOs
{
    public class MemberDTO
    {
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Member name is required.")]
        public string MemberName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        public List<string> Books { get; set; } = new List<string>();

    }
}
