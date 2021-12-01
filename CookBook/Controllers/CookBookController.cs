using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookBook.Infrastructure;
using CookBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Controllers
{
    public class CookBookController : Controller
    {
        private readonly CookBookContext context;
        public CookBookController(CookBookContext context)
        {
            this.context = context;
        }

        //GET/
        public async Task<ActionResult> Index()
        {
            IQueryable<CookBookList> items = from i in context.CookBookList orderby i.Id select i;
            List<CookBookList> cookBookList = await items.ToListAsync();
            return View(cookBookList);
        }

        // GET /cookbook/create
        public IActionResult Create() => View();

        //POST /cookbook/create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CookBookList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The recipe has been added correctly.";

                return RedirectToAction("Index");
            }
            return View(item);
        }

        //GET/ /cookbook/edit/5
        public async Task<ActionResult> Edit(int id)
        {
            CookBookList item = await context.CookBookList.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }


        //POST /cookbook/edit/id 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CookBookList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The recipe has been added correctly.";

                return RedirectToAction("Index");
            }
            return View(item);
        }
    } 
}
