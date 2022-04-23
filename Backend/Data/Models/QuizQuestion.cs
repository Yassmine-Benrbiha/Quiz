using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class QuizQuestion
    {
        public Guid QuiId { get; set; }
        public Guid QueId { get; set; }
        public virtual Question Que { get; set; } = null!;
        public virtual Quiz Qui { get; set; } = null!;
    }
}
