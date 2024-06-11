using Microsoft.AspNetCore.Mvc;
using ShoesApp.Data;
using ShoesApp.Models;


namespace ShoesApp.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CheckShoesId(int shoesId)
        {
            
            var infoRecord = _context.Info.FirstOrDefault(info => info.ShoesId == shoesId);
            if (infoRecord == null)
            {
                TempData["ShoesId"] = shoesId;
                return RedirectToAction("CreateUser");
            }
            TempData["ShoesId"] = shoesId;
            return RedirectToAction("DisplayInfoFields", shoesId);
           
        }
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if(user != null)
                {
                    TempData["UserId"] = user.UserId;
                    TempData.Keep("ShoesId"); // shoesId'yi saklamaya devam edin
                    return RedirectToAction("SelectInfoFields");
                }
                ViewData["ErrorMessage"] = "Kullanıcı Veya Şifre hatalı.";
                return View();
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult SelectInfoFields()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectInfoFields(Info info)
        {

            if (TempData["UserId"] == null || TempData["ShoesId"] == null)
            {
                return RedirectToAction("Login");
            }
            var userId = (int)TempData["UserId"];
            var shoesId = (int)TempData["ShoesId"];
            TempData.Keep("UserId"); // TempData'yı sakla
            TempData.Keep("ShoesId"); // TempData'yı sakla

			info.NameVisibility = info.NameVisibility.HasValue && info.NameVisibility.Value;
			info.RelatedName1Visibility = info.RelatedName1Visibility.HasValue && info.RelatedName1Visibility.Value;
			info.RelatedName2Visibility = info.RelatedName2Visibility.HasValue && info.RelatedName2Visibility.Value;
			info.RelatedPhone1Visibility = info.RelatedPhone1Visibility.HasValue && info.RelatedPhone1Visibility.Value;
			info.RelatedPhone2Visibility = info.RelatedPhone2Visibility.HasValue && info.RelatedPhone2Visibility.Value;
			info.AddressVisibility = info.AddressVisibility.HasValue && info.AddressVisibility.Value;
			info.MessageVisibility = info.MessageVisibility.HasValue && info.MessageVisibility.Value;
			info.EmailVisibility = info.EmailVisibility.HasValue && info.EmailVisibility.Value;

			info.UserId = userId;
            info.ShoesId = shoesId;
			_context.Info.Add(info);
            _context.SaveChanges();
            return RedirectToAction("DisplayInfoFields");
        }
        [HttpGet]
        public IActionResult EditInfoFields(int id)
        {
            var info = _context.Info.Find(id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }
        [HttpPost]
        public IActionResult EditInfoFields(Info info)
        {
            if (ModelState.IsValid)
            {
                _context.Info.Update(info);
                _context.SaveChanges();
                return RedirectToAction("DisplayInfoFields", new { shoesId = info.ShoesId });
            }
            return View(info);
        }

        [HttpGet]
        public ActionResult DisplayInfoFields()
        {
            if (TempData["ShoesId"] == null)
            {
                return RedirectToAction("Login");
            }

            var shoesId = (int)TempData["ShoesId"];
            TempData.Keep("ShoesId"); // TempData'yı sakla
			var infoList = _context.Info.Where(i => i.ShoesId == shoesId).ToList();
			var sonKayit = infoList.LastOrDefault(); // Son kaydı seçer
            return View(sonKayit);
		}
        [HttpGet]
        public IActionResult CreateUser() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(UserViewModel model) 
        {
            if (ModelState.IsValid) {
                var user = new User
                {
                    Username = model.UserName,
                    Password = model.Password,
                };
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
