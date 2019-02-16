using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraniteWarehouse.Models;
using GraniteWarehouse.Data;
using Microsoft.EntityFrameworkCore;
using GraniteWarehouse.Extensions;
using Microsoft.AspNetCore.Http;

namespace GraniteWarehouse.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        // dependancy injection, a copy of the database, readonly
        private readonly ApplicationDbContext _db;
        private string area;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            // bluiding the product list from the _db we got when it was passed in.
            var productList = await _db.Products
                .Include(mbox => mbox.ProductTypes)
                .Include(mbox => mbox.SpecialTags)
                .ToListAsync();
            return View(productList);
        }

       public async Task<IActionResult> Details(int id)
        {
            // bluiding the product list from the _db we got when it was passed in.
            var product = await _db.Products
                .Include(mbox => mbox.ProductTypes)
                .Include(mbox => mbox.SpecialTags)
                .Where(mbox => mbox.Id == id) //this is eager loading
                .FirstOrDefaultAsync();
            return View(product);

        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsPost(int id)
        {
            List<int> listShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            //make a cart, If the cart is null, then make a new one
            if (listShoppingCart == null)
            {
                listShoppingCart = new List<int>();
            }
            listShoppingCart.Add(id);
            HttpContext.Session.Set("ssShoppingCart", listShoppingCart);
            return RedirectToAction("Index", "Home", new { area = "Customer"}); // 3rd parameter when crossing areas
        }

        public IActionResult Remove(int id)
        {
            List<int> listShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if(listShoppingCart.Count > 0)
            {
                if (listShoppingCart.Contains(id))
                {
                    listShoppingCart.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", listShoppingCart);
            return RedirectToAction(nameof(Index));
        }

    }
}
