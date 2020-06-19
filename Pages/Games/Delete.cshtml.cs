﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly webapi.Data.AppDbContext _context;

        public DeleteModel(webapi.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.FirstOrDefaultAsync(m => m.Id == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.FindAsync(id);

            if (Game != null)
            {
                _context.Game.Remove(Game);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
