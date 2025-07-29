using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            List<Announcement> announcements = _announcementService.TGetList();
            List<AnnouncementListViewModel> models = new List<AnnouncementListViewModel>();
            foreach (var item in announcements)
            {
                AnnouncementListViewModel announcementListViewModel = new AnnouncementListViewModel();
                announcementListViewModel.ID = item.AnnouncementID;
                announcementListViewModel.Title = item.Title;
                announcementListViewModel.Content = item.Content;

                models.Add(announcementListViewModel);
            }
            return View(models);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(string x)
        {
            return View();
        }
    }
}
