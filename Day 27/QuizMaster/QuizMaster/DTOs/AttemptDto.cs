using static QuizMaster.Controllers.AttemptController;

namespace QuizMaster.DTOs
{
    public class AttemptDto
    {
        public int QuizId { get; set; }
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }
}
