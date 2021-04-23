using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMeister.Core.Data;
using QuizMeister.Core.Models.DataModels;

namespace QuizMeister.Core.DefaultData
{
    public class DefaultAnswers
    {
        public static void SeedAnswers(AppDbContext context)
        {
            var questions = context.Questions.ToList();

            var answers = new List<Answer>
            {
                new Answer
                {
                    QuestionId = questions[0].Id,
                    Option = "A",
                    Text = "324",
                    IsCorrect = true
                },
                new Answer
                {
                    QuestionId = questions[0].Id,
                    Option = "B",
                    Text = "277"
                },
                new Answer
                {
                    QuestionId = questions[0].Id,
                    Option = "C",
                    Text = "365"
                },


                new Answer
                {
                    QuestionId = questions[1].Id,
                    Option = "A",
                    Text = "64000"
                },
                new Answer
                {
                    QuestionId = questions[1].Id,
                    Option = "B",
                    Text = "8000"
                },
                new Answer
                {
                    QuestionId = questions[1].Id,
                    Option = "C",
                    Text = "65536",
                    IsCorrect = true
                },


                new Answer
                {
                    QuestionId = questions[2].Id,
                    Option = "A",
                    Text = "25600 miles per second"
                },
                new Answer
                {
                    QuestionId = questions[2].Id,
                    Option = "B",
                    Text = "186000 miles per second",
                    IsCorrect = true
                },
                new Answer
                {
                    QuestionId = questions[2].Id,
                    Option = "C",
                    Text = "79100000 miles per hour"
                },


                new Answer
                {
                    QuestionId = questions[3].Id,
                    Option = "A",
                    Text = "1889"
                },
                new Answer
                {
                    QuestionId = questions[3].Id,
                    Option = "B",
                    Text = "1832"
                },
                new Answer
                {
                    QuestionId = questions[3].Id,
                    Option = "C",
                    Text = "1856",
                    IsCorrect = true
                },




                new Answer
                {
                    QuestionId = questions[4].Id,
                    Option = "A",
                    Text = "1995",
                    IsCorrect = true
                },
                new Answer
                {
                    QuestionId = questions[4].Id,
                    Option = "B",
                    Text = "2000"
                },
                new Answer
                {
                    QuestionId = questions[4].Id,
                    Option = "C",
                    Text = "1998"
                },
                new Answer
                {
                    QuestionId = questions[4].Id,
                    Option = "D",
                    Text = "2010"
                },
            };

            context.Answers.AddRange(answers);
            context.SaveChanges();
        }
    }
}
