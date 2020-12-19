using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IProductoRepository _producto;
        private readonly IMedidaRepository _medida;
        private readonly IIvaRepository _iva;
        private readonly IDepartamentoRepository _departamento;

        public ProductosController(/*DataContext context*/ICombosHelper combosHelper,
            IProductoRepository productoRepository,IMedidaRepository medidaRepository,
            IIvaRepository iva,IDepartamentoRepository departamentoRepository)
        {
            _combosHelper = combosHelper;
            _producto = productoRepository;
            _medida = medidaRepository;
            _iva = iva;
            _departamento = departamentoRepository;

            //_context = context;

        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            //var dataContext = _context.Productos.Include(p => p.IddepartamentoNavigation).Include(p => p.IdivaNavigation).Include(p => p.IdmedidaNavigation);
            var data = await _producto.GetIndexResult();
            return View(data);
        }       

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Iddepartamento)
                .Include(p => p.Idiva)
                .Include(p => p.Idmedida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["Iddepartamento"] = new SelectList(_departamento.GetAll(),"Id","Descripcion");
            ViewData["Idiva"] = new SelectList(_iva.GetAll(),"Id","Descripcion");//, "Id", "Descripcion");
            ViewData["Idmedida"] = new SelectList(_medida.GetAll(),"Id", "Descripcion") ;
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _producto.CreateAsync(producto);                
                return RedirectToAction("Index");
            }
            //ViewData["Iddepartamento"] = new SelectListItem("Id",_combosHelper.GetComboDepartamento.;
            ViewData["Iddepartamento"] = new SelectList(_departamento.GetAll(),"Id","Descripcion",producto.Iddepartamento);
            //ViewData["Iddepartamento"] = new SelectList(_context.Departamentos, "Id", "Descripcion", producto.Iddepartamento);
            //ViewData["Idiva"] = _combosHelper.GetComboIva();
            ViewData["Idiva"] = new SelectList(_iva.GetAll(),"Id","Descripcion",producto.Idiva);
            //ViewData["Idmedida"] = _combosHelper.GetComboMedida();
            ViewData["Idmedida"] = new SelectList(_medida.GetAll(),"Id","Descripcion",producto.Idmedida);//, "Descripcion", producto.Idmedida);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Iddepartamento"] = new SelectList(_context.Departamentos, "Id", "Descripcion", producto.Iddepartamento);
            ViewData["Idiva"] = new SelectList(_context.Ivas, "Id", "Descripcion", producto.Idiva);
            ViewData["Idmedida"] = new SelectList(_context.Medidas, "Id", "Descripcion", producto.Idmedida);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Nombre,Iddepartamento,Idiva,Precio,Notas,Idmedida,Medida,Activo")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            ViewData["Iddepartamento"] = new SelectList(_context.Departamentos, "Id", "Descripcion", producto.Iddepartamento);
            ViewData["Idiva"] = new SelectList(_context.Ivas, "Id", "Descripcion", producto.Idiva);
            ViewData["Idmedida"] = new SelectList(_context.Medidas, "Id", "Descripcion", producto.Idmedida);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Iddepartamento)
                .Include(p => p.Idiva)
                .Include(p => p.Idmedida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
