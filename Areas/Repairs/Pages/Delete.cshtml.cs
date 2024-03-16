using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMG.Data;
using EMG.Models;

namespace EMG.Areas.Repairs.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public DeleteModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Repair Repair { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.repairs.FirstOrDefaultAsync(m => m.Id == id);

            if (repair == null)
            {
                return NotFound();
            }
            else
            {
                Repair = repair;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.repairs.FindAsync(id);
            if (repair != null)
            {
                Repair = repair;
                _context.repairs.Remove(Repair);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
