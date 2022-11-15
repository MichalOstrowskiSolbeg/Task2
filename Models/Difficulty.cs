using System;
using System.Collections.Generic;

#nullable disable

namespace Task2.Models
{
    public partial class Difficulty
    {
        public Difficulty()
        {
            Questions = new HashSet<Question>();
        }

        public int DifficultyId { get; set; }
        public int WinValue { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
