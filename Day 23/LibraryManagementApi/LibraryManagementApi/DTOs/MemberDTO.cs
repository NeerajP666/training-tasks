using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.DTOs
{
    public class MemberDTO
    {
        public int MemberId { get; set; }

       
        [Required(ErrorMessage = "Member name is required.")]
        [StringLength(100, ErrorMessage = "Member name cannot exceed 100 characters.")]
        public string MemberName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

       
        public List<string> Books { get; set; } = new List<string>();
    }
}
