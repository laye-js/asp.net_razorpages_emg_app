using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMG.Data;
using EMG.Models;

namespace EMG.Areas.Modeles.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public DeleteModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Modele Modele { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modele = await _context.Modeles.FirstOrDefaultAsync(m => m.Id == id);

            if (modele == null)
            {
                return NotFound();
            }
            else
            {
                Modele = modele;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modele = await _context.Modeles.FindAsync(id);
            if (modele != null)
            {
                Modele = modele;
                _context.Modeles.Remove(Modele);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
