using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web
{
    public class TipoDocumentosController : Controller
    {
        //private readonly DataContext _context;
        private readonly ITipoDocumento _tipoDocumento;
        public TipoDocumentosController(ITipoDocumento tipoDocumento)
        {
            _tipoDocumento = tipoDocumento;
        }

        // GET: TipoDocumentoes
        public async Task<IActionResult> Index()
        {
            return View(await _tipoDocumento.GetAll().ToListAsync());
        }

        // GET: TipoDocumentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _tipoDocumento.GetByIdAsync((int)id);
                //_context.TiposDocumentos
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // GET: TipoDocumentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(tipoDocumento);
                await _tipoDocumento.CreateAsync(tipoDocumento);
                return RedirectToAction("Index");
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _tipoDocumento.GetByIdAsync((int)id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _tipoDocumento.UpdateAsync(tipoDocumento);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _tipoDocumento.ExistAsync(tipoDocumento.Id))
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
            return View(tipoDocumento);
        }

        // GET: TipoDocumentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TipoDocumento tipoDocumento = await _tipoDocumento.GetByIdAsync((int)id);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            //tipoDocumento = await _tipoDocumento.GetByIdAsync((int)id);

            await _tipoDocumento.DeleteAsync(tipoDocumento);
            return RedirectToAction("Index");
        }

        //// POST: TipoDocumentoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tipoDocumento = await _tipoDocumento.GetByIdAsync((int)id);
        //    await _tipoDocumento.DeleteAsync(tipoDocumento);
        //    //await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        
    }
}
