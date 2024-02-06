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
    [Authorize(Roles = "Administrator, User")]
    public class RequestEstatesController : Controller
    {
		/*private readonly EstateContext _requestEstateService;

        public RequestEstatesController(EstateContext context)
        {
            _requestEstateService = context;
        }

        // GET: RequestEstates
        public async Task<IActionResult> Index()
        {
            var estateContext = _requestEstateService.RequestEstates.Include(r => r.User);
            return View(await estateContext.ToListAsync());
        }

        // GET: RequestEstates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _requestEstateService.RequestEstates == null)
            {
                return NotFound();
            }

            var requestEstate = await _requestEstateService.RequestEstates
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (requestEstate == null)
            {
                return NotFound();
            }

            return View(requestEstate);
        }

        // GET: RequestEstates/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_requestEstateService.Users, "CustomerId", "CustomerId");
            return View();
        }

        // POST: RequestEstates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,CustomerId,PhoneNumber,Details")] RequestEstate requestEstate)
        {
            if (ModelState.IsValid)
            {
                _requestEstateService.Add(requestEstate);
                await _requestEstateService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_requestEstateService.Users, "CustomerId", "CustomerId", requestEstate.CustomerId);
            return View(requestEstate);
        }

        // GET: RequestEstates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _requestEstateService.RequestEstates == null)
            {
                return NotFound();
            }

            var requestEstate = await _requestEstateService.RequestEstates.FindAsync(id);
            if (requestEstate == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_requestEstateService.Users, "CustomerId", "CustomerId", requestEstate.CustomerId);
            return View(requestEstate);
        }

        // POST: RequestEstates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,CustomerId,PhoneNumber,Details")] RequestEstate requestEstate)
        {
            if (id != requestEstate.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _requestEstateService.Update(requestEstate);
                    await _requestEstateService.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestEstateExists(requestEstate.RequestId))
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
            ViewData["CustomerId"] = new SelectList(_requestEstateService.Users, "CustomerId", "CustomerId", requestEstate.CustomerId);
            return View(requestEstate);
        }

        // GET: RequestEstates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _requestEstateService.RequestEstates == null)
            {
                return NotFound();
            }

            var requestEstate = await _requestEstateService.RequestEstates
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (requestEstate == null)
            {
                return NotFound();
            }

            return View(requestEstate);
        }

        // POST: RequestEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_requestEstateService.RequestEstates == null)
            {
                return Problem("Entity set 'EstateContext.RequestEstates'  is null.");
            }
            var requestEstate = await _requestEstateService.RequestEstates.FindAsync(id);
            if (requestEstate != null)
            {
                _requestEstateService.RequestEstates.Remove(requestEstate);
            }
            
            await _requestEstateService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestEstateExists(int id)
        {
          return (_requestEstateService.RequestEstates?.Any(e => e.RequestId == id)).GetValueOrDefault();
        }*/
		private readonly RequestEstateService _requestEstateService;

		public RequestEstatesController(RequestEstateService requestEstateService)
		{
			_requestEstateService = requestEstateService;
		}

		// GET: RequestEstates
		[Authorize(Roles = "Administrator")]
		public IActionResult Index()
		{
			var estateContext = _requestEstateService.GetAllRequestEstate();
			return View(estateContext);
		}

		// GET: RequestEstates/Details/5
		[Authorize(Roles = "Administrator")]
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

           var requestEstate = _requestEstateService.GetRequestEstateTypeById(id.Value);

			if (requestEstate == null)
			{
				return NotFound();
			}

			return View(requestEstate);
		}

        [Authorize(Roles = "User")]
        // GET: RequestEstates/Create
        public IActionResult Create()
		{
			//var customers = _requestEstateService.GetAllCustomers();
			// ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "LastName");
			return View();
		}

		// POST: RequestEstates/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public IActionResult Create([Bind("RequestId,Name,PhoneNumber,Details")] RequestEstate requestEstate)
		{
			if (ModelState.IsValid)
			{
                TempData["RequestAdd"] = "Cererea dvs a fost inregistrata! Veti fi contactat cand va aparea ceva potrivit pentru dvs!";
                _requestEstateService.AddRequestEstate(requestEstate);
				return RedirectToAction(nameof(Index),"Home");
			}
			
			// var customers = _requestEstateService.GetAllCustomers();
			//ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "LastName", requestEstate.CustomerId);
			return View(requestEstate);
		}

		// GET: RequestEstates/Edit/5
		[Authorize(Roles = "Administrator")]
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var requestEstate = _requestEstateService.GetRequestEstateTypeById(id.Value);

			if (_requestEstateService == null)
			{
				return NotFound();
			}
			//var customers = _requestEstateService.GetAllCustomers();
			//ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "LastName", requestEstate.CustomerId);
			return View(requestEstate);
		}

		// POST: RequestEstates/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Administrator")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		
		public IActionResult Edit(int id, [Bind("RequestId,Name,PhoneNumber,Details")] RequestEstate requestEstate)
		{
			if (id != requestEstate.RequestId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_requestEstateService.UpdateRequestEstate(requestEstate);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_requestEstateService.RequestEstateExists(id))
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
			//var customers = _requestEstateService.GetAllCustomers();
			//ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "LastName", requestEstate.CustomerId);
			return View(requestEstate);
		}

		[Authorize(Roles = "Administrator")]
		// GET: RequestEstates/Delete/5
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

           var requestEstate = _requestEstateService.GetRequestEstateTypeById(id.Value);
			if (requestEstate == null)
			{
				return NotFound();
			}

			return View(requestEstate);
		}

		[Authorize(Roles = "Administrator")]
		// POST: RequestEstates/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var requestEstate = _requestEstateService.GetRequestEstateTypeById(id);
			if (requestEstate != null)
			{
				_requestEstateService.DeleteRequestEstate(id);
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
