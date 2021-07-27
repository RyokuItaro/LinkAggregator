using System;
using System.ComponentModel.DataAnnotations;

namespace LinkAggregator.Models
{
    public class LinkEntity
    {
        [Key]
        public int LinkId { get; set; }
        public string Url { get; set; }
        public int Points { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
