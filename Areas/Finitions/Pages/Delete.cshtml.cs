using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMG.Data;
using EMG.Models;

namespace EMG.Areas.Finitions.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public DeleteModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Finition Finition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finition = await _context.Finitions.FirstOrDefaultAsync(m => m.Id == id);

            if (finition == null)
            {
                return NotFound();
            }
            else
            {
                Finition = finition;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finition = await _context.Finitions.FindAsync(id);
            if (finition != null)
            {
                Finition = finition;
                _context.Finitions.Remove(Finition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
