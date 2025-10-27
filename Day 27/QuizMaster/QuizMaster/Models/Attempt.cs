namespace QuizMaster.Models
{
    public class Attempt
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int Score { get; set; }
        public DateTime AttemptedOn { get; set; } = DateTime.Now;
    }
}
