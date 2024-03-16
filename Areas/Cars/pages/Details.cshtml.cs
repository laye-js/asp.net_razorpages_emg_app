using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMG.Data;
using EMG.Models;

namespace EMG.Areas.Cars.pages
{
    public class DetailsModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public DetailsModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
      
            var car = await _context.Cars
               .Include(c => c.Finition)
               .Include(c => c.Marque)
               .Include(c => c.Modele)
               .Include(c => c.Image).FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }
    }
}
