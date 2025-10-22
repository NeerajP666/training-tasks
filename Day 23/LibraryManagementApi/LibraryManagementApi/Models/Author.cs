using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters.")]
        public string AuthorName { get; set; }

        
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
