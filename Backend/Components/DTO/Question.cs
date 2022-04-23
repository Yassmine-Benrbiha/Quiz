using System;
using System.Collections.Generic;
using System.Text;
using Components.DTO;

namespace Components.DTO
{
    public class QuestionDTO
    {
        public Guid QueId { get; set; }
        public string QueText { get; set; } = null!;
        public string QueType { get; set; }

        public ICollection<OptionDTO> Options { get; set; }
    }
}