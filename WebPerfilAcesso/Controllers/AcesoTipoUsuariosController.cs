using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPerfilAcesso.Data;
using WebPerfilAcesso.Models;

namespace WebPerfilAcesso.Controllers
{
    public class AcesoTipoUsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcesoTipoUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcesoTipoUsuarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AcessosTiposUsuarios.Include(a => a.TipoUsuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AcesoTipoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acesoTipoUsuario = await _context.AcessosTiposUsuarios
                .Include(a => a.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acesoTipoUsuario == null)
            {
                return NotFound();
            }

            return View(acesoTipoUsuario);
        }

        // GET: AcesoTipoUsuarios/Create
        public IActionResult Create()
        {
            ViewData["IdTipoUsuario"] = new SelectList(_context.TiposUsuarios, "Id", "Id");
            return View();
        }

        // POST: AcesoTipoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFuncionalidade,NomeTipoUsuario")] AcesoTipoUsuario acesoTipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acesoTipoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoUsuario"] = new SelectList(_context.TiposUsuarios, "Id", "Id", acesoTipoUsuario.IdTipoUsuario);
            return View(acesoTipoUsuario);
        }

        // GET: AcesoTipoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acesoTipoUsuario = await _context.AcessosTiposUsuarios.FindAsync(id);
            if (acesoTipoUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdTipoUsuario"] = new SelectList(_context.TiposUsuarios, "Id", "Id", acesoTipoUsuario.IdTipoUsuario);
            return View(acesoTipoUsuario);
        }

        // POST: AcesoTipoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFuncionalidade,NomeTipoUsuario")] AcesoTipoUsuario acesoTipoUsuario)
        {
            if (id != acesoTipoUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acesoTipoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcesoTipoUsuarioExists(acesoTipoUsuario.Id))
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
            ViewData["IdTipoUsuario"] = new SelectList(_context.TiposUsuarios, "Id", "Id", acesoTipoUsuario.IdTipoUsuario);
            return View(acesoTipoUsuario);
        }

        // GET: AcesoTipoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acesoTipoUsuario = await _context.AcessosTiposUsuarios
                .Include(a => a.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acesoTipoUsuario == null)
            {
                return NotFound();
            }

            return View(acesoTipoUsuario);
        }

        // POST: AcesoTipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acesoTipoUsuario = await _context.AcessosTiposUsuarios.FindAsync(id);
            _context.AcessosTiposUsuarios.Remove(acesoTipoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcesoTipoUsuarioExists(int id)
        {
            return _context.AcessosTiposUsuarios.Any(e => e.Id == id);
        }
    }
}
