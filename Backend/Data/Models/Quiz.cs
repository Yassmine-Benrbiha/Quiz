using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            QuizQuestions = new HashSet<QuizQuestion>();
        }

        public Guid QuiId { get; set; }
        public string QuiTitle { get; set; } = null!;
        public DateTime QuiCreatedDate { get; set; }
        public string? QuiCreatedBy { get; set; }
        public DateTime QuiLastModifiedDate { get; set; }
        public string? QuiLastModifiedBy { get; set; }

        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
