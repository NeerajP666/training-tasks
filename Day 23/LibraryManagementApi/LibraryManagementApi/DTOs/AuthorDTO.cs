using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.DTOs
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }

       
        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters.")]
        public string AuthorName { get; set; }

      
        public List<string> Books { get; set; } = new List<string>();
    }
}
