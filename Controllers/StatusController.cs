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
    public class StatusController : Controller
    {
		/*private readonly EstateContext _statusService;

        public StatusController(EstateContext context)
        {
            _statusService = context;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
              return _statusService.Statuses != null ? 
                          View(await _statusService.Statuses.ToListAsync()) :
                          Problem("Entity set 'EstateContext.Statuses'  is null.");
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _statusService.Statuses == null)
            {
                return NotFound();
            }

            var status = await _statusService.Statuses
                .FirstOrDefaultAsync(m => m.StausId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StausId,StatusName")] Status status)
        {
            if (ModelState.IsValid)
            {
                _statusService.Add(status);
                await _statusService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _statusService.Statuses == null)
            {
                return NotFound();
            }

            var status = await _statusService.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StausId,StatusName")] Status status)
        {
            if (id != status.StausId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _statusService.Update(status);
                    await _statusService.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.StausId))
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
            return View(status);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _statusService.Statuses == null)
            {
                return NotFound();
            }

            var status = await _statusService.Statuses
                .FirstOrDefaultAsync(m => m.StausId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_statusService.Statuses == null)
            {
                return Problem("Entity set 'EstateContext.Statuses'  is null.");
            }
            var status = await _statusService.Statuses.FindAsync(id);
            if (status != null)
            {
                _statusService.Statuses.Remove(status);
            }
            
            await _statusService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(int id)
        {
          return (_statusService.Statuses?.Any(e => e.StausId == id)).GetValueOrDefault();
        }*/
		private readonly StatusService _statusService;

		public StatusController(StatusService statusService)
		{
			_statusService = statusService;
		}

		// GET: Status
		public IActionResult Index()
		{
			var staus = _statusService.GetAllStatus();
            return View(staus);
		}

		// GET: Status/Details/5
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

            var status = _statusService.GetStatusById(id.Value);

			if (status == null)
			{
				return NotFound();
			}

			return View(status);
		}

		// GET: Status/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Status/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("StatusId,StatusName")] Status status)
		{
			if (ModelState.IsValid)
			{
				_statusService.AddStatus(status);
				return RedirectToAction(nameof(Index));
			}
			return View(status);
		}

		// GET: Status/Edit/5
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

            var status = _statusService.GetStatusById(id.Value);
			if (status == null)
			{
				return NotFound();
			}
			return View(status);
		}

		// POST: Status/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("StatusId,StatusName")] Status status)
		{
			if (id != status.StatusId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_statusService.UpdateStatus(status);

				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_statusService.StatusExists(status.StatusId))
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
			return View(status);
		}

		// GET: Status/Delete/5
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var status = _statusService.GetStatusById(id.Value);
			if (status == null)
			{
				return NotFound();
			}

			return View(status);
		}

		// POST: Status/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{

            var status = _statusService.GetStatusById(id);
			if (status != null)
			{
				_statusService.DeleteStatus(id);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
