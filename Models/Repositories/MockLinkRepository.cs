using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAggregator.Models.Repositories
{
    public class MockLinkRepository : ILinkRepository
    {
        public IEnumerable<LinkEntity> AllLinks => new List<LinkEntity> {
            new LinkEntity{ LinkId = 1, Url = "https://www.wp.pl", Points = 11, Title = "Strona internetowa wp"},
            new LinkEntity{ LinkId = 2, Url = "https://www.onet.pl", Points = -1, Title = "Strona internetowa onet"},
            new LinkEntity{ LinkId = 3, Url = "https://www.youtube.pl", Points = 0, Title = "Strona internetowa yt"},
            new LinkEntity{ LinkId = 4, Url = "https://www.fb.pl", Points = 1123, Title = "Strona internetowa fb"}
        };

        public LinkEntity AddLink(LinkEntity newLink) //Not needed in mock
        {
            return newLink;
        }

        public int Commit()//Not needed in mock
        {
            return 1;
        }

        public LinkEntity GetLink(int linkId)
        {
            return AllLinks.FirstOrDefault(link => link.LinkId == linkId);
        }

        public int GetPoints(int linkId)
        {
            return GetLink(linkId).Points;
        }

        public LinkEntity RemoveLink(int id) //Not needed in mock
        {
            return new LinkEntity();
        }
    }
}
