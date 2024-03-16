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
using EMG.Services;
using NuGet.Protocol.Plugins;

namespace EMG.Areas.Cars.pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext ctx;
        private readonly ImageService imageService;
        public EditModel(ApplicationDbContext ctx, ImageService imageService)
        {
            this.ctx = ctx;
            this.imageService = imageService;
        }

        [BindProperty]
        public Car Car { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await ctx.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
           ViewData["FinitionId"] = new SelectList(ctx.Finitions, "Id", "Nom");
           ViewData["MarqueId"] = new SelectList(ctx.Marques, "Id", "Nom");
           ViewData["ModeleId"] = new SelectList(ctx.Modeles, "Id", "Nom");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var CarToUpdate = await ctx.Cars
                 .Include(c => c.Image)
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (CarToUpdate == null)
                return NotFound();

            var uploadedImage = Car.Image;

            if (null != uploadedImage)
            {
                uploadedImage = await imageService.UploadAsync(Car.Image);

                if (CarToUpdate.Image != null)
                {
                    imageService.DeleteUploadedFile(CarToUpdate.Image);
                    CarToUpdate.Image.Name = uploadedImage.Name;
                    CarToUpdate.Image.Path = uploadedImage.Path;
                }
                else
                    CarToUpdate.Image = uploadedImage;
            }

            await TryUpdateModelAsync(CarToUpdate, "Car", c => c.VIN, c => c.Année, c => c.MarqueId, c => c.ModeleId, c => c.FinitionId, c => c.DateAchat, c => c.PrixAchat, c => c.DateDisponibilité, c => c.PrixVente, c => c.DateVente);
            {
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool CarExists(int id)
        {
            return ctx.Cars.Any(e => e.Id == id);
        }
    }
}
