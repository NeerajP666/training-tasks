using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }


        [Required(ErrorMessage = "Book name is required.")]
        [StringLength(100, ErrorMessage = "Book name cannot exceed 100 characters.")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters.")]
        public string Genre { get; set; }

       
        [Required(ErrorMessage = "AuthorId is required.")]
        public int AuthorId { get; set; }

        public string? AuthorName { get; set; }

        public int? MemberId { get; set; }
        public string? MemberName { get; set; }
    }
}
