using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AplicacionComercial.Web.Controllers
{
    [Authorize(Roles = "SuperUser")]
    public class ConceptosController : Controller
    {
        //private readonly DataContext _context;
        private readonly IConcepto _concepto;

        public ConceptosController(IConcepto concepto/*DataContext context*/)
        {
            // _context = context;
            _concepto = concepto;

        }

        // GET: Conceptos
        public async Task<IActionResult> Index()
        {
            return View(await _concepto.GetAll().ToListAsync());
        }

        // GET: Conceptos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _concepto.GetByIdAsync((int)id);
            if (concepto == null)
            {
                return NotFound();
            }

            return View(concepto);
        }

        // GET: Conceptos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conceptos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Activo")] Concepto concepto)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(concepto);
                await _concepto.CreateAsync(concepto);
                return RedirectToAction(nameof(Index));
            }
            return View(concepto);
        }

        // GET: Conceptos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _concepto.GetByIdAsync((int)id);
            if (concepto == null)
            {
                return NotFound();
            }
            return View(concepto);
        }

        // POST: Conceptos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Activo")] Concepto concepto)
        {
            if (id != concepto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(concepto);
                    await _concepto.UpdateAsync(concepto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _concepto.ExistAsync(concepto.Id))
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
            return View(concepto);
        }

        // GET: Conceptos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Concepto concepto = await _concepto.GetByIdAsync((int)id);

             
                //_context.Conceptos
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (concepto == null)
            {
                return NotFound();
            }
            await _concepto.DeleteAsync(concepto);
            return RedirectToAction("Index");
        }

        // POST: Conceptos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var concepto = await _context.Conceptos.FindAsync(id);
        //    _context.Conceptos.Remove(concepto);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ConceptoExists(int id)
        //{
        //    return _context.Conceptos.Any(e => e.Id == id);
        //}
    }
}
