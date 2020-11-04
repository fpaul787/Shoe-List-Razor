using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoeListRazor.Model;

namespace ShoeListRazor.Controllers
{
    [Route("api/Shoe")]
    [ApiController]
    public class ShoeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ShoeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Shoe.ToList() });
        }
    }
}
