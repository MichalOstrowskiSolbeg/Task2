using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Task2.DTO;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext _context { get; set; }
        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var x = _context.Questions.First();
            var data = new QuizDTO
            {
                Question = x.Question1,
                Answer1 = x.CorrectAnswer,
                Answer2 = x.Answer2,
                Answer3 = x.Answer3,
                Answer4 = x.Answer4
            };
            return View(data);
        }

        public IActionResult Rules()
        {
            return View();
        }

        public IActionResult ResultView(QuizDTO data)
        {
            return View(data);
        }
    }
}