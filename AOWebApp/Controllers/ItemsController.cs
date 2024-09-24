using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AOWebApp.Data;
using AOWebApp.Models;
using AOWebApp.ViewModels;

namespace AOWebApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AmazonOrdersContext _context;

        public ItemsController(AmazonOrdersContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index(ItemSearchViewModel vm, string sortOrder)
        {
            // Pass sortOrder to the view
            ViewBag.sortOrder = sortOrder;
            // Modify the action including #regions
            #region CategoriesQuery
            var categories = await _context.ItemCategories
                .Where(c => c.ParentCategoryId == null) // Find all categories the parents categories is null 
                .Select(c => new { c.CategoryId, c.CategoryName }) // Select only the CategoryId and its name as a new anonymous obj
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            //// Pass the category list to the index view
            //ViewBag.CategoryList = new SelectList(Categories,
            //    nameof(ItemCategory.CategoryId),
            //    nameof(ItemCategory.CategoryName));

            // Pass the category list to the viewModel
            vm.CategoryList = new SelectList(categories,
                nameof(ItemCategory.CategoryId),
                nameof(ItemCategory.CategoryName));

            #endregion

            #region ItemQuery
            // ViewBag.SearchText = searchText;
            var amazonOrdersContext = _context.Items
                .Include(i => i.Category)
                .Include(i => i.Reviews)
                .OrderBy(i => i.ItemName)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(vm.SearchText))
            {
                amazonOrdersContext = amazonOrdersContext
                    .Where(i => i.ItemName.Contains(vm.SearchText));
            }
            // Adding category value check 
            if (vm.CategoryId != null)
            {
                amazonOrdersContext = amazonOrdersContext
                    .Where(i => i.Category.ParentCategoryId == vm.CategoryId);
                
            }
            // Update Index() action to meet the sort function
            switch (sortOrder)
            {
                case "name_desc":
                    amazonOrdersContext = amazonOrdersContext.OrderByDescending(i => i.ItemName);
                    break;
                case "price_asc":
                    amazonOrdersContext = amazonOrdersContext.OrderBy(i => i.ItemCost);
                    break;
                case "price_desc":
                    amazonOrdersContext = amazonOrdersContext.OrderByDescending(i => i.ItemCost);
                    break;
                default:
                    amazonOrdersContext = amazonOrdersContext.OrderBy(i => i.ItemName);
                    break;
            }
            // Item Rating viewModel
            vm.ItemList = await amazonOrdersContext
                .Select(i => new ItemRatingViewModel
                {
                    TheItem = i,
                    ReviewCount = i.Reviews != null ? i.Reviews.Count : 0,
                    AverageRating = i.Reviews != null && i.Reviews.Count() > 0 ? i.Reviews.Average(r => r.Rating) : 0
                })
                .ToListAsync();
            #endregion

            return View(vm);
        }

        // GET: Items/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,ItemDescription,ItemCost,ItemImage,CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "CategoryId", "CategoryId", item.CategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "CategoryId", "CategoryId", item.CategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,ItemDescription,ItemCost,ItemImage,CategoryId")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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
            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "CategoryId", "CategoryId", item.CategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
