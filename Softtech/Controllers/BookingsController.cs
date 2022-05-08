using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using Softtech.Repositories;
using Softtech.Services;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class BookingsController : BaseController
    {
        private readonly ResManagementDBContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBookingRepository bookingRepository;
        private readonly IEmailSender emailSender;

        public BookingsController(ResManagementDBContext context, UserManager<ApplicationUser> userManager, IBookingRepository bookingRepository, IEmailSender emailSender)
        {
            this.context = context;
            this.userManager = userManager;
            this.bookingRepository = bookingRepository;
            this.emailSender = emailSender;
        }
        public IActionResult Index()
        {
            var bookings = context.TblBookings
                .Where(s => s.Status==false)
                .Include(a => a.Student)
                .Include(b => b.Room).
                Include(c => c.RoomType)
                .OrderByDescending(d => d.Date)
                .AsTracking();
            return View(bookings);
        }
        public async Task<IActionResult> AllBookings()
        {
            var bookingList = context.TblBookings
                   .Include(a => a.Room)
                   .Include(r => r.RoomType)
                   .Include(s => s.Student)
                   .AsNoTracking();

            var bookings = await bookingRepository.AllApprovedStudentBookingstsAsync();
            var BookList = bookings.Select(a => new BookingListViewModel
            {
                CVV = a.CVV,
                Year = a.Year,
                Date = DateTime.Now,
                Status = a.Status,
                PayAmount = a?.PayAmount ?? "0.00",
                ExpiryYear = a.ExpiryYear,
                CardHolder = a.CardHolder,
                CardNumber = a.CardNumber,
                BursaryName = a?.BursaryName ?? "N/A",
                ExpiryMonth = a.ExpiryMonth,
                ContactNumber = a.ContactNumber,
                StudentFundedBy = a?.StudentFundedBy ?? "N/A",
                TermsAndConditions = a.TermsAndConditions,
                RoomId = a?.Room?.RoomNo ?? "<Not Assigned>",
                RoomTypeId = a?.RoomType?.Name ?? "<Not Assigned>",
                StudentId = a?.Student?.FullName ?? "<Not Transfered>"
            })
            .ToList();

            return View(BookList);
        }
        public async Task<IActionResult> ListOfBookings()
        {

            var bookingList = context.TblBookings
                 .Include(a => a.Room)
                 .Include(r => r.RoomType)
                 .Include(s => s.Student)
                 .AsNoTracking();

            var bookings = await bookingRepository.AllStudentBookingstsAsync();
            var BookList = bookings.Select(a => new BookingListViewModel
            {
                CVV = a.CVV,
                Year = a.Year,
                Date = DateTime.Now,
                Status = a.Status,
                PayAmount = a?.PayAmount ?? "0.00",
                ExpiryYear = a.ExpiryYear,
                CardHolder = a.CardHolder,
                CardNumber = a.CardNumber,
                BursaryName = a?.BursaryName ?? "N/A",
                ExpiryMonth = a.ExpiryMonth,
                ContactNumber = a.ContactNumber,
                StudentFundedBy = a?.StudentFundedBy ?? "N/A",
                TermsAndConditions = a.TermsAndConditions,
                RoomId = a?.Room?.RoomNo ?? "<Not Assigned>",
                RoomTypeId = a?.RoomType?.Name ?? "<Not Assigned>",
                StudentId = a?.Student?.FullName ?? "<Not Transfered>"
            })
            .ToList();

            return View(BookList);
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
            {
                PopulateRoomTypeDropDownList();
                return View(new BookingViewModel());
            }
            else
            {
                PopulateRoomTypeDropDownList();
                var cities = await context.TblBookings.FindAsync(id);
                if (cities == null)
                {
                    return NotFound();
                }
                return View(cities);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, BookingViewModel model)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            PopulateRoomTypeDropDownList();
            if (ModelState.IsValid)
            {
                PopulateRoomTypeDropDownList();
                var getMyBookings = context.TblBookings.Find(id);

                if (id == null)
                {
                    try
                    {
                        var booking = new TblBooking
                        {
                            CVV = model.CVV,
                            Year = model.Year,
                            Date = DateTime.Now,
                            Status = model.Status,
                            StudentId = currentUser.Id,
                            PayAmount = model.PayAmount,
                            ExpiryYear = model.ExpiryYear,
                            CardHolder = model.CardHolder,
                            CardNumber = model.CardNumber,
                            RoomTypeId = model.RoomTypeId,
                            BursaryName = model.BursaryName,
                            ExpiryMonth = model.ExpiryMonth,
                            ContactNumber = model.ContactNumber,
                            StudentFundedBy = model.StudentFundedBy,
                            TermsAndConditions = model.TermsAndConditions
                        };
                        PopulateRoomTypeDropDownList(booking.RoomTypeId);
                        context.Add(booking);
                        await context.SaveChangesAsync();
                        Notify("Your bookings was successfully");
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
                        model.CVV = getMyBookings.CVV;
                        model.Date = getMyBookings.Date;
                        model.Year = getMyBookings.Year;
                        model.Status = getMyBookings.Status;
                        model.StudentId = getMyBookings.StudentId;
                        model.PayMethod = getMyBookings.PayMethod;
                        model.RoomTypeId = getMyBookings.RoomTypeId;
                        model.CardNumber = getMyBookings.CardNumber;
                        model.ExpiryYear = getMyBookings.ExpiryYear;
                        model.CardHolder = getMyBookings.CardHolder;
                        model.BursaryName = getMyBookings.BursaryName;
                        model.ExpiryMonth = getMyBookings.ExpiryMonth;
                        model.ContactNumber = getMyBookings.ContactNumber;
                        model.TermsAndConditions = getMyBookings.TermsAndConditions;

                        PopulateRoomTypeDropDownList(model.RoomTypeId);
                        context.Update(model);
                        await context.SaveChangesAsync();
                        Notify("Your bookings details was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(model.BookingId))
                        {
                            return NotFound();
                        }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(StudentsController.Index), "Students");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AssignRoom(string id, AssignRoomToStudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateRoomDropDownList();
                PopulateRoomTypeDropDownList();
                GetStudentByName();

                var stud = bookingRepository.GetBookings(id);
                if (stud != null)
                {
                    model.StudentId = stud.StudentId;
                    model.RoomId = stud.RoomId;
                    model.RoomTypeId = stud.RoomTypeId;
                    model.Status = stud.Status;
                    model.PayAmount = stud.PayAmount;
                    model.BursaryName = stud?.BursaryName ?? "N/A";
                    model.Date = stud.Date;
                    model.Year = stud.Year;
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoom(AssignRoomToStudentViewModel model, string id)
        {

            if (!ModelState.IsValid)
            {
                PopulateRoomDropDownList();
                PopulateRoomTypeDropDownList();
                GetStudentByName();

                var stud = bookingRepository.GetBookings(id);
                if (stud != null)
                {
                    stud.RoomTypeId = model.RoomTypeId;
                    stud.RoomId = model.RoomId;
                    stud.Status = true;

                    PopulateRoomDropDownList(stud.RoomId);
                    PopulateRoomTypeDropDownList(stud.RoomTypeId);
                    bookingRepository.AssignRoomToStudent(stud);
                }
                ApplicationUser userr = await userManager.FindByIdAsync(stud.StudentId);
                model = new AssignRoomToStudentViewModel
                {
                    Email = userr.Email
                };


                var ctokenlink = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = stud.StudentId
                }, protocol: HttpContext.Request.Scheme);

                await emailSender.SendEmailAssigningRoomsAsync(userr.Email, ctokenlink);
                Notify("Room has been assigned successfully");
                return RedirectToAction(nameof(BookingsController.ListOfBookings), "Bookings");
            }
            return View();
        }
        private async Task<IEnumerable<SelectListItem>> GetDoctorsListItemsAsync()
        {
            List<ViewModelUserRole> students = new List<ViewModelUserRole>();
            var stud = await userManager.GetUsersInRoleAsync("Student");
            var studentListItems = stud.Select(st => new SelectListItem
            {
                Text = $"Dr. {st.LastName}",
                Value = st.Id
            })
            .ToList();

            return studentListItems;
        }

        public async Task<IActionResult> Delete(string id)
        {
            var booking = await context.TblBookings.FindAsync(id);
            try
            {
                if (id != null)
                {
                    PopulateRoomDropDownList(booking.RoomId);
                    PopulateRoomTypeDropDownList(booking.RoomTypeId);
                    context.TblBookings.Remove(booking);
                    await context.SaveChangesAsync();
                    Notify("Your booking was declined successfully");
                }
            }
            catch (Exception)
            {
                Notify("Your booking is in process could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(ListOfBookings));
        }

        private bool ModelExists(string id)
        {
            return context.TblBookings.Any(e => e.BookingId == id);
        }

        private void PopulateRoomTypeDropDownList(object selectedRoom = null)
        {
            var roomQuery = from d in context.TblRoomTypes.Distinct().AsNoTracking()
                            orderby d.Name
                            select d;
            ViewBag.RoomTypeId = new SelectList(roomQuery.AsNoTracking(), "RoomTypeId", "Name",
            selectedRoom);
        }
        private void PopulateRoomDropDownList(object selectedRoom = null)
        {
            var roomQuery = from d in context.TblRooms
                            orderby d.RoomNo
                            select d;
            ViewBag.RoomId = new SelectList(roomQuery.AsNoTracking(), "RoomId", "RoomNo",
            selectedRoom);
        }
        private void GetStudentByName(object selectedStudent = null)
        {
            var studentQuery = from d in context.tblApplicationUser
                               orderby d.LastName
                               select d;
            ViewBag.StudentId = new SelectList(studentQuery.AsNoTracking(), "Id", "LastName",
            selectedStudent);
        }
    }
}