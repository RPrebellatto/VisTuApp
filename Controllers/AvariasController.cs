using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisTuApp.Data;
using VisTuApp.Models;

namespace VisTuApp.Controllers
{
    public class AvariasController : Controller
    {
        private readonly Context _context;

        public AvariasController(Context context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Avarias
        public async Task<IActionResult> Index()
        {
            var context = _context.Avarias.Include(a => a.Tubulacao);
            return View(await context.ToListAsync());
        }

        // GET: Avarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Avarias == null)
            {
                return NotFound();
            }

            var avaria = await _context.Avarias
                .Include(a => a.Tubulacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaria == null)
            {
                return NotFound();
            }

            return View(avaria);
        }

        // GET: Avarias/Create
        public IActionResult Create()
        {
            ViewData["TubulacaoId"] = new SelectList(_context.Tubulacoes, "Id", "NomeTubulacao");
            return View();
        }

        // POST: Avarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeAvaria,Grau,Descricao,TubulacaoId")] Avaria avaria)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(avaria);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            //}
            ViewData["TubulacaoId"] = new SelectList(_context.Tubulacoes, "Id", "NomeTubulacao", avaria.TubulacaoId);
            //return View(avaria);
            return RedirectToAction(nameof(Index));
        }

        // GET: Avarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Avarias == null)
            {
                return NotFound();
            }

            var avaria = await _context.Avarias.FindAsync(id);
            if (avaria == null)
            {
                return NotFound();
            }
            ViewData["TubulacaoId"] = new SelectList(_context.Tubulacoes, "Id", "NomeTubulacao", avaria.TubulacaoId);
            return View(avaria);
        }

        // POST: Avarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeAvaria,Grau,Descricao,TubulacaoId")] Avaria avaria)
        {
            if (id != avaria.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(avaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvariaExists(avaria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               // return RedirectToAction(nameof(Index));
           // }
            ViewData["TubulacaoId"] = new SelectList(_context.Tubulacoes, "Id", "NomeTubulacao", avaria.TubulacaoId);
            //return View(avaria);
            return RedirectToAction(nameof(Index));
        }

        // GET: Avarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Avarias == null)
            {
                return NotFound();
            }

            var avaria = await _context.Avarias
                .Include(a => a.Tubulacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaria == null)
            {
                return NotFound();
            }

            return View(avaria);
        }

        // POST: Avarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Avarias == null)
            {
                return Problem("Entity set 'Context.Avarias'  is null.");
            }
            var avaria = await _context.Avarias.FindAsync(id);
            if (avaria != null)
            {
                _context.Avarias.Remove(avaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvariaExists(int id)
        {
          return _context.Avarias.Any(e => e.Id == id);
        }
    }
}
