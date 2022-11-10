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
    public class TubulacoesController : Controller
    {
        private readonly Context _context;

        public TubulacoesController(Context context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Tubulacoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tubulacoes.ToListAsync());
        }

        // GET: Tubulacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tubulacoes == null)
            {
                return NotFound();
            }

            var tubulacao = await _context.Tubulacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tubulacao == null)
            {
                return NotFound();
            }

            return View(tubulacao);
        }

        // GET: Tubulacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tubulacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTubulacao")] Tubulacao tubulacao)
        {
           // if (ModelState.IsValid)
            //{
                _context.Add(tubulacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
           // return View(tubulacao);
        }

        // GET: Tubulacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tubulacoes == null)
            {
                return NotFound();
            }

            var tubulacao = await _context.Tubulacoes.FindAsync(id);
            if (tubulacao == null)
            {
                return NotFound();
            }
            return View(tubulacao);
        }

        // POST: Tubulacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTubulacao")] Tubulacao tubulacao)
        {
            if (id != tubulacao.Id)
            {
                return NotFound();
            }

           // if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(tubulacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TubulacaoExists(tubulacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
           // return View(tubulacao);
        }

        // GET: Tubulacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tubulacoes == null)
            {
                return NotFound();
            }

            var tubulacao = await _context.Tubulacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tubulacao == null)
            {
                return NotFound();
            }

            return View(tubulacao);
        }

        // POST: Tubulacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tubulacoes == null)
            {
                return Problem("Entity set 'Context.Tubulacoes'  is null.");
            }
            var tubulacao = await _context.Tubulacoes.FindAsync(id);
            if (tubulacao != null)
            {
                _context.Tubulacoes.Remove(tubulacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TubulacaoExists(int id)
        {
          return _context.Tubulacoes.Any(e => e.Id == id);
        }
    }
}
