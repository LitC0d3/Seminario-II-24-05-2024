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
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
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
            string cad_sql = "EXEC sp_ListarEmpleados";
            List<Empleado> empleados = _context.Empleados.FromSqlRaw(cad_sql).ToList();

            return Json(new { data = empleados });
        }

        [HttpGet]
        public JsonResult Consultar(int ID_Empleado)
        {
            string cad_sql = "EXEC sp_ConsultarEmpleadoPorID @ID_Empleado";
            Empleado empleado = _context.Empleados
                                  .FromSqlRaw(cad_sql, new SqlParameter("@ID_Empleado", ID_Empleado))
                                  .AsEnumerable()
                                  .FirstOrDefault();

            return Json(empleado);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Empleado empleado)
        {
            bool rpta = true;

            try
            {
                Empleado tmp_empleado = _context.Empleados
                                  .FirstOrDefault(emp => emp.ID_Empleado == empleado.ID_Empleado);

                if (tmp_empleado == null)
                {
                    _context.Empleados.Add(empleado);
                }
                else
                {
                    tmp_empleado.Nombre = empleado.Nombre;
                    tmp_empleado.Apellido = empleado.Apellido;
                    tmp_empleado.Cargo = empleado.Cargo;
                    tmp_empleado.Salario = empleado.Salario;
                    tmp_empleado.FechaContratacion = empleado.FechaContratacion;
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
        public JsonResult Borrar(int ID_Empleado)
        {
            bool rpta = true;

            try
            {
                Empleado empleado = _context.Empleados
                                  .FirstOrDefault(emp => emp.ID_Empleado == ID_Empleado);

                if (empleado != null)
                {
                    _context.Empleados.Remove(empleado);
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
