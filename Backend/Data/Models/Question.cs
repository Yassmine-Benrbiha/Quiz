using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Question
    {
        public Question()
        {
            QuestionOptions = new HashSet<QuestionOption>();
            QuizQuestions = new HashSet<QuizQuestion>();
        }

        public Guid QueId { get; set; }
        public string QueText { get; set; } = null!;
        public DateTime QueCreatedDate { get; set; }
        public string? QueCreatedBy { get; set; }
        public DateTime QueLastModifiedDate { get; set; }
        public string? QueLastModifiedBy { get; set; }
        public string QueType { get; set; } = null!;

        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
