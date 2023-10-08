using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorScaffolding.Training.Models;

namespace RazorScaffolding.Training.Pages_Purchase
{
    public class CreateModel : PageModel
    {
        private readonly RazorScaffolding.Training.Data.ApplicationDbContext _context;

        public CreateModel(RazorScaffolding.Training.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Purchase Purchase { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Purchases == null || Purchase == null)
            {
                return Page();
            }

            _context.Purchases.Add(Purchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
