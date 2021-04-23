using System;
using NUnit.Framework;
using QuizMeister.Core.Extensions.QuizExtensions;
using QuizMeister.Core.Models.DataModels;

namespace QuizMeister.Tests.CalculateScoreTests
{
    public class CalculateScoreTests
    {
        private QuizSession _quizSession;
        private Random _random;

        [SetUp]
        public void Setup()
        {
            _random = new Random();
            _quizSession = new QuizSession
            {
                Id = _random.Next(100),
                QuizAnswers = new System.Collections.Generic.List<QuizAnswer>
                {
                    new QuizAnswer { Answer = new Answer { IsCorrect = false } },
                    new QuizAnswer { Answer = new Answer { IsCorrect = true } },
                    new QuizAnswer { Answer = new Answer { IsCorrect = true } },
                    new QuizAnswer { Answer = new Answer { IsCorrect = false } },
                    new QuizAnswer { Answer = new Answer { IsCorrect = true } },
                    new QuizAnswer { Answer = new Answer { IsCorrect = false } },
                }
            };
        }

        [Test]
        public void IsCorrectScore()
        {
            var score = _quizSession.CalculateScore();
            Assert.AreEqual(3, score);
        }

        [Test]
        public void IsNotNull()
        {
            var score = _quizSession.CalculateScore();
            Assert.IsNotNull(score);
        }

        [Test]
        public void IsNumber()
        {
            var score = _quizSession.CalculateScore();
            Assert.IsInstanceOf(typeof(int), score);
        }

        [Test]
        public void IsPositive()
        {
            var score = _quizSession.CalculateScore();
            Assert.Positive(score);
        }

    }
}
