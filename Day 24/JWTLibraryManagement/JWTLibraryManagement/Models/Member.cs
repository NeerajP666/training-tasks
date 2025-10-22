using System.ComponentModel.DataAnnotations;

namespace JWTLibraryManagement.Models
{
    public class Member
    {
        public int MemberId {  get; set; }
        [Required]
        public string MemberName {  get; set; }
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
        [Required]
        public string Password {  get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
