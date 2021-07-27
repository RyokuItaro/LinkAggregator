using LinkAggregator.Models;
using LinkAggregator.Models.Repositories;
using LinkAggregator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAggregator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkRepository _linkRepository;

        public HomeController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var links = _linkRepository.AllLinksQueryable.OrderBy(l => l.Points);
            return View(await PaginatedLinkList<LinkEntity>.CreateAsync(links, pageNumber, 100));
        }
        public IActionResult AddLink()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLink(LinkInputModel link)
        {
            var linkToAdd = new LinkEntity();
            if (ModelState.IsValid)
            {
                linkToAdd.CreationDate = DateTime.Now;
                linkToAdd.Creator = "test";
                linkToAdd.Points = 0;
                linkToAdd.Title = link.Title;
                linkToAdd.Url = link.Url;
                _linkRepository.AddLink(linkToAdd);
                _linkRepository.Commit();
                return RedirectToAction("LinkAdded");
            }
            return View(link);
        }
        public IActionResult LinkAdded()
        {
            ViewBag.LinkAddedMessage = "Link has been added!";
            return View();
        }
        public IActionResult ClearRecords()
        {
            _linkRepository.ClearRecords();
            _linkRepository.Commit();
            return RedirectToAction("Index");
        }
        public IActionResult UpVote(int linkId)
        {
            return RedirectToAction("Index");
        }
        public IActionResult DownVote(int linkId)
        {
            return RedirectToAction("Index");
        }
    }
}
