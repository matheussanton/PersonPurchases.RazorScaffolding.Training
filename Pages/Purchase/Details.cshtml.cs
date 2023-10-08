using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorScaffolding.Training.Data;
using RazorScaffolding.Training.Models;

namespace RazorScaffolding.Training.Pages_Purchase
{
    public class DetailsModel : PageModel
    {
        private readonly RazorScaffolding.Training.Data.ApplicationDbContext _context;

        public DetailsModel(RazorScaffolding.Training.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Purchase Purchase { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Purchases == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases
                                         .Include(p => p.Person)
                                         .FirstOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }
            else 
            {
                Purchase = purchase;
            }
            return Page();
        }
    }
}
