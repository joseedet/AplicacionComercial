using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Controllers
{
    public class IvasController : Controller
    {
        private readonly IIvaRepository _iva;

        public IvasController(IIvaRepository ivaRepository)
        {

            _iva = ivaRepository;
        }

        // GET: Ivas
        public async Task<IActionResult> Index()
        {
            return View(await _iva.GetAll().ToListAsync());
        }

        // GET: Ivas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iva = await _iva.GetByIdAsync((int)id);
            if (iva == null)
            {
                return NotFound();
            }

            return View(iva);
        }

        // GET: Ivas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ivas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Tarifa,Activo")] Iva iva)
        {
            if (ModelState.IsValid)
            {
                
                await _iva.CreateAsync(iva);
                return RedirectToAction("Index");
            }
            return View(iva);
        }

        // GET: Ivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iva = await _iva.GetByIdAsync((int)id);
            if (iva == null)
            {
                return NotFound();
            }
            return View(iva);
        }

        // POST: Ivas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Tarifa,Activo")] Iva iva)
        {
            if (id != iva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                    await _iva.UpdateAsync(iva);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _iva.ExistAsync(iva.Id))
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
            return View(iva);
        }

        // GET: Ivas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iva = await _iva.GetByIdAsync((int)id);
            if (iva == null)
            {
                return NotFound();
            }
            await _iva.DeleteAsync(iva);
            return RedirectToAction("Index");
            //return View(iva);
        }

        //// POST: Ivas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var iva = await _context.Ivas.FindAsync(id);
        //    _context.Ivas.Remove(iva);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool IvaExists(int id)
        //{
        //    return _context.Ivas.Any(e => e.Id == id);
        //}
    }
}
