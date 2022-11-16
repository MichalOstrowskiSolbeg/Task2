using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.DTO;

namespace Task2.Interfaces
{
    public interface IQuiz 
    {
        bool IsAnswerCorrect(QuizDTO data, string task);

        QuizDTO GetStartQuestion();

        QuizDTO GetNextQuestion(QuizDTO data);

        bool IsThatAWin(QuizDTO data, string task);

        QuizDTO GetWinResult();
    }
}
