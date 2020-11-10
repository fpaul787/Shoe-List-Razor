using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Shoe.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var shoeFromDb = await _db.Shoe.FirstOrDefaultAsync(u => u.Id == id);
            if(shoeFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Shoe.Remove(shoeFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
