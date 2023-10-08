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
    public class IndexModel : PageModel
    {
        private readonly RazorScaffolding.Training.Data.ApplicationDbContext _context;

        public IndexModel(RazorScaffolding.Training.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Purchase> Purchase { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Purchases != null)
            {
                Purchase = await _context.Purchases
                .Include(p => p.Person).ToListAsync();
            }
        }
    }
}
