using AplicacionComercial.Common.Entities;
using AplicacionComercial.Interfaces.ProcedimientosAl;
using AplicacionComercial.Web.Interfaces;
using AplicacionComercial.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Controllers
{
    [Authorize(Roles = "SuperUser")]
    public class ProductosController : Controller
    {
        //private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IProductoRepository _producto;
        private readonly IMedidaRepository _medida;
        private readonly IIvaRepository _iva;
        private readonly IDepartamentoRepository _departamento;
        private readonly IConverterHelper _convertHelper;
        private readonly IBodegaProductoRepository _bodegaproducto;
        private readonly IImagenProducto _imagentProducto;
        private readonly IFileManager _fileManager;
        private readonly IBodega _bodega;
        private readonly IAlmacenProducto _almacenProducto;


        public ProductosController(/*DataContext context*/ICombosHelper combosHelper,
            IProductoRepository productoRepository, IMedidaRepository medidaRepository,
            IIvaRepository iva, IDepartamentoRepository departamentoRepository,
            IConverterHelper converterHelper, IBodegaProductoRepository bodegaProductoRepository
            , IImagenProducto imagenProducto, IFileManager fileManager, IBodega bodega, IAlmacenProducto almacenProducto)
        {
            _combosHelper = combosHelper;
            _producto = productoRepository;
            _medida = medidaRepository;
            _iva = iva;
            _departamento = departamentoRepository;
            _convertHelper = converterHelper;
            _bodegaproducto = bodegaProductoRepository;
            _imagentProducto = imagenProducto;
            _fileManager = fileManager;
            _bodega = bodega;
            _almacenProducto = almacenProducto;
            //_context = context;

        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            //var dataContext = _context.Productos.Include(p => p.IddepartamentoNavigation).Include(p => p.IdivaNavigation).Include(p => p.IdmedidaNavigation);


            var data = await _producto.GetIndexResult();
            
            
            return View(data);
        }
        //TODO:Acabar Vistas esta es un index IEnumerable<ImagenProducto>


        public async Task<IActionResult> DetallesImagen(int? id)
        {

            if (id == null)
            {

                return NotFound();
            }
            Producto producto = await _producto.GetProductoDetallesImagenProducto((int)id);

            if (producto == null)
            {

                return NotFound();
            }
            ImagenProductoViewModel imagen = _convertHelper.ToImagenProductViewModel(producto);
            //var imagen=await _convertHelper.toi

            return View(imagen);
        }
        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _producto.GetProductoAlmacen((int)id);
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

            ViewData["Iddepartamento"] = new SelectList(_departamento.GetAll(), "Id", "Descripcion");
            ViewData["Idiva"] = new SelectList(_iva.GetAll(), "Id", "Descripcion");//, "Id", "Descripcion");
            ViewData["Idmedida"] = new SelectList(_medida.GetAll(), "Id", "Descripcion");
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
                Producto producto =  _convertHelper.ToProductAsync(model, true);
                
               var img= await _fileManager.SaveImage(model.Image);
                if (img==string.Empty)
                {
                    ViewData["Iddepartamento"] = new SelectList(_departamento.GetAll(), "Id", "Descripcion", model.Iddepartamento);
                    ViewData["Idiva"] = new SelectList(_iva.GetAll(), "Id", "Descripcion", model.Idiva);
                    ViewData["Idmedida"] = new SelectList(_medida.GetAll(), "Id", "Descripcion", model.Idmedida);
                    return View(model);
                }
                producto.Imagen = img;
                await _producto.CreateAsync(producto);
                

                return RedirectToAction("Index");
            }

            ViewData["Iddepartamento"] = new SelectList(_departamento.GetAll(), "Id", "Descripcion", model.Iddepartamento);
            ViewData["Idiva"] = new SelectList(_iva.GetAll(), "Id", "Descripcion", model.Idiva);
            ViewData["Idmedida"] = new SelectList(_medida.GetAll(), "Id", "Descripcion", model.Idmedida);
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
            ProductoViewModel productoViewModel = _convertHelper.ToProductViewModel(producto);
            //var producto = await _producto.GetByIdAsync((int)id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Iddepartamento"] = new SelectList(_departamento.GetAll(), "Id", "Descripcion", producto.Iddepartamento);
            ViewData["Idiva"] = new SelectList(_iva.GetAll(), "Id", "Descripcion", producto.Idiva);
            ViewData["Idmedida"] = new SelectList(_medida.GetAll(), "Id", "Descripcion", producto.Idmedida);
            return View(productoViewModel);
            //return View ("Index");
        }

        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
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
                return RedirectToAction("Index");
            }
            ViewData["Iddepartamento"] = new SelectList(_departamento.GetAll(), "Id", "Descripcion", producto.Iddepartamento);
            ViewData["Idiva"] = new SelectList(_iva.GetAll(), "Id", "Descripcion", producto.Idiva);
            ViewData["Idmedida"] = new SelectList(_medida.GetAll(), "Id", "Descripcion", producto.Idmedida);
            return View(producto);
        }
        //GET Producto/AddBodegaProducto

        public IActionResult AddBodegaProducto(int id)
        {
            //TODO:Cambiar modelo a bodegaproducto
            ProductoAlmacenViewModel productoAlmacenViewModel = new ProductoAlmacenViewModel
            {
                Minimo = 1,
                Idproducto = id

            };

            ViewData["Idbodega"] = new SelectList(_bodega.GetAll(), "Id", "Descripcion");
            //ViewData["Idiva"] = new SelectList(_iva.GetAll(), "Id", "Descripcion");//, "Id", "Descripcion");
            //ViewData["Idmedida"] = new SelectList(_medida.GetAll(), "Id", "Descripcion");
            return View(productoAlmacenViewModel);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBodegaProducto(ProductoAlmacenViewModel productoAlmacenViewModel)
        {
            BodegaProducto bodegaProducto = _convertHelper.ToAlmacenProducto(productoAlmacenViewModel, true);

            if (!ModelState.IsValid)
            {

                try
                {
                    await _bodegaproducto.CreateAsync(bodegaProducto);
                    //await _almacenProducto.Agregar("",bodegaProducto);
                    return RedirectToAction("Details", "Productos", new { id = bodegaProducto.Idproducto });

                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await _bodegaproducto.ExistAsync(bodegaProducto.Idbodega, bodegaProducto.Idproducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            ViewData["Idbodega"] = new SelectList(_bodega.GetAll(), "Id", "Descripcion");
            return View(productoAlmacenViewModel);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImagenProducto(AddImagenProducto model)
        {

            if (ModelState.IsValid)
            {
                //ImagenProducto imagenProducto = _convertHelper.ToImagenProducto(model);
               var guid= await _fileManager.SaveImage(model.Image);
                var imagen = new
                    AddImagenProducto
                {
                    ProductoId = model.ProductoId,
                    ImageId = guid
                };
               ////model.ImageId =guid;
               await _imagentProducto.CreateAsync(imagen);
                return View(imagen);
            }
            else
            {
                return View(model);

            }
            
        }
        //GET
        [HttpGet]
        public async Task<IActionResult> AddImagenProducto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = await _producto.GetByIdAsync((int)id);

            var imagen = new
                AddImagenProducto
            {
                ProductoId = producto.Id,
                 

            };
            //AddImagenProducto imagenProducto =(AddImagenProducto) _convertHelper.ToImagenProducto(producto);
            //ImagenProductoViewModel imagenProduct = _convertHelper.ToImagenProductViewModel(producto);
            return View(imagen);
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


        public async Task<IActionResult> ImagenDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var ids=(int)id;

            ImagenProducto imagenProducto = await _imagentProducto.GetByIdAsync((int)id);

            if (imagenProducto == null)
            {
                return NotFound();

            }
            await _imagentProducto.DeleteAsync(imagenProducto);
            return RedirectToAction("Index");
        }

    }
}
