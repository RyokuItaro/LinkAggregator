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
        private readonly IUserRepository _userRepository;
        private readonly ILinkRepository _linkRepository;

        public HomeController(IUserRepository userRepository, ILinkRepository linkRepository)
        {
            _userRepository = userRepository;
            _linkRepository = linkRepository;
        }

        public ViewResult Index()
        {
            var linksViewModel = new LinkListViewModel();
            linksViewModel.Links = _linkRepository.AllLinks;
            return View(linksViewModel);
        }
    }
}
