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
                ArrivalDate = new DateTime(2017, 1, 15, ),
                DepartureDate = new DateTime(2017, 1, 20),
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
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = Before(_ExistingBooking.ArrivalDate)
          }, _repository.Object);
               
               Assert.That(result, Is.Empty);
        }
        [Tests]
        public void BookingStartsBeforeAndFinishesIntheMiddleBeforeAnExistingBooking_ReturnEmptyString()
        {
               var result = BookingHelper_OverlappingBookibgsExist(new Booking
            {

                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = Before(_existingBooking.ArrivalDate)
            }, _repository.Object);

            Assert.That(result, Is.Empty);
        }
        [Test]
        public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingsReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.DepartureDate),
            }, _repository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
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
