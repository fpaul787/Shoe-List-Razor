using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoeListRazor.Model;

namespace ShoeListRazor.Pages.ShoeList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Shoe Shoe { get; set; }

        public async Task OnGet(int id)
        {
            Shoe = await _db.Shoe.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var ShoeFromDb = await _db.Shoe.FindAsync(Shoe.Id);
                ShoeFromDb.Name = Shoe.Name;
                ShoeFromDb.ISBN = Shoe.ISBN;
                ShoeFromDb.Brand = Shoe.Brand;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
