using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class RoomsController : BaseController
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public RoomsController(ResManagementDBContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult ListOfRooms()
        {
            var roomList = context.TblRooms.Include(r => r.RoomType)
                .AsNoTracking();
            return View(roomList);
        }
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            PopulateRoomDropDownList();
            if (id == null)
            {
                return View(new TblRoom());
            }
            else
            {
                var rooms = await context.TblRooms.FindAsync(id);
                if (rooms == null)
                {
                    return NotFound();
                }
                return View(rooms);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, [Bind("RoomId, RoomNo, RoomTypeId, Price, Available")] TblRoom room)
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
                        return RedirectToAction(nameof(RoomsController.ListOfRooms), "Rooms");
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
                        if (!ModelExists(room.RoomId))
                        {
                            return NotFound();
                        }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(RoomsController.ListOfRooms), "Rooms");
            }
            return View(room);
        }
       
        public async Task<IActionResult> Delete(string id)
        {
            var room = await context.TblRooms.FindAsync(id);
            try
            {
                if (id != null)
                {
                    context.TblRooms.Remove(room);
                    Notify("Your room was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify("Your room is in process could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(ListOfRooms));
        }

        private bool ModelExists(string id)
        {
            return context.TblRooms.Any(e => e.RoomId == id);
        }
        private void PopulateRoomDropDownList(object selectedRoom = null)
        {
            var roomQuery = from d in context.TblRoomTypes.Distinct().AsNoTracking()
                            orderby d.Name
                            select d;
            ViewBag.RoomTypeId = new SelectList(roomQuery.AsNoTracking(), "RoomTypeId", "Name",
            selectedRoom);
        }
    }
}
