using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Controllers
{
    public class MedidasController : Controller
    {
        private readonly IMedidaRepository _medida;

        public MedidasController(IMedidaRepository medidaRepository)
        {
            _medida = medidaRepository;
        }

        // GET: Medidas
        public async Task<IActionResult> Index()
        {
            return View(await _medida.GetAll().ToListAsync());
        }

        // GET: Medidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medida = await _medida.GetByIdAsync((int)id);
                //_context.Medidas
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (medida == null)
            {
                return NotFound();
            }

            return View(medida);
        }

        // GET: Medidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Activo")] Medida medida)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(medida);
                await _medida.CreateAsync(medida);
                return RedirectToAction("Index");
            }
            return View(medida);
        }

        // GET: Medidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medida = await _medida.GetByIdAsync((int)id);
            if (medida == null)
            {
                return NotFound();
            }
            return View(medida);
        }

        // POST: Medidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Activo")] Medida medida)
        {
            if (id != medida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(medida);
                    await _medida.UpdateAsync(medida);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _medida.ExistAsync(medida.Id))
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
            return View(medida);
        }

        // GET: Medidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medida = await _medida.GetByIdAsync((int)id);
                //_context.Medidas
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (medida == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        //// POST: Medidas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var medida = await _context.Medidas.FindAsync(id);
        //    _context.Medidas.Remove(medida);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MedidaExists(int id)
        //{
        //    return _context.Medidas.Any(e => e.Id == id);
        //}
    }
}
