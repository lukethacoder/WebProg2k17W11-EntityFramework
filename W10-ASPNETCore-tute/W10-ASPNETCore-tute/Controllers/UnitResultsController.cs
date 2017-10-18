using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using W10_ASPNETCore_tute.Data;

namespace W10_ASPNETCore_tute.Controllers
{
    public class UnitResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitResultsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: UnitResults
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnitResult.ToListAsync());
        }

        // GET: UnitResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitResult = await _context.UnitResult
                .SingleOrDefaultAsync(m => m.Id == id);
            if (unitResult == null)
            {
                return NotFound();
            }

            return View(unitResult);
        }

        // GET: UnitResults/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,StudentName,Assignment1Mark,Assignment2Mark,ExamMark,TotalMark,Grade")] UnitResult unitResult)
        {
            if (ModelState.IsValid)
            {
                var total = double.Parse(unitResult.Assignment1Mark) +
                double.Parse(unitResult.Assignment2Mark) +
                double.Parse(unitResult.ExamMark);
                unitResult.TotalMark = total.ToString();

                _context.Add(unitResult);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(unitResult);
        }

        // GET: UnitResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitResult = await _context.UnitResult.SingleOrDefaultAsync(m => m.Id == id);
            if (unitResult == null)
            {
                return NotFound();
            }
            return View(unitResult);
        }

        // POST: UnitResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,StudentName,Assignment1Mark,Assignment2Mark,ExamMark,TotalMark,Grade")] UnitResult unitResult)
        {
            if (id != unitResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var total = double.Parse(unitResult.Assignment1Mark) +
                double.Parse(unitResult.Assignment2Mark) +
                double.Parse(unitResult.ExamMark);
                    unitResult.TotalMark = total.ToString();
                    _context.Update(unitResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitResultExists(unitResult.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");

            }
            return View(unitResult);
        }

        // GET: UnitResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitResult = await _context.UnitResult
                .SingleOrDefaultAsync(m => m.Id == id);
            if (unitResult == null)
            {
                return NotFound();
            }

            return View(unitResult);
        }

        // POST: UnitResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitResult = await _context.UnitResult.SingleOrDefaultAsync(m => m.Id == id);
            _context.UnitResult.Remove(unitResult);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UnitResultExists(int id)
        {
            return _context.UnitResult.Any(e => e.Id == id);
        }
    }
}
