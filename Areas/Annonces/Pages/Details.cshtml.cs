﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public DetailsModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Annonce Annonce { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annonce = await _context.annonces.FirstOrDefaultAsync(m => m.Id == id);
            if (annonce == null)
            {
                return NotFound();
            }
            else
            {
                Annonce = annonce;
            }
            return Page();
        }
    }
}
