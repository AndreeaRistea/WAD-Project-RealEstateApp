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
    //[Authorize(Roles = "Administrator, User")]
    public class AnnouncementsController : Controller
    {
        /*private readonly EstateContext _estateService;

        public AnnouncementsController(EstateContext context)
        {
            _estateService = context;
        }

        // GET: Announcements
        public async Task<IActionResult> Index()
        {
            var estateContext = _estateService.Announcements.Include(a => a.EstateType).Include(a => a.User);
            return View(await estateContext.ToListAsync());
        }

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _estateService.Announcements == null)
            {
                return NotFound();
            }

            var announcement = await _estateService.Announcements
                .Include(a => a.EstateType)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnnouncementId == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // GET: Announcements/Create
        public IActionResult Create()
        {
            ViewData["EstateTypeId"] = new SelectList(_estateService.EstateTypes, "EstateId", "EstateId");
            ViewData["CustomerId"] = new SelectList(_estateService.Users, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnnouncementId,EstateTypeId,CustomerId,PublishingDate")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _estateService.Add(announcement);
                await _estateService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstateTypeId"] = new SelectList(_estateService.EstateTypes, "EstateId", "EstateId", announcement.EstateTypeId);
            ViewData["CustomerId"] = new SelectList(_estateService.Users, "CustomerId", "CustomerId", announcement.CustomerId);
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _estateService.Announcements == null)
            {
                return NotFound();
            }

            var announcement = await _estateService.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            ViewData["EstateTypeId"] = new SelectList(_estateService.EstateTypes, "EstateId", "EstateId", announcement.EstateTypeId);
            ViewData["CustomerId"] = new SelectList(_estateService.Users, "CustomerId", "CustomerId", announcement.CustomerId);
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnnouncementId,EstateTypeId,CustomerId,PublishingDate")] Announcement announcement)
        {
            if (id != announcement.AnnouncementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _estateService.Update(announcement);
                    await _estateService.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.AnnouncementId))
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
            ViewData["EstateTypeId"] = new SelectList(_estateService.EstateTypes, "EstateId", "EstateId", announcement.EstateTypeId);
            ViewData["CustomerId"] = new SelectList(_estateService.Users, "CustomerId", "CustomerId", announcement.CustomerId);
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _estateService.Announcements == null)
            {
                return NotFound();
            }

            var announcement = await _estateService.Announcements
                .Include(a => a.EstateType)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnnouncementId == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_estateService.Announcements == null)
            {
                return Problem("Entity set 'EstateContext.Announcements'  is null.");
            }
            var announcement = await _estateService.Announcements.FindAsync(id);
            if (announcement != null)
            {
                _estateService.Announcements.Remove(announcement);
            }
            
            await _estateService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
          return (_estateService.Announcements?.Any(e => e.AnnouncementId == id)).GetValueOrDefault();
        }*/
        private readonly AnnouncementService _announcementService;

        public AnnouncementsController(AnnouncementService announcementService)
        {
			_announcementService = announcementService;
        }

        // GET: Announcements
        public IActionResult Index()
        {
            var estateContext = _announcementService.GetAllAnnouncements();
            var status = _announcementService.GetAllStatus();
            var estateTypes = _announcementService.GetAllEstateTypes();
            ViewData["StatusId"] = new SelectList(status, "StatusId", "StatusName");
            ViewData["EstateTypeId"] = new SelectList(estateTypes, "EstateTypeId", "EstateTypeName");
            //return View();
            return View(estateContext);
        }

        // GET: Announcements/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = _announcementService.GetAnnouncementAndRelatedById(id.Value);
             
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // GET: Announcements/Create
        public IActionResult Create()
        {
            var status = _announcementService.GetAllStatus();
            var estateTypes = _announcementService.GetAllEstateTypes();
            ViewData["StatusId"] = new SelectList(status, "StatusId", "StatusName");
            ViewData["EstateTypeId"] = new SelectList(estateTypes, "EstateTypeId", "EstateTypeName");
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AnnouncementId,EstateTypeId,StatusId,Description,AuthorName, DataContact")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                TempData["AnnouncementAdd"] = "Anuntul dvs a fost trimis! Veti fi contactat in curand de noi!";
                //announcement.PublishingDate = announcement.PublishingDate.ToUniversalTime();
                _announcementService.AddAnnouncement(announcement);
                return RedirectToAction(nameof(Index),"Home");
            }
            var status = _announcementService.GetAllStatus();
            var estateTypes = _announcementService.GetAllEstateTypes();
            ViewData["StatusId"] = new SelectList(status, "StatusId", "StatusName", announcement.StatusId);
            ViewData["EstateTypeId"] = new SelectList(estateTypes, "EstateTypeId", "EstateTypeName", announcement.EstateTypeId);
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = _announcementService.GetAnnouncementById(id.Value);
            if(_announcementService == null )
            {
                return NotFound();
            }
            var status = _announcementService.GetAllStatus();
            var estateTypes = _announcementService.GetAllEstateTypes();
            ViewData["StatusId"] = new SelectList(status, "StatusId", "StatusName", announcement.StatusId);
            ViewData["EstateTypeId"] = new SelectList(estateTypes, "EstateTypeId", "EstateTypeName", announcement.EstateTypeId);
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AnnouncementId,EstateTypeId,StatusId,Description,AuthorName, DataContact")] Announcement announcement)
        {
            if (id != announcement.AnnouncementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					_announcementService.UpdateAnnouncement(announcement);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_announcementService.AnnouncementExists(id))
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
            var status = _announcementService.GetAllStatus();
            var estateTypes = _announcementService.GetAllEstateTypes();
            ViewData["StatusId"] = new SelectList(status, "StatusId", "StatusName", announcement.StatusId);
            ViewData["EstateTypeId"] = new SelectList(estateTypes, "EstateTypeId", "EstateTypeName", announcement.EstateTypeId);
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = _announcementService.GetAnnouncementAndRelatedById(id.Value);

            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var announcement = _announcementService.GetAnnouncementById(id);
            if (announcement != null)
            {
				_announcementService.DeleteAnnouncement(id);
            }
            return RedirectToAction(nameof(Index));
        }

        /*private bool AnnouncementExists(int id)
        {
          return (_announcementService.GetAllAnnouncements().Any(e => e.AnnouncementId == id));
        }*/
    }
}
