using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoeListRazor.Model;

namespace ShoeListRazor.Pages.ShoeList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Shoe> Shoes { get; set; }

        public async Task OnGet()
        {
            // going to database and receing all of the shoes
            Shoes = await _db.Shoe.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var shoe = await _db.Shoe.FindAsync(id);
            if(shoe == null)
            {
                return NotFound();
            }
            _db.Shoe.Remove(shoe);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}