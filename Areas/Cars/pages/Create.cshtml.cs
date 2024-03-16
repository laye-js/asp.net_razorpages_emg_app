#nullable disable
using EMG.Data;
using EMG.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMG.Data;
using EMG.Models;
using EMG.Services;
using NuGet.Protocol.Plugins;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace EMG.Areas.Cars.Pages;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext ctx;
    private readonly ImageService imageService;

    public CreateModel(ApplicationDbContext ctx, ImageService imageService)
    {
        this.ctx = ctx;
        this.imageService = imageService;
    }

    public IActionResult OnGet()
    {
        ViewData["FinitionId"] = new SelectList(ctx.Finitions, "Id", "Nom");
        ViewData["MarqueId"] = new SelectList(ctx.Marques, "Id", "Nom");
        ViewData["ModeleId"] = new SelectList(ctx.Modeles, "Id", "Nom");
        return Page();
    }

    [BindProperty]
    public Car Car { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        var emptyCar = new Car();
        if (null != Car.Image)
        {

            emptyCar.Image = await imageService.UploadAsync(Car.Image);
           ViewData["Message"] = emptyCar.Image.Name;
        }

        await TryUpdateModelAsync(emptyCar, "Car", c => c.VIN, c => c.Année, c => c.MarqueId, c => c.ModeleId, c => c.FinitionId, c => c.DateAchat, c => c.PrixAchat, c => c.DateDisponibilité, c => c.PrixVente, c => c.DateVente);
        
            ctx.Cars.Add(emptyCar);
            await ctx.SaveChangesAsync();

            return RedirectToPage("./Index");
      


    }

}