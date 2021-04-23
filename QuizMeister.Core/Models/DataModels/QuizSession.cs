using System;
using System.Collections.Generic;

namespace QuizMeister.Core.Models.DataModels
{
    public class QuizSession
    {
        public int Id { get; set; }
        public List<QuizAnswer> QuizAnswers { get; set; }
    }
}
