using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class OptionDTO
    {
        public Guid OptId { get; set; }
        public string OptText { get; set; } = null!;
        public bool OptValue { get; set; }
    }
}