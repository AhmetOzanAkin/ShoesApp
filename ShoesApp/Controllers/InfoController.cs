using Microsoft.AspNetCore.Mvc;
using ShoesApp.Data;

namespace ShoesApp.Controllers
{
    public class InfoController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public InfoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
