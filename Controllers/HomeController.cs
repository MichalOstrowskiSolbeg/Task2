using Microsoft.AspNetCore.Mvc;
using Task2.DTO;
using Task2.Interfaces;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private IQuiz _service { get; set; }
        public HomeController(IQuiz service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetStartQuestion());
        }

        public IActionResult Rules()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Answer(QuizDTO data, string task)
        {
            if (_service.IsThatAWin(data, task))
            {
                return View("ResultView", _service.GetWinResult());
            }

            if(_service.IsAnswerCorrect(data, task))
            {
                ModelState.Remove("Id");
                ModelState.Remove("CurrentScore");
                return View("index", _service.GetNextQuestion(data));
            }

            return View("ResultView", new QuizDTO { });
        }

        public IActionResult ResultView(QuizDTO data)
        {
            return View(data);
        }
    }
}