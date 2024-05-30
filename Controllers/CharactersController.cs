using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDCharacterStorageApp.Data;
using DnDCharacterStorageApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DnDCharacterStorageApp.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CharactersController> _logger;

        public CharactersController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<CharactersController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: Characters (Index)
        public async Task<IActionResult> Index()
        {
            ViewData["UserId"] = _userManager.GetUserId(User);
            return View(await _context.Character.Include(c => c.CreatedBy).ToListAsync());
        }

        // GET: Characters/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // GET: Characters/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            SearchPhrase = SearchPhrase?.Trim(); // Remove whitespace from the start and end of the search phrase

            if (string.IsNullOrEmpty(SearchPhrase))
            {
                // If the search phrase is null or empty after trimming, redirect to the index page
                return RedirectToAction("Index");
            }

            // Perform the search...
            ViewBag.SearchPhrase = SearchPhrase; // Store the search phrase in ViewBag
            return View("Index", await _context.Character.Where( j => j.Name.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character.Include(c => c.CreatedBy).FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = _userManager.GetUserId(User);
            return View(character);
        }

        // GET: Characters/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Character character)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    // Handle not logged in case
                    return Unauthorized();
                }
                character.CreatedById = user.Id;

                _context.Add(character);
                await _context.SaveChangesAsync();

                // Log a success message
                _logger.LogInformation("Character created successfully with ID: {CharacterId}", character.Id);

                return RedirectToAction(nameof(Index));
            }

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            foreach (var error in errors)
            {
                foreach (var subError in error.Errors)
                {
                    _logger.LogError("Error in property {Property}: {ErrorMessage}", error.Key, subError.ErrorMessage);
                }
            }

            return View(character);
        }

        // GET: Characters/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character.Include(c => c.CreatedBy).FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            if (character.CreatedById != userId)
            {
                return Unauthorized();
            }

            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
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
            return View(character);
        }

        // GET: Characters/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character.Include(c => c.CreatedBy).FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            if (character.CreatedById != userId)
            {
                return Unauthorized();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Character.Include(c => c.CreatedBy).FirstOrDefaultAsync(m => m.Id == id);
            if (character != null)
            {
                _context.Character.Remove(character);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.Id == id);
        }
    }
}
