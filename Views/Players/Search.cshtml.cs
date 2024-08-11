using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using c_sharp_asp_net_core_player_tracker.Data;
using c_sharp_asp_net_core_player_tracker.Models;

namespace c_sharp_asp_net_core_player_tracker.Views.Players
{
    public class SearchModel : PageModel
    {
        private readonly c_sharp_asp_net_core_player_tracker.Data.ApplicationDbContext _context;

        public SearchModel(c_sharp_asp_net_core_player_tracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Player.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
