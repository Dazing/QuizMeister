using System;
using System.Collections.Generic;

namespace QuizMeister.Core.Models.DataModels
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
