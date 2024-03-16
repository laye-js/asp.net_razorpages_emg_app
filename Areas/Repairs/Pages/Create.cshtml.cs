using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMG.Data;
using EMG.Models;

namespace EMG.Areas.Repairs.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext _context;

        public CreateModel(EMG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var cars = _context.Cars.Select(car => new
            {
                Id = car.Id,
                LibelleComplet = $"{car.Id} - {car.Marque.Nom}-{car.Modele.Nom}-{car.Finition.Nom}-{car.Année}"
            }).ToList();
            ViewData["CarId"] = new SelectList(cars, "Id", "LibelleComplet");
            return Page();
        }

        [BindProperty]
        public Repair Repair { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyRepair = new Repair();

            await TryUpdateModelAsync(emptyRepair, "Annonce", r => r.Description, r => r.Coût, r =>r.DateRéparation, r =>r.CarId);
           

            _context.repairs.Add(Repair);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
