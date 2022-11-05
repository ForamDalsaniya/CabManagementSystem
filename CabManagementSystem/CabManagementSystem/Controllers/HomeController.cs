using CabManagementSystem.Models;
using CabManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CabManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICabRepository _cabRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(ICabRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _cabRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        public IActionResult CabIndex()
        {
            return View();
        }
        [HttpGet]
=======
>>>>>>> a442d54260d84ac05c5374ed36d3c42bf507f58e
        public IActionResult CabDriverHome()
        {
            return View();
        }
<<<<<<< HEAD
        private string ProcessUploadFile(CabCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpPost]
        [Authorize]
        public IActionResult CabDriverHome(CabCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);
                Cab cab = new Cab
                {
                    CabModel = model.CabModel,
                    numberPlate = model.numberPlate,
                    AC = model.AC,
                    PhotoPath = uniqueFileName,
                    DriverId = model.DrivarId
                };
                _cabRepository.Add(cab);
                return RedirectToAction("CabIndex");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CabBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CabBook([FromForm]string? cityName)
        {
            string city = cityName ?? string.Empty;
            ViewBag.city = city;
            var model = _cabRepository.GetCab();
            return View("ListCab",model);
        }
        public IActionResult ListCab()
        {
            return View();
        }
=======
>>>>>>> a442d54260d84ac05c5374ed36d3c42bf507f58e
    }

}
