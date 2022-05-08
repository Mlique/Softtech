using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class DepositsController : Controller
    {
        private readonly ResManagementDBContext connContext;
        public DepositsController(ResManagementDBContext connContext)
        {
            this.connContext = connContext;
        }

        public IActionResult ListOfDeposits()
        {
            var depositList = connContext.TblDeposits;
            return View(depositList);
        }
        [HttpGet]
        public IActionResult AddDeposits()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDeposits([Bind("DepositId, Amount, Date, StudentId, AdminId")] TblDeposit deposit)
        {
            if (ModelState.IsValid)
            {
                connContext.Add(deposit);
                await connContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deposit);
        }
        [HttpGet]

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deposit = await connContext.TblDeposits
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.DepositId == id);
            if (deposit == null)
            {
                return NotFound();
            }
            return View(deposit);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var depositToUpdate = await connContext.TblDeposits
                      .FirstOrDefaultAsync(d => d.DepositId == id);
            if (await TryUpdateModelAsync<TblDeposit>(depositToUpdate,
            "",
            d => d.Amount, d => d.Date, d => d.StudentId))
            {
                try
                {
                    await connContext.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Write Anything Here");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(depositToUpdate);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deposit = await connContext.TblDeposits
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.DepositId == id);
            if (deposit == null)
            {
                return NotFound();
            }
            return View(deposit);
        }
        public IActionResult Delete(string Id)
        {
            TblDeposit deposit = connContext.TblDeposits.Find(Id);
            if (deposit != null)
            {
                connContext.TblDeposits.Remove(deposit);
                connContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(deposit);
        }
    }
}
