using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPerfilAcesso.Data;
using WebPerfilAcesso.Models;

namespace WebPerfilAcesso.Controllers
{
    public class teste : Controller
    {
        private readonly ApplicationDbContext _context;

        public teste(ApplicationDbContext context )
        {
            _context = context;
        }

        //GET:TipoUsuarios
        public async Task<IActionResult> Index()
        {
            var tiposUsuarios = await _context.TiposUsuarios.ToListAsync();
            return View(tiposUsuarios);
        }

        //
    }
}
