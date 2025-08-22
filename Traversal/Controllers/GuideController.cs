using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideManager guideMAnager = new GuideManager(new EfGuideDal());
        public IActionResult Index()
        {
            var values = guideMAnager.TGetList();
            return View(values);
        }
    }
}
