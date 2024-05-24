using Microsoft.AspNetCore.Mvc;
using pry_ventas_ds505.Data;
using pry_ventas_ds505.Models;
using System.Collections.Generic;

namespace pry_ventas_ds505.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> listaCategorias = _context.Categoria;

            return View(listaCategorias);
        }
    }
}
