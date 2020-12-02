using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloBack.DAL;
using FiorelloBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
              Sliders=_db.Sliders.ToList(),
              SliderContents=_db.SliderContents.FirstOrDefault(),
              Categories=_db.Categories.Where(c=>c.IsDeleted==false).ToList(),
              Products=_db.Products.Include(p=>p.Category).Where(p=>p.IsDeleted==false).ToList(),
                Surprises = _db.Surprises.ToList(),
                Experts = _db.Experts.ToList(),
                Blogs = _db.Blogs.ToList(),
            };
            return View(homeVM);
        }
    }
}
