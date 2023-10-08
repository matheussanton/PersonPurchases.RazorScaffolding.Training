using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorScaffolding.Training.Data;
using RazorScaffolding.Training.Models;

namespace RazorScaffolding.Training.Pages_Person
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
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.People == null || Person == null)
            {
                return Page();
            }

            _context.People.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
