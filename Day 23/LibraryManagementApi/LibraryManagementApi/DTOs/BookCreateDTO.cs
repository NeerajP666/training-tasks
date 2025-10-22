using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.DTOs
{
    public class BookCreateDTO
    {

        [Required]
        [MaxLength(150)]
        public string BookName { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
