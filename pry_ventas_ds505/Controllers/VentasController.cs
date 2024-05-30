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
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
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
            string cad_sql = "EXEC sp_ListarVentas";
            List<Venta> ventas = _context.Ventas.FromSqlRaw(cad_sql).ToList();

            return Json(new { data = ventas });
        }

        [HttpGet]
        public JsonResult Consultar(int ID_Venta)
        {
            string cad_sql = "EXEC sp_ConsultarVentaPorID @ID_Venta";
            Venta venta = _context.Ventas
                             .FromSqlRaw(cad_sql, new SqlParameter("@ID_Venta", ID_Venta))
                             .AsEnumerable()
                             .FirstOrDefault();

            return Json(venta);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Venta venta)
        {
            bool rpta = true;

            try
            {
                Venta tmp_venta = _context.Ventas
                                  .FirstOrDefault(v => v.ID_Venta == venta.ID_Venta);

                if (tmp_venta == null)
                {
                    _context.Ventas.Add(venta);
                }
                else
                {
                    tmp_venta.ID_Cliente = venta.ID_Cliente;
                    tmp_venta.FechaVenta = venta.FechaVenta;
                    tmp_venta.TotalVenta = venta.TotalVenta;
                    tmp_venta.MetodoPago = venta.MetodoPago;
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
        public JsonResult Borrar(int ID_Venta)
        {
            bool rpta = true;

            try
            {
                Venta venta = _context.Ventas
                             .FirstOrDefault(v => v.ID_Venta == ID_Venta);

                if (venta != null)
                {
                    _context.Ventas.Remove(venta);
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
