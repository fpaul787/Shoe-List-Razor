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
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Shoe Shoe { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Shoe = new Shoe();
            if (id == null)
            {
                //create
                return Page();
            }

            // update
            Shoe = await _db.Shoe.FirstOrDefaultAsync(u => u.Id == id);
            if (Shoe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Shoe.Id == 0)
                {
                    _db.Shoe.Add(Shoe);
                }
                else
                {
                    _db.Shoe.Update(Shoe);
                }

                // save changes
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
        

        
    }
}
