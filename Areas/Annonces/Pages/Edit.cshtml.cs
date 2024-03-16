using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMG.Data;
using EMG.Models;

namespace EMG.Areas.Annonces.Pages
{
    public class EditModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public EditModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Annonce Annonce { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annonce =  await _context.annonces.FirstOrDefaultAsync(m => m.Id == id);
            if (annonce == null)
            {
                return NotFound();
            }
            Annonce = annonce;
            var cars = _context.Cars.Select(car => new
            {
                Id = car.Id,
                LibelleComplet = $"{car.Id} - {car.Marque.Nom}-{car.Modele.Nom}-{car.Finition.Nom}-{car.Année}"
            }).ToList();
            ViewData["CarId"] = new SelectList(cars, "Id", "LibelleComplet"); return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Annonce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnonceExists(Annonce.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AnnonceExists(int id)
        {
            return _context.annonces.Any(e => e.Id == id);
        }
    }
}
