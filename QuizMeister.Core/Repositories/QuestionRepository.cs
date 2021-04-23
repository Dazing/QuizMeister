using QuizMeister.Core.Data;
using QuizMeister.Core.Extensions;
using QuizMeister.Core.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizMeister.Core.Repositories
{
    public interface IQuestionRepository
    {
        Question GetQuestionById(int id);
        List<Question> GetQuestions();
        void AddOrUpdate(Question question);
    }

    public class QuestionRepository : BaseRepository<AppDbContext>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
        }

        public Question GetQuestionById(int id) {
            return _context.Questions
                .Include(_ => _.Answers)
                .SingleOrDefault(_ => _.Id == id);
        }
        public List<Question> GetQuestions() {
            return _context.Questions
                .Include(_ => _.Answers)
                .ToList();
        }
        public void AddOrUpdate(Question question) {
            _context.AddOrUpdate(question);
            _context.SaveChanges();
        }
        
    }
}
