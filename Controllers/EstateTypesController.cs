using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AgentieImobiliarWeb.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EstateTypesController : Controller
    {
        /*private readonly EstateContext _estateTypeService;

        public EstateTypesController(EstateContext context)
        {
            _estateTypeService = context;
        }

        // GET: EstateTypes
        public async Task<IActionResult> Index()
        {
              return _estateTypeService.EstateTypes != null ? 
                          View(await _estateTypeService.EstateTypes.ToListAsync()) :
                          Problem("Entity set 'EstateContext.EstateTypes'  is null.");
        }

        // GET: EstateTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _estateTypeService.EstateTypes == null)
            {
                return NotFound();
            }

            var estateType = await _estateTypeService.EstateTypes
                .FirstOrDefaultAsync(m => m.EstateId == id);
            if (estateType == null)
            {
                return NotFound();
            }

            return View(estateType);
        }

        // GET: EstateTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstateTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstateId,EstateTypeName")] EstateType estateType)
        {
            if (ModelState.IsValid)
            {
                _estateTypeService.Add(estateType);
                await _estateTypeService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estateType);
        }

        // GET: EstateTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _estateTypeService.EstateTypes == null)
            {
                return NotFound();
            }

            var estateType = await _estateTypeService.EstateTypes.FindAsync(id);
            if (estateType == null)
            {
                return NotFound();
            }
            return View(estateType);
        }

        // POST: EstateTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstateId,EstateTypeName")] EstateType estateType)
        {
            if (id != estateType.EstateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _estateTypeService.Update(estateType);
                    await _estateTypeService.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstateTypeExists(estateType.EstateId))
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
            return View(estateType);
        }

        // GET: EstateTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _estateTypeService.EstateTypes == null)
            {
                return NotFound();
            }

            var estateType = await _estateTypeService.EstateTypes
                .FirstOrDefaultAsync(m => m.EstateId == id);
            if (estateType == null)
            {
                return NotFound();
            }

            return View(estateType);
        }

        // POST: EstateTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_estateTypeService.EstateTypes == null)
            {
                return Problem("Entity set 'EstateContext.EstateTypes'  is null.");
            }
            var estateType = await _estateTypeService.EstateTypes.FindAsync(id);
            if (estateType != null)
            {
                _estateTypeService.EstateTypes.Remove(estateType);
            }
            
            await _estateTypeService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstateTypeExists(int id)
        {
          return (_estateTypeService.EstateTypes?.Any(e => e.EstateId == id)).GetValueOrDefault();
        }*/
        private readonly EstateTypeService _estateTypeService;
		public EstateTypesController(EstateTypeService estateTypeService)
		{
			_estateTypeService = estateTypeService;
		}

		// GET: EstateTypes
		public IActionResult Index()
		{
            var estateTypes = _estateTypeService.GetAllEstateTypes();
            return View(estateTypes);
		}

		// GET: EstateTypes/Details/5
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

            var estateType = _estateTypeService.GetEstateTypeById(id.Value);

			if (estateType == null)
			{
				return NotFound();
			}

			return View(estateType);
		}

		// GET: EstateTypes/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: EstateTypes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("EstateId,EstateTypeName")] EstateType estateType)
		{
			//if (ModelState.IsValid)
			//{
				_estateTypeService.AddEstateType(estateType);
				return RedirectToAction(nameof(Index));
			//}
			return View(estateType);
		}

		// GET: EstateTypes/Edit/5
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var estateType = _estateTypeService.GetEstateTypeById(id.Value);

			if (estateType == null)
			{
				return NotFound();
			}
			return View(estateType);
		}

		// POST: EstateTypes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("EstateId,EstateTypeName")] EstateType estateType)
		{
			if (id != estateType.EstateTypeId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_estateTypeService.UpdateEstateType(estateType);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_estateTypeService.EstateTypeExists(estateType.EstateTypeId))
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
			return View(estateType);
		}

		// GET: EstateTypes/Delete/5
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var estateType = _estateTypeService.GetEstateTypeById(id.Value);

			if (estateType == null)
			{
				return NotFound();
			}

			return View(estateType);
		}

		// POST: EstateTypes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var estateType = _estateTypeService.GetEstateTypeById(id);
			if (estateType != null)
			{
				_estateTypeService.DeleteEstateType(id);
			}

			return RedirectToAction(nameof(Index));
		}

	}
}
