using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorScaffolding.Training.Data;
using RazorScaffolding.Training.Models;

namespace RazorScaffolding.Training.Pages_Purchase
{
    public class EditModel : PageModel
    {
        private readonly RazorScaffolding.Training.Data.ApplicationDbContext _context;

        public EditModel(RazorScaffolding.Training.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Purchase Purchase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Purchases == null)
            {
                return NotFound();
            }

            var purchase =  await _context.Purchases.FirstOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }
            Purchase = purchase;
           ViewData["PersonId"] = new SelectList(_context.People, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(Purchase.Id))
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

        private bool PurchaseExists(int id)
        {
          return (_context.Purchases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
