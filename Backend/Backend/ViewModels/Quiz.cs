using System;

namespace API.ViewModels
{
    public class QuizVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public ICollection<QuestionVM> Questions { get; set; }
    }
}