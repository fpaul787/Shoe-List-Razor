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
            
        }

        [BindProperty]
        public Shoe Shoe { get; set; }

        public async Task OnGet(int id)
        {
            Shoe = await _db.Shoe.FindAsync(id);
        }
    }
}
