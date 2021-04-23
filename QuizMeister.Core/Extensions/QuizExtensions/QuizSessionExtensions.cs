using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMeister.Core.Models.DataModels;

namespace QuizMeister.Core.Extensions.QuizExtensions
{
    public static class QuizSessionExtensions
    {
        public static int CalculateScore (this QuizSession quizSession)
        {
            var score = 0;
            
            foreach (var answer in quizSession.QuizAnswers)
                if (answer.Answer.IsCorrect) score++;

            return score;
        }
    }
}
