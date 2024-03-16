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
    public class IndexModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public IndexModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Marque> Marque { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Marque = await _context.Marques.ToListAsync();
        }
    }
}
