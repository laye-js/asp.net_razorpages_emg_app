using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMG.Data;
using EMG.Models;

namespace EMG.Areas.Modeles.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public CreateModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Modele Modele { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Modeles.Add(Modele);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
