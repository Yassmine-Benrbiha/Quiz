using System;

namespace API.ViewModels
{
    public class OptionVM
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public bool Value { get; set; }
    }
}