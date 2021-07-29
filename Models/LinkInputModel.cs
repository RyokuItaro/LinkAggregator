using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAggregator.Models
{
    public class LinkInputModel
    {
        [Required]
        [RegularExpression(@"(https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*))",
            ErrorMessage = "That link is not valid! Make sure that it starts with: \"https://www.\" or \"http://www.\"")]
        public string Url { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

    }
}
