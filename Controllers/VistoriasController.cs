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
    public class VistoriasController : Controller
    {
        private readonly Context _context;

        public VistoriasController(Context context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Vistorias
        public async Task<IActionResult> Index()
        {
            var context = _context.Vistorias.Include(v => v.Tubulacao);
            return View(await context.ToListAsync());
        }

        // GET: Vistorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vistorias == null)
            {
                return NotFound();
            }

            var vistoria = await _context.Vistorias
                .Include(v => v.Tubulacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vistoria == null)
            {
                return NotFound();
            }

            return View(vistoria);
        }

        // GET: Vistorias/Create
        public IActionResult Create()
        {
            ViewData["TubulacaoId"] = new SelectList(_context.Tubulacoes, "Id", "NomeTubulacao");
            return View();
        }

        // POST: Vistorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TubulacaoId,DataVistoria,UsuarioVistoria,DataReparo,Observação")] Vistoria vistoria)
        {
           // if (ModelState.IsValid)
           // {
                _context.Add(vistoria);
                await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            ViewData["TubulacaoId"] = new SelectList(_context.Tubulacoes, "Id", "NomeTubulacao", vistoria.TubulacaoId);
            // return View(vistoria);
            return RedirectToAction(nameof(Index));
        }

        // GET: Vistorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vistorias == null)
            {
                return NotFound();
            }

            var vistoria = await _context.Vistorias.FindAsync(id);
            if (vistoria == null)
            {
                return NotFound();
            }
            ViewData["TubulacaoId"] = new SelectList(_context.Tubulacoes, "Id", "NomeTubulacao", vistoria.TubulacaoId);
            return View(vistoria);
        }

        // POST: Vistorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TubulacaoId,DataVistoria,UsuarioVistoria,DataReparo,Observação")] Vistoria vistoria)
        {
            if (id != vistoria.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
           // {
                try
                {
                    _context.Update(vistoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VistoriaExists(vistoria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
              //  return RedirectToAction(nameof(Index));
           // }
            ViewData["TubulacaoId"] = new SelectList(_context.Tubulacoes, "Id", "NomeTubulacao", vistoria.TubulacaoId);
            // return View(vistoria);
            return RedirectToAction(nameof(Index));
        }

        // GET: Vistorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vistorias == null)
            {
                return NotFound();
            }

            var vistoria = await _context.Vistorias
                .Include(v => v.Tubulacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vistoria == null)
            {
                return NotFound();
            }

            return View(vistoria);
        }

        // POST: Vistorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vistorias == null)
            {
                return Problem("Entity set 'Context.Vistorias'  is null.");
            }
            var vistoria = await _context.Vistorias.FindAsync(id);
            if (vistoria != null)
            {
                _context.Vistorias.Remove(vistoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VistoriaExists(int id)
        {
          return _context.Vistorias.Any(e => e.Id == id);
        }
    }
}
