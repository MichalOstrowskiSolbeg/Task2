using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Interfaces
{
    public interface IQuizRepository
    {
        Question GetQuestionById(int id);

        List<Question> GetQuestionListByDifficultyLevel(int difficulty);

        Difficulty GetDifficultyById(int id);
    }
}