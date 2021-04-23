using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizMeister.Core.Models.DataModels;
using QuizMeister.Core.Models.ViewModels;

namespace QuizMeister.Core.Extensions.ViewModelExtensions
{
    public static class AnswerViewModelExtensions
    {
        public static List<AnswerViewModel> GetAnswerViewModel(this List<Answer> answers)
        {
            return answers.Select(_ => _.GetAnswerViewModel()).ToList();
        }
        public static AnswerViewModel GetAnswerViewModel(this Answer answer)
        {
            return new AnswerViewModel {
                Id = answer.Id,
                Option = answer.Option,
                Text = answer.Text
            };
        }
    }
}
