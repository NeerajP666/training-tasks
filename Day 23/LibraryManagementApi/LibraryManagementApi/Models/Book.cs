using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementApi.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book name is required.")]
        [StringLength(100, ErrorMessage = "Book name cannot exceed 100 characters.")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50)]
        public string Genre { get; set; }

     
        [Required(ErrorMessage = "AuthorId is required.")]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

       
        [ForeignKey("Member")]
        public int? MemberId { get; set; }
        public Member Member { get; set; }
    }
}
