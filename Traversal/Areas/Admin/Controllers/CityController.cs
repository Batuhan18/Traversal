using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        //public static List<City> cities = new List<City>
        //{
        //    new City
        //    {
        //        CityId = 1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new City
        //    {
        //        CityId = 2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //    new City
        //    {
        //        CityId = 3,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //    }
        //};
    }
}
