using System.ComponentModel.DataAnnotations;

namespace JWTLibraryManagement.DTOs
{
    public class AuthorDTO
    {
        public int AuthorId {  get; set; }
        [Required(ErrorMessage = "Author name is required.")]
        public string AuthorName {  get; set; }
        public List<string> Books {  get; set; }    = new List<string>();
    }
}
