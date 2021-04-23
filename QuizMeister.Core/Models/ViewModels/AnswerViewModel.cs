using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMeister.Core.Models.ViewModels
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public string Text { get; set; }
    }
}
