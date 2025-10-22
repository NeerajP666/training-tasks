using System.ComponentModel.DataAnnotations;

namespace JWTLibraryManagement.DTOs
{
    public class BookDTO
    {
        public int BookId {  get; set; }
        [Required(ErrorMessage = "Book name is required.")]
        public string BookName {  get; set; }
        [Required(ErrorMessage = "Genre is required.")]
        public string Genre {  get; set; }
        [Required(ErrorMessage = "AuthorId is required.")]
        public int AuthorId {  get; set; }
        public string? AuthorName {  get; set; }
        public int? MemberId { get; set; }
        public string? MemberName {  get; set; }
    }
}
