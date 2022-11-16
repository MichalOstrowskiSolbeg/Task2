using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.DTO;
using Task2.Interfaces;
using Task2.Models;

namespace Task2.Services
{
    public class QuizService : IQuiz
    {
        private readonly int EndValue = 1000000;
        private readonly MyDbContext _context;
        public QuizService(MyDbContext context)
        {
            _context = context;
        }

        public QuizDTO GetNextQuestion(QuizDTO data)
        {
            var q = _context.Questions.Where(x => x.QuestionId == data.Id).First();

            int difficulty = q.DifficultyId;
            var score = _context.Difficulties.Where(x => x.DifficultyId.Equals(difficulty)).First().WinValue;

            var questions = _context.Questions.Where(x => x.DifficultyId == difficulty + 1).ToList();
            var x = questions.ElementAt(new Random().Next(0, questions.Count));

            var list = new List<string>() { x.CorrectAnswer, x.Answer2, x.Answer3, x.Answer4 };
            list = list.OrderBy((item) => new Random().Next()).ToList();
            /*for (var i = list.Count; i > 0; i--)
            {
                list.Swap(0, new Random().Next(0, i));
            }*/
                

            return new QuizDTO
            {
                CurrentScore = score,
                Id = x.QuestionId,
                Question = x.Question1,
                Answer1 = list.ElementAt(0),
                Answer2 = list.ElementAt(1),
                Answer3 = list.ElementAt(2),
                Answer4 = list.ElementAt(3)
            };
        }

        public QuizDTO GetStartQuestion()
        {
            var questions = _context.Questions.Where(x => x.DifficultyId == 1).ToList();
            var x = questions.ElementAt(new Random().Next(0, questions.Count));

            var list = new List<string>() { x.CorrectAnswer, x.Answer2, x.Answer3, x.Answer4 };
            list = list.OrderBy((item) => new Random().Next()).ToList();

            return new QuizDTO
            {
                Id = x.QuestionId,
                Question = x.Question1,
                Answer1 = list.ElementAt(0),
                Answer2 = list.ElementAt(1),
                Answer3 = list.ElementAt(2),
                Answer4 = list.ElementAt(3)
            };
        }

        public bool IsAnswerCorrect(QuizDTO data, string task)
        {
            var q = _context.Questions.Where(x => x.QuestionId == data.Id).First();
            return q.CorrectAnswer.Equals(task);
        }

        public bool IsThatAWin(QuizDTO data, string task)
        {
            var q = _context.Questions.Where(x => x.QuestionId == data.Id).First();
            return _context.Difficulties.Where(x => x.DifficultyId.Equals(q.DifficultyId)).First().WinValue.Equals(EndValue) && q.CorrectAnswer.Equals(task);
        }

        public QuizDTO GetWinResult()
        {
            return new QuizDTO
            {
                CurrentScore = EndValue
            };
        }
    }
}
