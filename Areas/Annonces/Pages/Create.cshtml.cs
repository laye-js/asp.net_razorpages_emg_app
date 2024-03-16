using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMG.Data;
using EMG.Models;
using EMG.Services;

namespace EMG.Areas.Annonces.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EMG.Data.ApplicationDbContext ctx;

        public CreateModel(EMG.Data.ApplicationDbContext context)
        {
            ctx = context;
        }

        public IActionResult OnGet()
        {
            var cars = ctx.Cars.Select(car => new
            {
                Id = car.Id,
                LibelleComplet = $"{car.Id} - {car.Marque.Nom}-{car.Modele.Nom}-{car.Finition.Nom}-{car.Année}"
            }).ToList();
            ViewData["CarId"] = new SelectList(cars, "Id", "LibelleComplet");
            return Page();
        }

        [BindProperty]
        public Annonce Annonce { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyAnnonce = new Annonce();

            await TryUpdateModelAsync(emptyAnnonce, "Annonce", a => a.Description, a => a.CarId);

            ctx.annonces.Add(emptyAnnonce);
            await ctx.SaveChangesAsync();

            return RedirectToPage("./Index");



        }
    }
}
