using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizMeister.Core.Extensions;
using QuizMeister.Core.Extensions.QuizExtensions;
using QuizMeister.Core.Extensions.ViewModelExtensions;
using QuizMeister.Core.Models.DataModels;
using QuizMeister.Core.Models.RequestModels;
using QuizMeister.Core.Models.ViewModels;
using QuizMeister.Core.Repositories;

namespace QuizMeister.Web.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : BaseAPIController
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizSessionRepository _quizSessionRepository;
        private readonly IQuizAnswerRepository _quizAnswerRepository;
        private readonly Random _random;

        public QuizController(
            IQuestionRepository questionRepository,
            IQuizSessionRepository quizSessionRepository,
            IQuizAnswerRepository quizAnswerRepository
        )
        {
            _questionRepository = questionRepository;
            _quizSessionRepository = quizSessionRepository;
            _quizAnswerRepository = quizAnswerRepository;

            _random = new Random();
        }


        [HttpGet("start")]
        public ActionResult<int> StartQuiz()
        {
            return TryExecute(() =>
            {
                var session = new QuizSession();
                _quizSessionRepository.AddOrUpdate(session);

                return session.Id;
            });
        }

        [HttpGet("{sessionId}/questions/next")]
        public ActionResult<QuestionViewModel> GetNextQuestion(int sessionId)
        {
            return TryExecute(() =>
            {
                var session = _quizSessionRepository.GetQuizSessionById(sessionId);
                var questions = _questionRepository.GetQuestions();

                var answeredQuestions = session.QuizAnswers.Select(_ => _.QuestionId).ToList();
                var questionIds = questions.Where(_ => !answeredQuestions.Contains(_.Id)).Select(_ => _.Id).ToList();

                if (questionIds == null || questionIds.Count == 0)
                    return null;

                var questionId = questionIds[_random.Next(questionIds.Count)];

                var question = _questionRepository.GetQuestionById(questionId).GetQuestionViewModel();
                question.HasNext = questionIds.Count > 1; 
                return question;
            });
        }

        [HttpPost("{sessionId}/questions/{questionId}/answer")]
        public ActionResult<QuizAnswer> PostQuizAnswers(int sessionId, int questionId, [FromBody] QuizAnswerRequestModel answer)
        {
            return TryExecute(() =>
            {
                var existingAnswer = _quizAnswerRepository.GetQuizAnswerById(sessionId, questionId);

                if (existingAnswer != null)
                    throw new InvalidOperationException("An answer for the question already exists, you cannot change your answer.");

                var quizAnswer = new QuizAnswer
                {
                    QuizSessionId = sessionId,
                    QuestionId = questionId,
                    AnswerId = answer.AnswerId
                };
                _quizAnswerRepository.AddOrUpdate(quizAnswer);

                return quizAnswer;
            });
        }

        [HttpGet("{sessionId}/score")]
        public ActionResult<int> GetQuizScore(int sessionId)
        {
            return TryExecute(() =>
            {
                var quizSession = _quizSessionRepository.GetQuizSessionById(sessionId);
                var score = quizSession.CalculateScore();
                return score;
            });
        }
    }
}
