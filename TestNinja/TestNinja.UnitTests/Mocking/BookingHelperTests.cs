using NUnit.Compatibility;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookibgsExistTests
    {
        private Booking _booking;
        private Mock<IBookingRepository> _repository;

        [setUp]
        public void SetUp()
        {
            _booking = new Booking
            {
                Id = 2,
                ArrivalDate = new DateTime(2017, 1, 15, 14, 0, 0),
                DepartureDate = new DateTime(2017, 1, 20, 10, 0, 0),
                Reference = "a"
            };
            repositry = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(1)).Return(new List<Booking>)
            {
                _booking
           
            }.AsQueryable());
        }
        [Tests]
        public void BookingStartsAndFinishBeforeAnExistingBooking_ReturnEmptyString()
        {

          var result = BookingHelper_OverlappingBookibgsExist(new Booking
          {

                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingBooking.ArrivalDate)
          }, _repository.Object);
               
               Assert.That(result, Is.Empty);
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dataTime.AddDays(-days);
        }
        private DateTime Before(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }
    }
    
}
