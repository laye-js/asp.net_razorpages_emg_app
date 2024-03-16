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
    public class IndexModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public IndexModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Repair> Repair { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Repair = await _context.repairs
                .Include(r => r.Cars)
                   .ThenInclude(c => c.Marque)
                    .Include(r => r.Cars)
                    .ThenInclude(c => c.Modele)
                    .Include(r => r.Cars)
                    .ThenInclude(c => c.Finition)
                .ToListAsync();
        }
    }
}
