﻿using System;

namespace QuizMeister.Core.Models.DataModels
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string Option { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
