using QuizMeister.Core.Data;
using QuizMeister.Core.Extensions;
using QuizMeister.Core.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizMeister.Core.Repositories
{
    public interface IQuizSessionRepository
    {
        QuizSession GetQuizSessionById(int id);
        List<QuizSession> GetQuizSessions();
        void AddOrUpdate(QuizSession QuizSession);
    }

    public class QuizSessionRepository : BaseRepository<AppDbContext>, IQuizSessionRepository
    {
        public QuizSessionRepository(AppDbContext context) : base(context)
        {
        }

        public QuizSession GetQuizSessionById(int id) {
            return _context.QuizSessions
                .Include(_ => _.QuizAnswers)
                    .ThenInclude(_ => _.Answer)
                .SingleOrDefault(_ => _.Id == id);
        }
        public List<QuizSession> GetQuizSessions() {
            return _context.QuizSessions.ToList();
        }
        public void AddOrUpdate(QuizSession QuizSession) {
            _context.AddOrUpdate(QuizSession);
            _context.SaveChanges();
        }
        
    }
}
