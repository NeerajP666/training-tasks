namespace QuizMaster.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int AttemptId { get; set; }
        public int QuestionId { get; set; }
        public string SelectedOption { get; set; }
    }
}