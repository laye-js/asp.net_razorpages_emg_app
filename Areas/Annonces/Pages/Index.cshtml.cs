using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMG.Data;
using EMG.Models;

namespace EMG.Areas.Annonces.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public IndexModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Annonce> Annonce { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Annonce = await _context.annonces
       .Include(a => a.Car)
           .ThenInclude(c => c.Marque)
       .Include(a => a.Car)
           .ThenInclude(c => c.Modele)
       .Include(a => a.Car)
           .ThenInclude(c => c.Finition)
       .Include(a => a.Car)
           .ThenInclude(c => c.Image)
            .Include(a => a.Car)
           .ThenInclude(c => c.Réparations)
       .ToListAsync();
        }
    }
}
