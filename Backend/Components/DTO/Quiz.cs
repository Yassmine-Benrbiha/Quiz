using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class QuizDTO
    {
        public Guid QuiId { get; set; }
        public string QuiTitle { get; set; } = null!;
        public string? QuiCreatedBy { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
    }
}