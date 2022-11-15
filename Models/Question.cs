using System;
using System.Collections.Generic;

#nullable disable

namespace Task2.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public int DifficultyId { get; set; }
        public string Question1 { get; set; }
        public string CorrectAnswer { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

        public virtual Difficulty Difficulty { get; set; }
    }
}
