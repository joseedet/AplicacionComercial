using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace AplicacionComercial.Web.Controllers
{
    [Authorize(Roles = "SuperUser")]
    public class BodegasController : Controller
    {
        private readonly DataContext _context;
        private readonly IBodega _bodega;
        public BodegasController(IBodega bodega, DataContext context)
        {
            _context = context;
            _bodega = bodega;
        }

        // GET: Bodegas
        public async Task<IActionResult> Index()
        {
            return View(await _bodega.GetAll().ToListAsync());
        }

        // GET: Bodegas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _bodega.GetByIdAsync((int)id);
            //await _context.Bodegas
            //.FirstOrDefaultAsync(m => m.Id == id);
            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        // GET: Bodegas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bodegas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Activo")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodega);
                await _bodega.CreateAsync(bodega);
                return RedirectToAction(nameof(Index));
            }
            return View(bodega);
        }

        // GET: Bodegas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _bodega.GetByIdAsync((int)id);
            //_context.Bodegas.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }
            return View(bodega);
        }

        // POST: Bodegas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Activo")] Bodega bodega)
        {
            if (id != bodega.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _bodega.UpdateAsync(bodega);
                    //_context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _bodega.ExistAsync(bodega.Id))
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
            return View(bodega);
        }

        // GET: Bodegas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _bodega.GetByIdAsync((int)id);
            //_context.Bodegas
            //.FirstOrDefaultAsync(m => m.Id == id);
            if (bodega == null)
            {
                return NotFound();
            }

            await _bodega.DeleteAsync(bodega);
            return RedirectToAction("Index");
            //return View(bodega);
        }

        //// POST: Bodegas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var bodega = await _context.Bodegas.FindAsync(id);
        //    _context.Bodegas.Remove(bodega);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
