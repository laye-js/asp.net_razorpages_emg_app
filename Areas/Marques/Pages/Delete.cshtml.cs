using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMG.Data;
using EMG.Models;

namespace EMG.Areas.Marques.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public DeleteModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Marque Marque { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marque = await _context.Marques.FirstOrDefaultAsync(m => m.Id == id);

            if (marque == null)
            {
                return NotFound();
            }
            else
            {
                Marque = marque;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marque = await _context.Marques.FindAsync(id);
            if (marque != null)
            {
                Marque = marque;
                _context.Marques.Remove(Marque);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
