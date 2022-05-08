using Softtech.Models;
using Softtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<AppointmentViewService>> StudentBookingssAsync(string studentId);
        Task<IEnumerable<AppointmentViewService>> AllStudentBookingstsAsync();
        Task<IEnumerable<AppointmentViewService>> AllApprovedStudentBookingstsAsync();
        TblBooking GetBookings(string bookingId);
        TblBooking AssignRoomToStudent(TblBooking booking);
    }
}
