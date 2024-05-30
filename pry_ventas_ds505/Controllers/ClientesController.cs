using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pry_ventas_ds505.Data;
using pry_ventas_ds505.Models;

namespace pry_ventas_ds505.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
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
            string cad_sql = "EXEC sp_ListarClientes";
            List<Cliente> arr_clientes = _context.Clientes.FromSqlRaw(cad_sql).ToList();

            return Json(new { data = arr_clientes });
        }

        [HttpGet]
        public JsonResult Consultar(int ID_Cliente)
        {
            string cad_sql = "EXEC sp_ConsultarClientePorID @ID_Cliente";
            Cliente cliente = _context.Clientes
                             .FromSqlRaw(cad_sql, new SqlParameter("@ID_Cliente", ID_Cliente))
                             .AsEnumerable()
                             .FirstOrDefault();

            return Json(cliente);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Cliente cliente)
        {
            bool rpta = true;

            try
            {
                Cliente tmp_cliente = _context.Clientes
                                  .FirstOrDefault(cli => cli.ID_Cliente == cliente.ID_Cliente);

                if (tmp_cliente == null)
                {
                    _context.Clientes.Add(cliente);
                }
                else
                {
                    tmp_cliente.Nombre = cliente.Nombre;
                    tmp_cliente.Apellido = cliente.Apellido;
                    tmp_cliente.Direccion = cliente.Direccion;
                    tmp_cliente.CorreoElectronico = cliente.CorreoElectronico;
                    tmp_cliente.Telefono = cliente.Telefono;
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
        public JsonResult Borrar(int ID_Cliente)
        {
            bool rpta = true;

            try
            {
                Cliente cliente = _context.Clientes
                             .FirstOrDefault(cli => cli.ID_Cliente == ID_Cliente);

                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
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
