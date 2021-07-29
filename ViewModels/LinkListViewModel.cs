using LinkAggregator.Models;
using System.Collections.Generic;

namespace LinkAggregator.ViewModels
{
    public class LinkListViewModel
    {
        public IEnumerable<LinkEntity> Links { get; set; }
    }
}
