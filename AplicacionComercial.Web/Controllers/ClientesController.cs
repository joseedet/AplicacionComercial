using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Controllers
{
    public class ClientesController : Controller
    {
        //private readonly DataContext _context;
        IClienteRepository _cliente;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _cliente= clienteRepository;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _cliente.GetAll().ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _cliente.GetByIdAsync((int)id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdtipoDocumento,Documento,NombreComercial,NombresContacto,ApellidosContacto,Direccion,CodPostal,Poblacion,Provincia,Movil,Telefono,Correo,Foto,Notas,Aniversario,Activo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(cliente);
                await _cliente.CreateAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _cliente.GetByIdAsync((int)id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdtipoDocumento,Documento,NombreComercial,NombresContacto,ApellidosContacto,Direccion,CodPostal,Poblacion,Provincia,Movil,Telefono,Correo,Foto,Notas,Aniversario,Activo")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _cliente.UpdateAsync(cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(! await _cliente.ExistAsync(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _cliente.GetByIdAsync((int)id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var cliente = await _context.Clientes.FindAsync(id);
        //    _context.Clientes.Remove(cliente);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ClienteExists(int id)
        //{
        //    return _context.Clientes.Any(e => e.Id == id);
        //}
    }
}
