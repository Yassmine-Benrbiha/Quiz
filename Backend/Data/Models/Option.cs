using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Option
    {
        public Option()
        {
            QuestionOptions = new HashSet<QuestionOption>();
        }

        public Guid OptId { get; set; }
        public string OptText { get; set; } = null!;
        public bool OptValue { get; set; }
        public DateTime OptCreatedDate { get; set; }
        public string? OptCreatedBy { get; set; }
        public DateTime OptLastModifiedDate { get; set; }
        public string? OptLastModifiedBy { get; set; }

        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
