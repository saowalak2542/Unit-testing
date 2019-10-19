﻿using System.Linq;

namespace TestNinja.Mocking
{
    public class BookingRepository
    {
      public IQueryable<Booking> GetAvtiveBookings(int? excludedBookingId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                .Where(
                    b => b.Status != "Cancelled");

            if(excludedBookingId.HasValue)
                bookings = bookings.Where(b => b.Id != excludedBookingId.Value )


            return bookings;
        }
    }
}
