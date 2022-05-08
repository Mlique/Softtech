using Microsoft.AspNetCore.Identity;
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
    public class RoomTypeController : BaseController
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public RoomTypeController(ResManagementDBContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var roomList = context.TblRoomTypes;
            return View(roomList);
        }
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
            {
                return View(new TblRoomType());
            }
            else
            {
                var rooms = await context.TblRoomTypes.FindAsync(id);
                if (rooms == null)
                {
                    return NotFound();
                }
                return View(rooms);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, [Bind("RoomTypeId, Name")] TblRoomType room)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    try
                    {
                        context.Add(room);
                        await context.SaveChangesAsync();
                        Notify("Your room was save successfully");
                        return RedirectToAction(nameof(RoomTypeController.Index), "RoomType");
                    }
                    catch (Exception)
                    {
                        Notify("Something went wrong please you provided all necessary info", notificationType: NotificationType.error);
                        return View();
                    }
                }
                else
                {
                    try
                    {
                        context.Update(room);
                        await context.SaveChangesAsync();
                        Notify("Your room details was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(room.RoomTypeId))
                        {
                            return NotFound();
                        }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(RoomTypeController.Index), "RoomType");
            }
            return View(room);
        }
       
        public async Task<IActionResult> Delete(string id)
        {
            var room = await context.TblRoomTypes.FindAsync(id);
            try
            {
                if (id != null)
                {
                    context.TblRoomTypes.Remove(room);
                    Notify("Your room was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify("Your room is in process could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(string id)
        {
            return context.TblRoomTypes.Any(e => e.RoomTypeId == id);
        }
    }
}
