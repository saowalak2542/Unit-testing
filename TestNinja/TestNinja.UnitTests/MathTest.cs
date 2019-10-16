using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        //setUp
        //TearDown
        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [Test]
  //      [Ignore("Because I wanted to!")]
        public void Add_Whencalled_ReturntheSumOfArguments()
        {

            var result = _math.Max(1, 2);

                    Assert.That(result, Is.EqualTo(3));
           
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {

            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddnumbersUpTolimit()
        {
            var result = _math.GetOddNumbers(5);

     //         Assert.That(result, Is.Not.Empty);
     //         Assert.That(result.Count(), Is.EqualTo(3));

     //         Assert.That(result, Does.Contain(1));
     //         Assert.That(result, Does.Contain(3));
     //         Assert.That(result, Does.Contain(5));

            Assert.That(result, Is.EqualTo(new[] { 1,3,3}));

      //      Assert.That(result, Is.Ordered);
      //      Assert.That(result, Is.Unique);
        }
    }
}