using System;

namespace API.ViewModels
{
    public class QuestionVM
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public string Type { get; set; }

        public ICollection<OptionVM> Options { get; set; }
    }
}