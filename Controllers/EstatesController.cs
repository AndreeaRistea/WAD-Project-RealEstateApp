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
    public class EstatesController : Controller
    {
		/* private readonly EstateContext _estateService;

		 public EstatesController(EstateContext context)
		 {
			 _estateService = context;
		 }

		 // GET: Estates
		 public async Task<IActionResult> Index()
		 {
			 var estateContext = _estateService.Estates.Include(e => e.EstateType).Include(e => e.Status);
			 return View(await estateContext.ToListAsync());
		 }

		 // GET: Estates/Details/5
		 public async Task<IActionResult> Details(int? id)
		 {
			 if (id == null || _estateService.Estates == null)
			 {
				 return NotFound();
			 }

			 var estate = await _estateService.Estates
				 .Include(e => e.EstateType)
				 .Include(e => e.Status)
				 .FirstOrDefaultAsync(m => m.EstateId == id);
			 if (estate == null)
			 {
				 return NotFound();
			 }

			 return View(estate);
		 }

		 // GET: Estates/Create
		 public IActionResult Create()
		 {
			 ViewData["EstateTypeId"] = new SelectList(_estateService.EstateTypes, "EstateId", "EstateId");
			 ViewData["StatusId"] = new SelectList(_estateService.Statuses, "StausId", "StausId");
			 return View();
		 }

		 // POST: Estates/Create
		 // To protect from overposting attacks, enable the specific properties you want to bind to.
		 // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		 [HttpPost]
		 [ValidateAntiForgeryToken]
		 public async Task<IActionResult> Create([Bind("EstateId,EstateTypeId,StatusId,Price,City,Description")] Estate estate)
		 {
			 if (ModelState.IsValid)
			 {
				 _estateService.Add(estate);
				 await _estateService.SaveChangesAsync();
				 return RedirectToAction(nameof(Index));
			 }
			 ViewData["EstateTypeId"] = new SelectList(_estateService.EstateTypes, "EstateId", "EstateId", estate.EstateTypeId);
			 ViewData["StatusId"] = new SelectList(_estateService.Statuses, "StausId", "StausId", estate.StatusId);
			 return View(estate);
		 }

		 // GET: Estates/Edit/5
		 public async Task<IActionResult> Edit(int? id)
		 {
			 if (id == null || _estateService.Estates == null)
			 {
				 return NotFound();
			 }

			 var estate = await _estateService.Estates.FindAsync(id);
			 if (estate == null)
			 {
				 return NotFound();
			 }
			 ViewData["EstateTypeId"] = new SelectList(_estateService.EstateTypes, "EstateId", "EstateId", estate.EstateTypeId);
			 ViewData["StatusId"] = new SelectList(_estateService.Statuses, "StausId", "StausId", estate.StatusId);
			 return View(estate);
		 }

		 // POST: Estates/Edit/5
		 // To protect from overposting attacks, enable the specific properties you want to bind to.
		 // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		 [HttpPost]
		 [ValidateAntiForgeryToken]
		 public async Task<IActionResult> Edit(int id, [Bind("EstateId,EstateTypeId,StatusId,Price,City,Description")] Estate estate)
		 {
			 if (id != estate.EstateId)
			 {
				 return NotFound();
			 }

			 if (ModelState.IsValid)
			 {
				 try
				 {
					 _estateService.Update(estate);
					 await _estateService.SaveChangesAsync();
				 }
				 catch (DbUpdateConcurrencyException)
				 {
					 if (!EstateExists(estate.EstateId))
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
			 ViewData["EstateTypeId"] = new SelectList(_estateService.EstateTypes, "EstateId", "EstateId", estate.EstateTypeId);
			 ViewData["StatusId"] = new SelectList(_estateService.Statuses, "StausId", "StausId", estate.StatusId);
			 return View(estate);
		 }

		 // GET: Estates/Delete/5
		 public async Task<IActionResult> Delete(int? id)
		 {
			 if (id == null || _estateService.Estates == null)
			 {
				 return NotFound();
			 }

			 var estate = await _estateService.Estates
				 .Include(e => e.EstateType)
				 .Include(e => e.Status)
				 .FirstOrDefaultAsync(m => m.EstateId == id);
			 if (estate == null)
			 {
				 return NotFound();
			 }

			 return View(estate);
		 }

		 // POST: Estates/Delete/5
		 [HttpPost, ActionName("Delete")]
		 [ValidateAntiForgeryToken]
		 public async Task<IActionResult> DeleteConfirmed(int id)
		 {
			 if (_estateService.Estates == null)
			 {
				 return Problem("Entity set 'EstateContext.Estates'  is null.");
			 }
			 var estate = await _estateService.Estates.FindAsync(id);
			 if (estate != null)
			 {
				 _estateService.Estates.Remove(estate);
			 }

			 await _estateService.SaveChangesAsync();
			 return RedirectToAction(nameof(Index));
		 }

		 private bool EstateExists(int id)
		 {
		   return (_estateService.Estates?.Any(e => e.EstateId == id)).GetValueOrDefault();
		 }*/
		private readonly EstateService _estateService;
       // private readonly IWebHostEnvironment _webHostEnvironment;

        public EstatesController(EstateService estateService)//, IWebHostEnvironment webHostEnvironment)
		{
			_estateService = estateService;
           // _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        // GET: Estates
        public IActionResult Index()
		{
            var estateContext = _estateService.GetAllEstates();
            return View(estateContext);
        }

        [AllowAnonymous]
        public IActionResult IndexRent()
		{
			var estateContext = _estateService.GetAllRentEstates();
			return View(estateContext);
		}

        [AllowAnonymous]
        public IActionResult IndexSale()
		{
			var estateContext = _estateService.GetSaleEstates();
			return View(estateContext);
		}

		// GET: Estates/Details/5
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var estate = _estateService.GetEstateAndRelatedById(id.Value);

			if (estate == null)
			{
				return NotFound();
			}

			return View(estate);
		}

		// GET: Estates/Create
		public IActionResult Create()
		{
            var status = _estateService.GetAllStatuses();
            var estateTypes = _estateService.GetAllEstateTypes();
            ViewData["StatusId"] = new SelectList(status, "StatusId", "StatusName");
            ViewData["EstateTypeId"] = new SelectList(estateTypes, "EstateTypeId", "EstateTypeName");
            return View();
		}

		// POST: Estates/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("EstateId,EstateTypeId,StatusId,Price,City,Address,Description")] Estate estate)
		{
			//if (ModelState.IsValid)
			//{
                _estateService.AddEstate(estate);
				return RedirectToAction(nameof(Index));
			//}
            var status = _estateService.GetAllStatuses();
            var estateTypes = _estateService.GetAllEstateTypes();
            ViewData["StatusId"] = new SelectList(status, "StatusId", "StatusName",estate.StatusId);
            ViewData["EstateTypeId"] = new SelectList(estateTypes, "EstateTypeId", "EstateTypeName",estate.EstateTypeId);
            return View(estate);
		}

        // GET: Estates/Edit/5
        public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var estate = _estateService.GetEstateById(id.Value);
			if (_estateService == null)
			{
				return NotFound();
			}
            var estateType = _estateService.GetAllEstateTypes();
            var status = _estateService.GetAllStatuses();
            ViewData["EstateTypeId"] = new SelectList(estateType, "EstateTypeId", "EstateTypeName", estate.EstateTypeId);
            ViewData["StatusId"] = new SelectList(status, "StatusId", "StatusName", estate.StatusId);
            return View(estate);
		}

		// POST: Estates/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("EstateId,EstateTypeId,StatusId,Price,City,Address,Description")] Estate estate)
		{
			if (id != estate.EstateId)
			{
				return NotFound();
			}

			//if (ModelState.IsValid)
			//{
				try
				{
					_estateService.UpdateEstate(estate);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_estateService.EstateExists(id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			//}
            var estateType = _estateService.GetAllEstateTypes();
            var status = _estateService.GetAllStatuses();
            ViewData["EstateTypeId"] = new SelectList(estateType, "EstateTypeId", "EstateTypeName", estate.EstateTypeId);
            ViewData["StatusId"] = new SelectList(status, "StatusId", "StatusName", estate.StatusId);
            return View(estate);
		}

		// GET: Estates/Delete/5
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var estate = _estateService.GetEstateAndRelatedById(id.Value);

			if (estate == null)
			{
				return NotFound();
			}

			return View(estate);
		}

		// POST: Estates/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var estate = _estateService.GetEstateById(id);
			if (estate != null)
			{
				_estateService.DeleteEstate(id);
			}

			return RedirectToAction(nameof(Index));
		}

	}
}
