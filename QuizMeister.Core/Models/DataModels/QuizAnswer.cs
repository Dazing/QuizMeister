using System;

namespace QuizMeister.Core.Models.DataModels
{
    public class QuizAnswer
    {
        public int QuizSessionId { get; set; }
        public QuizSession QuizSession { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
