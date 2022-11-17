using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Interfaces;
using Task2.Models;

namespace Task2.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly MyDbContext _context;
        public QuizRepository(MyDbContext context)
        {
            _context = context;
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.Where(x => x.QuestionId == id).First();
        }

        public List<Question> GetQuestionListByDifficultyLevel(int difficulty)
        {
            return _context.Questions.Where(x => x.DifficultyId == difficulty).ToList();
        }

        public Difficulty GetDifficultyById(int id)
        {
            return _context.Difficulties.Where(x => x.DifficultyId == id).First();
        }
    }
}