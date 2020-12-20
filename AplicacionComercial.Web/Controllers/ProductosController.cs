using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;
using AplicacionComercial.Web.Models;

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
        private readonly IConverterHelper _convertHelper;


        public ProductosController(/*DataContext context*/ICombosHelper combosHelper,
            IProductoRepository productoRepository,IMedidaRepository medidaRepository,
            IIvaRepository iva,IDepartamentoRepository departamentoRepository,
            IConverterHelper converterHelper)
        {
            _combosHelper = combosHelper;
            _producto = productoRepository;
            _medida = medidaRepository;
            _iva = iva;
            _departamento = departamentoRepository;
            _convertHelper = converterHelper;

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
            ProductoViewModel model = new ProductoViewModel
            {
                Activo = true
            };

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
        public async Task<IActionResult> Create(ProductoViewModel model)
        {

            if (ModelState.IsValid)
            {
                Producto producto = await _convertHelper.ToProductAsync(model, true);
                await _producto.CreateAsync(producto);
               
                return RedirectToAction("Index");
            }
            //ViewData["Iddepartamento"] = new SelectListItem("Id",_combosHelper.GetComboDepartamento.;
            ViewData["Iddepartamento"] = new SelectList(_departamento.GetAll(),"Id","Descripcion",model.Iddepartamento);
            //ViewData["Iddepartamento"] = new SelectList(_context.Departamentos, "Id", "Descripcion", producto.Iddepartamento);
            //ViewData["Idiva"] = _combosHelper.GetComboIva();
            ViewData["Idiva"] = new SelectList(_iva.GetAll(),"Id","Descripcion",model.Idiva);
            //ViewData["Idmedida"] = _combosHelper.GetComboMedida();
            ViewData["Idmedida"] = new SelectList(_medida.GetAll(),"Id","Descripcion",model.Idmedida);//, "Descripcion", producto.Idmedida);
            return View(model);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _producto.GetByIdAsync((int)id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Iddepartamento"] = new SelectList(_departamento.GetAll(), "Id", "Descripcion", producto.Iddepartamento);
            ViewData["Idiva"] = new SelectList(_iva.GetAll(), "Id", "Descripcion", producto.Idiva);
            ViewData["Idmedida"] = new SelectList(_medida.GetAll(), "Id", "Descripcion", producto.Idmedida);
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
                    
                    await _producto.UpdateAsync(producto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _producto.ExistAsync(producto.Id))
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producto producto = await _producto.GetProductoById((int)id);
            if (producto == null)
            {
                return NotFound();
            }
            await _producto.DeleteAsync(producto);
            return RedirectToAction("Index");
            //return View(departamento);
        }


    }
}
