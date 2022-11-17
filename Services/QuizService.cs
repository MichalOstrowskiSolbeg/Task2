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
        private readonly IQuizRepository _repository;
        public QuizService(IQuizRepository repository)
        {
            _repository = repository;
        }

        public QuizDTO GetNextQuestion(QuizDTO data)
        {
            var q = _repository.GetQuestionById(data.Id);

            int difficulty = q.DifficultyId;
            
            var score = _repository.GetDifficultyById(difficulty).WinValue;

            var questions = _repository.GetQuestionListByDifficultyLevel(difficulty + 1);
            var x = questions.ElementAt(new Random().Next(0, questions.Count));

            var list = new List<string>() { x.CorrectAnswer, x.Answer2, x.Answer3, x.Answer4 };
            list = list.OrderBy((item) => new Random().Next()).ToList();            

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
            var questions = _repository.GetQuestionListByDifficultyLevel(1);
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
            var q = _repository.GetQuestionById(data.Id);
            return q.CorrectAnswer.Equals(task);
        }

        public bool IsThatAWin(QuizDTO data, string task)
        {
            var q = _repository.GetQuestionById(data.Id);
            return _repository.GetDifficultyById(q.DifficultyId).WinValue.Equals(EndValue) && q.CorrectAnswer.Equals(task);
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
