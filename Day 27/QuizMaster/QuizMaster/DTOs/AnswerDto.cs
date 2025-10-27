namespace QuizMaster.DTOs
{
    public class AnswerDto
    {
        public int QuestionId { get; set; }
        public string SelectedOption { get; set; } = string.Empty;
    }
}
