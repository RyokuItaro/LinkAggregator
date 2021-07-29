using LinkAggregator.Models;
using LinkAggregator.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LinkAggregator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkRepository _linkRepository;
        private readonly UserManager<UserEntity> _userManager;

        public HomeController(ILinkRepository linkRepository, UserManager<UserEntity> userManager)
        {
            _linkRepository = linkRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var links = _linkRepository.AllLinksQueryable.OrderByDescending(l => l.Points);
            return View(await PaginatedLinkList<LinkEntity>.CreateAsync(links, pageNumber, 100));
        }
        [Authorize]
        public IActionResult AddLink()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddLink(LinkInputModel link)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var displayName = currentUser.VisibleName;
            var linkToAdd = new LinkEntity();
            if (ModelState.IsValid)
            {
                linkToAdd.CreationDate = DateTime.Now;
                linkToAdd.Creator = displayName;
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
        [Authorize]
        public IActionResult UpVote(int linkId)
        {
            _linkRepository.Voting(1, linkId);
            _linkRepository.Commit();
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult DownVote(int linkId)
        {
            _linkRepository.Voting(-1, linkId);
            _linkRepository.Commit();
            return RedirectToAction("Index");
        }
    }
}
