using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Softtech.Data;
using Softtech.Models;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ResManagementDBContext context;
        public BookingRepository(ResManagementDBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<AppointmentViewService>> StudentBookingssAsync(string studentId)
        {
            return await context
                     .TblBookings
                     .Where(a => a.StudentId == studentId)
                     .OrderByDescending(a => a.Date)
                     .ProjectTo<AppointmentViewService>()
                     .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentViewService>> AllStudentBookingstsAsync()
        {
            return await context
                     .TblBookings
                     .OrderByDescending(a => a.Date)
                     .OrderByDescending(a => a.Status == false)
                     .ThenByDescending(a => a.BookingId)
                     .ProjectTo<AppointmentViewService>()
                     .ToListAsync();
        }
        public async Task<IEnumerable<AppointmentViewService>> AllApprovedStudentBookingstsAsync()
        {
            return await context
                     .TblBookings
                     .Where(s => s.Status == true)
                     .OrderByDescending(a => a.Date)
                     .OrderByDescending(a => a.Status == false)
                     .ThenByDescending(a => a.BookingId)
                     .ProjectTo<AppointmentViewService>()
                     .ToListAsync();
        }
        public TblBooking GetBookings(string bookingId)
        {
            return context.TblBookings.FirstOrDefault(a => a.BookingId == bookingId);
        }

        public TblBooking AssignRoomToStudent(TblBooking booking)
        {
            var bookings = context.TblBookings.Attach(booking);
            bookings.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return booking;
        }
    }
}
