using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AplicacionComercial.Web.Controllers
{
    [Authorize(Roles = "SuperUser")]
    public class DepartamentosController : Controller
    {
        //private readonly DataContext _context;
        private readonly IDepartamentoRepository _departamento;
        public DepartamentosController(IDepartamentoRepository departamentoRepository/*DataContext context*/)
        {
            _departamento = departamentoRepository;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            return View(await _departamento.GetAll().ToListAsync());
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _departamento.GetByIdAsync((int)id);
                //_context.Departamentos
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Activo")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(departamento);
                await _departamento.CreateAsync(departamento);
                return RedirectToAction("Index");
            }
            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _departamento.GetByIdAsync((int)id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Activo")] Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try 
                { 
                
                    
                    await _departamento.UpdateAsync(departamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( !await  _departamento.ExistAsync(departamento.Id))
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
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departamento departamento = await _departamento.GetByIdAsync((int)id);
            if (departamento == null)
            {
                return NotFound();
            }
            await _departamento.DeleteAsync(departamento);
            return RedirectToAction("Index");
            //return View(departamento);
        }

        //// POST: Departamentos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var departamento = await _context.Departamentos.FindAsync(id);
        //    _context.Departamentos.Remove(departamento);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

       
    }
}
