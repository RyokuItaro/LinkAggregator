using LinkAggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAggregator.ViewModels
{
    public class LinkListViewModel
    {
        public IEnumerable<LinkEntity> Links { get; set; }
    }
}
