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
    public class IndexModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public IndexModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Cars
                .Include(c => c.Finition)
                .Include(c => c.Marque)
                .Include(c => c.Modele)
                .Include(c => c.Image)
                .Include(c => c.Réparations)
                .ToListAsync();
        }
    }
}
