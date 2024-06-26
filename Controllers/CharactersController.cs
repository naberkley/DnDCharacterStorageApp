﻿using System;
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
        public IActionResult ShowSearchForm()
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

            var character = await _context.Character
                .Include(c => c.CreatedBy)
                .Include(c => c.AbilitiesList)
                .Include(c => c.SkillsList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = _userManager.GetUserId(User);
            return View(character);
        }

        // GET: Characters/Create
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var character = new Character();

            if (Skills.Definitions?.Any() == true)
            {
                character.SkillsList = Skills.Definitions.Select(s => new Skill { SkillName = s.Key }).ToList();
            }

            if (Abilities.Definitions?.Any() == true)
            {
                character.AbilitiesList = Abilities.Definitions.Select(a => new Ability { AbilityName = a.Key }).ToList();
            }

            return View(character);
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

                // Initialize SkillsList and AbilitiesList if they're not already populated
                if (character.SkillsList == null)
                {
                    character.SkillsList = Skills.Definitions.Select(s => new Skill { SkillName = s.Key }).ToList();
                }
                if (character.AbilitiesList == null)
                {
                    character.AbilitiesList = Abilities.Definitions.Select(a => new Ability { AbilityName = a.Key }).ToList();
                }

                // Save the character to the database first to generate its ID
                _context.Add(character);
                await _context.SaveChangesAsync();

                // Now set up the relationships and save again
                foreach (var skill in character.SkillsList)
                {
                    skill.CharacterId = character.Id;
                    _context.Update(skill);
                }
                foreach (var ability in character.AbilitiesList)
                {
                    ability.CharacterId = character.Id;
                    _context.Update(ability);
                }
                await _context.SaveChangesAsync();

                // Log a success message
                _logger.LogInformation("Character created successfully with ID: {CharacterId}", character.Id);

                return RedirectToAction("Details", new { id = character.Id });
            }

            var errors = ModelState.Where(x => x.Value?.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value?.Errors })
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

            var character = await _context.Character
                .Include(c => c.CreatedBy)
                .Include(c => c.AbilitiesList)
                .Include(c => c.SkillsList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // Handle not logged in case
                return Unauthorized();
            }

            var userId = user.Id;
            if (character.CreatedById != userId)
            {
                return Unauthorized();
            }

            return View(character);
        }

        // POST: Characters/Edit/5
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

                    // Manually mark each Ability and Skill as modified
                    foreach (var ability in character.AbilitiesList)
                    {
                        _context.Entry(ability).State = EntityState.Modified;
                    }
                    foreach (var skill in character.SkillsList)
                    {
                        _context.Entry(skill).State = EntityState.Modified;
                    }

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
                // Redirect to the Details action for the updated character
                return RedirectToAction("Details", new { id = character.Id });
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

            var character = await _context.Character
                .Include(c => c.CreatedBy)
                .Include(c => c.AbilitiesList)
                .Include(c => c.SkillsList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // Handle not logged in case
                return Unauthorized();
            }

            var userId = user.Id;
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
            var character = await _context.Character
                .Include(c => c.CreatedBy)
                .Include(c => c.AbilitiesList)
                .Include(c => c.SkillsList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // Handle not logged in case
                return Unauthorized();
            }

            var userId = user.Id;
            if (character.CreatedById != userId)
            {
                return Unauthorized();
            }

            _context.Character.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.Id == id);
        }
    }
}
