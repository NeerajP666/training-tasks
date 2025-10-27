namespace QuizMaster.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
