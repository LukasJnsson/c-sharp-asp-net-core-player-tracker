
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using c_sharp_asp_net_core_player_tracker.Data;
using c_sharp_asp_net_core_player_tracker.Models;
using Microsoft.AspNetCore.Authorization;
namespace c_sharp_asp_net_core_player_tracker.Controllers;


public class PlayersController : Controller
{
    private readonly ApplicationDbContext _context;

    public PlayersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Players
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Player.ToListAsync());
    }

    // GET: Players/Search
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Search()
    {
        return View();
    }

    // POST: Players/SearchResults
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SearchResults(string player)
    {
        return View("index", await _context.Player.Where(p => p.firstName.ToLower().Contains(player.ToLower()) || p.lastName.ToLower().Contains(player.ToLower())).ToListAsync());
    }

    // GET: Players/Details/5
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var player = await _context.Player
            .FirstOrDefaultAsync(m => m.id == id);
        if (player == null)
        {
            return NotFound();
        }

        return View(player);
    }

    // GET: Players/Create
    [HttpGet]
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    // POST: Players/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Create([Bind("id,firstName,lastName,club,salary")] Player player)
    {
        if (ModelState.IsValid)
        {
            _context.Add(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(player);
    }

    // GET: Players/Edit/5
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var player = await _context.Player.FindAsync(id);
        if (player == null)
        {
            return NotFound();
        }
        return View(player);
    }

    // POST: Players/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Edit(int id, [Bind("id,firstName,lastName,club,salary")] Player player)
    {
        if (id != player.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(player);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(player.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(player);
    }

    // GET: Players/Delete/5
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var player = await _context.Player
            .FirstOrDefaultAsync(m => m.id == id);
        if (player == null)
        {
            return NotFound();
        }

        return View(player);
    }

    // POST: Players/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var player = await _context.Player.FindAsync(id);
        if (player != null)
        {
            _context.Player.Remove(player);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PlayerExists(int id)
    {
        return _context.Player.Any(e => e.id == id);
    }
}