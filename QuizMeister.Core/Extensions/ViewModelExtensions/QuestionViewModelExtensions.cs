using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizMeister.Core.Models.DataModels;
using QuizMeister.Core.Models.ViewModels;

namespace QuizMeister.Core.Extensions.ViewModelExtensions
{
    public static class QuestionViewModelExtensions
    {
        public static List<QuestionViewModel> GetQuestionViewModel(this List<Question> questions)
        {
            return questions.Select(_ => _.GetQuestionViewModel()).ToList();
        }
        public static QuestionViewModel GetQuestionViewModel(this Question question)
        {
            return new QuestionViewModel {
                Id = question.Id,
                QuestionText = question.QuestionText,
                Answers = question.Answers.GetAnswerViewModel()
            };
        }
    }
}
