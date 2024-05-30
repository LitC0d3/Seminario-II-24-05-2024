using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pry_ventas_ds505.Data;
using pry_ventas_ds505.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pry_ventas_ds505.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Listar()
        {
            string cad_sql = "EXEC sp_ListarProductos";
            List<Producto> arr_productos = _context.Productos.FromSqlRaw(cad_sql).ToList();

            return Json(new { data = arr_productos });
        }

        [HttpGet]
        public JsonResult Consultar(int ID_Producto)
        {
            string cad_sql = "EXEC sp_ConsultarProductoPorID @ID_Producto";
            Producto producto = _context.Productos
                             .FromSqlRaw(cad_sql, new SqlParameter("@ID_Producto", ID_Producto))
                             .AsEnumerable()
                             .FirstOrDefault();

            return Json(producto);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Producto producto)
        {
            bool rpta = true;

            try
            {
                Producto tmp_producto = _context.Productos
                                  .FirstOrDefault(prod => prod.ID_Producto == producto.ID_Producto);

                if (tmp_producto == null)
                {
                    _context.Productos.Add(producto);
                }
                else
                {
                    tmp_producto.NombreProducto = producto.NombreProducto;
                    tmp_producto.Descripcion = producto.Descripcion;
                    tmp_producto.Precio = producto.Precio;
                    tmp_producto.Stock = producto.Stock;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }

        [HttpDelete]
        public JsonResult Borrar(int ID_Producto)
        {
            bool rpta = true;

            try
            {
                Producto producto = _context.Productos
                             .FirstOrDefault(prod => prod.ID_Producto == ID_Producto);

                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                }
                else
                {
                    rpta = false;
                }
            }
            catch (Exception)
            {
                rpta = false;
            }

            return Json(new { resultado = rpta });
        }
    }
}
