using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMeister.Core.Data;
using QuizMeister.Core.Models.DataModels;

namespace QuizMeister.Core.DefaultData
{
    public class DefaultQuestions
    {
        public static void SeedQuestions(AppDbContext context)
        {
            var questions = new List<Question>
            {
                new Question
                {
                    QuestionText = "What is the height of the Eifel tower?",
                },
                new Question
                {
                    QuestionText = "How many bits are in 8 kilobytes?",
                },
                new Question
                {
                    QuestionText = "What is the speed of light in vacuume?",
                },
                new Question
                {
                    QuestionText = "Which year was Nikola Tesla born?",
                },
                new Question
                {
                    QuestionText = "Which year did the JavaScript programming languege appear for the first time?",
                },
            };

            context.Questions.AddRange(questions);
            context.SaveChanges();
        }
    }
}
