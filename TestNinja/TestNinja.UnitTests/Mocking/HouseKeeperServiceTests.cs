using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        private HouseKeeperService service;
        private Mock<ISTatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _messageBox;
        private DateTime _statementDate = new DateTime(2017, 1, 1);

        [SetUp]
        public void SetUp()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            _houseKeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody}
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                new Housekeeper {Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" }

            }.AsQueryable());
            var statementGenerator = new Mock<IStatementGenerator>();
            var emailSender = new Mock<IEmailSender>();
            var messageBox = new Mock<IXtraMessageBox>();


            _service = new HousekeeperService(
                unitOfWork.Object,
                statementGenerator.Object,
                emailSender.Object,
                messageBox.Object);

        }


        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            
            _service.SendStatementEmails(new DateTime(2017, 1, 1));

            statementGenerator.Verify(sg => sg.SaveStatement(1, "b", ( _statementDate)));

        }
    }
}