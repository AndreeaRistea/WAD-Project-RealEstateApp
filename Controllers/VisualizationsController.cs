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
    public class VisualizationsController : Controller
    {
		/*private readonly EstateContext _visualizationService;

        public VisualizationsController(EstateContext context)
        {
            _visualizationService = context;
        }

        // GET: Visualizations
        public async Task<IActionResult> Index()
        {
            var estateContext = _visualizationService.Visualizations.Include(v => v.Estate).Include(v => v.User);
            return View(await estateContext.ToListAsync());
        }

        // GET: Visualizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _visualizationService.Visualizations == null)
            {
                return NotFound();
            }

            var visualization = await _visualizationService.Visualizations
                .Include(v => v.Estate)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.VisualizationId == id);
            if (visualization == null)
            {
                return NotFound();
            }

            return View(visualization);
        }

        // GET: Visualizations/Create
        public IActionResult Create()
        {
            ViewData["EstateId"] = new SelectList(_visualizationService.Estates, "EstateId", "EstateId");
            ViewData["CustomerId"] = new SelectList(_visualizationService.Users, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Visualizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisualizationId,EstateId,CustomerId,AppointmentDate")] Visualization visualization)
        {
            if (ModelState.IsValid)
            {
                _visualizationService.Add(visualization);
                await _visualizationService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstateId"] = new SelectList(_visualizationService.Estates, "EstateId", "EstateId", visualization.EstateId);
            ViewData["CustomerId"] = new SelectList(_visualizationService.Users, "CustomerId", "CustomerId", visualization.CustomerId);
            return View(visualization);
        }

        // GET: Visualizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _visualizationService.Visualizations == null)
            {
                return NotFound();
            }

            var visualization = await _visualizationService.Visualizations.FindAsync(id);
            if (visualization == null)
            {
                return NotFound();
            }
            ViewData["EstateId"] = new SelectList(_visualizationService.Estates, "EstateId", "EstateId", visualization.EstateId);
            ViewData["CustomerId"] = new SelectList(_visualizationService.Users, "CustomerId", "CustomerId", visualization.CustomerId);
            return View(visualization);
        }

        // POST: Visualizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisualizationId,EstateId,CustomerId,AppointmentDate")] Visualization visualization)
        {
            if (id != visualization.VisualizationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _visualizationService.Update(visualization);
                    await _visualizationService.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisualizationExists(visualization.VisualizationId))
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
            ViewData["EstateId"] = new SelectList(_visualizationService.Estates, "EstateId", "EstateId", visualization.EstateId);
            ViewData["CustomerId"] = new SelectList(_visualizationService.Users, "CustomerId", "CustomerId", visualization.CustomerId);
            return View(visualization);
        }

        // GET: Visualizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _visualizationService.Visualizations == null)
            {
                return NotFound();
            }

            var visualization = await _visualizationService.Visualizations
                .Include(v => v.Estate)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.VisualizationId == id);
            if (visualization == null)
            {
                return NotFound();
            }

            return View(visualization);
        }

        // POST: Visualizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_visualizationService.Visualizations == null)
            {
                return Problem("Entity set 'EstateContext.Visualizations'  is null.");
            }
            var visualization = await _visualizationService.Visualizations.FindAsync(id);
            if (visualization != null)
            {
                _visualizationService.Visualizations.Remove(visualization);
            }
            
            await _visualizationService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisualizationExists(int id)
        {
          return (_visualizationService.Visualizations?.Any(e => e.VisualizationId == id)).GetValueOrDefault();
        }*/
		private readonly VisualizationService _visualizationService;

		public VisualizationsController(VisualizationService visualizationService)
		{
			_visualizationService = visualizationService;
		}

        // GET: Visualizations
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
		{
			var estateContext = _visualizationService.GetAllVisualization();
			return View(estateContext);
		}

        // GET: Visualizations/Details/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
          
            var visualization = _visualizationService.GetVisualizationById(id.Value);

			if (visualization == null)
			{
				return NotFound();
			}

			return View(visualization);
		}

        [Authorize(Roles = "User")]
        // GET: Visualizations/Create
        public IActionResult Create()
		{
            //var customers = _visualizationService.GetAllCustomers();
            var estates = _visualizationService.GetAllEstates();
            //ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "LastName");
            ViewData["EstateId"] = new SelectList(estates, "EstateId", "Description");
			return View();
		}

		// POST: Visualizations/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public IActionResult Create([Bind("VisualizationId,EstateId,ClientName,Telephone,AppointmentDate")] Visualization visualization)
		{
			if (ModelState.IsValid)
			{
                visualization.AppointmentDate = visualization.AppointmentDate.ToUniversalTime();
                //  visualization.EstateId = visualization.Estate.EstateId;
                TempData["SuccessVizualization"] = "Vizionare programata cu succes! Vei fi contactat de unul din agentii nostri!";
                _visualizationService.AddVisualization(visualization);
				return RedirectToAction(nameof(Index), "Estates");
			}
            //var customers = _visualizationService.GetAllCustomers();
            var estates = _visualizationService.GetAllEstates();
            //ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "LastName", visualization.CustomerId);
            ViewData["EstateId"] = new SelectList(estates, "EstateId", "Description", visualization.EstateId);
            return View(visualization);
		}

		// GET: Visualizations/Edit/5
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var visualization = _visualizationService.GetVisualizationById(id.Value);

			if (_visualizationService == null)
			{
				return NotFound();
			}
            //var customers = _visualizationService.GetAllCustomers();
            var estates = _visualizationService.GetAllEstates();
            //ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "LastName", visualization.CustomerId);
            ViewData["EstateId"] = new SelectList(estates, "EstateId", "Description", visualization.EstateId);
            return View(visualization);
		}

		// POST: Visualizations/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("VisualizationId,EstateId,ClientName,Telephone,AppointmentDate")] Visualization visualization)
		{
			if (id != visualization.VisualizationId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_visualizationService.UpdateVisualization(visualization);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_visualizationService.VisualizationExists(id))
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
            //var customers = _visualizationService.GetAllCustomers();
            var estates = _visualizationService.GetAllEstates();
            //ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "LastName", visualization.CustomerId);
            ViewData["EstateId"] = new SelectList(estates, "EstateId", "Description", visualization.EstateId);
            return View(visualization);
		}

        // GET: Visualizations/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

            var visualization = _visualizationService.GetVisualizationById(id.Value);

			if (visualization == null)
			{
				return NotFound();
			}

			return View(visualization);
		}

        // POST: Visualizations/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
            var visualization = _visualizationService.GetVisualizationById(id);

			if (visualization != null)
			{
				_visualizationService.DeleteVisualization(id);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
