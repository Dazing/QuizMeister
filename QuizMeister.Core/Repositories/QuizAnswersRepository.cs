using QuizMeister.Core.Data;
using QuizMeister.Core.Extensions;
using QuizMeister.Core.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizMeister.Core.Repositories
{
    public interface IQuizAnswerRepository
    {
        QuizAnswer GetQuizAnswerById(int sessionId, int questionId);
        List<QuizAnswer> GetQuizAnswers(int sessionId);
        void AddOrUpdate(QuizAnswer QuizAnswer);
    }

    public class QuizAnswerRepository : BaseRepository<AppDbContext>, IQuizAnswerRepository
    {
        public QuizAnswerRepository(AppDbContext context) : base(context)
        {
        }

        public QuizAnswer GetQuizAnswerById(int sessionId, int questionId) {
            return _context.QuizAnswers.SingleOrDefault(_ => _.QuizSessionId == sessionId && _.QuestionId == questionId);
        }
        public List<QuizAnswer> GetQuizAnswers(int sessionId) {
            return _context.QuizAnswers
                .Include(_ => _.Answer)
                .Where(_ => _.QuizSessionId == sessionId)
                .ToList();
        }
        public void AddOrUpdate(QuizAnswer QuizAnswer) {
            _context.AddOrUpdate(QuizAnswer);
            _context.SaveChanges();
        }
        
    }
}
