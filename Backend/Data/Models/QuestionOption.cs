using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class QuestionOption
    {
        public Guid QueId { get; set; }
        public Guid OptId { get; set; }
        public virtual Option Opt { get; set; } = null!;
        public virtual Question Que { get; set; } = null!;
    }
}
