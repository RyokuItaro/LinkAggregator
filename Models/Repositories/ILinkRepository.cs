﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAggregator.Models.Repositories
{
    public interface ILinkRepository
    {
        IEnumerable<LinkEntity> AllLinks { get; }
        int GetPoints(int linkId);
        LinkEntity GetLink(int linkId);
    }
}