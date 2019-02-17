using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraniteWarehouse.Data;
using GraniteWarehouse.Models;
using Microsoft.AspNetCore.Authorization;
using GraniteWarehouse.Utility;

namespace GraniteWarehouse.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]

    [Area("Admin")] // put this at the top ALWAYS
    public class SpecialTagsController : Controller
    {

        //dependancy injection
        public readonly ApplicationDbContext _db; // dependancy inject here!!! :)
        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db; //_db filled here.
        }

        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

            // CREATE
        //GET method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags special)// model binding here, when they submit it, productTypes is passed into this method
        {
            if (ModelState.IsValid)
            {
                _db.Add(special);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Passes it back Index.
            }

            return View(special);
        }

        // EDIT
        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTag = await _db.SpecialTags.FindAsync(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialTags productTypes)
        {
            if (id != productTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

        // DETAILs

        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _db.SpecialTags.FindAsync(id);
            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
            
        }

        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _db.SpecialTags.FindAsync(id);
            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialTags = await _db.SpecialTags.FindAsync(id);
            _db.SpecialTags.Remove(specialTags);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }// END class
}