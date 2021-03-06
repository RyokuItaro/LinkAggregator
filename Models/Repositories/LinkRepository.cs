using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkAggregator.Models.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly AppDbContext db;

        public LinkRepository(AppDbContext appDbContext)
        {
            db = appDbContext;
        }
        public IQueryable<LinkEntity> AllLinksQueryable
        {
            get
            {
                return db.Links;
            }
        }
        public IEnumerable<LinkEntity> AllLinks
        {
            get
            {
                return db.Links;
            }
        }

        public LinkEntity AddLink(LinkEntity newLink)
        {
            db.Add(newLink);
            return newLink;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public LinkEntity GetLink(int linkId)
        {
            return db.Links.FirstOrDefault(link => link.LinkId == linkId);
        }

        public int GetPoints(int linkId)
        {
            var link = GetLink(linkId);
            if(link != null)
            {
                return link.Points;
            }
            return 0;
        }

        public LinkEntity RemoveLink(int linkId)
        {
            var link = GetLink(linkId);
            if (link != null)
            {
                db.Links.Remove(link);
            }
            return link;
        }
        public void ClearRecords()
        {
            db.Links.RemoveRange(db.Links);
        }

        public void Voting(int value, int linkId)
        {
            var linkToChangeScore = GetLink(linkId);
            linkToChangeScore.Points += value;
        }
    }
}