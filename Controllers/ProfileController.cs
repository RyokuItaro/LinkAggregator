using LinkAggregator.Models;
using LinkAggregator.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LinkAggregator.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILinkRepository _linkRepository;
        private readonly UserManager<UserEntity> _userManager;

        public ProfileController(ILinkRepository linkRepository, UserManager<UserEntity> userManager)
        {
            _linkRepository = linkRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var links = _linkRepository.AllLinksQueryable.OrderByDescending(l => l.Points);
            return View(await PaginatedLinkList<LinkEntity>.CreateAsync(links, pageNumber, 10));
        }
    }
}
