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

            _houseKeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody }


            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
               _houseKeeper
            }.AsQueryable());


            statementGenerator = new Mock<IStatementGenerator>();
            emailSender = new Mock<IEmailSender>();
            messageBox = new Mock<IXtraMessageBox>();


            _service = new HousekeeperService(
                unitOfWork.Object,
                statementGenerator.Object,
                emailSender.Object,
                messageBox.Object);

        }

        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsNull_ShouldNotGenerateStatement()
        {
            _houseKeeper.Email = null;
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
             sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)),
            Times.Never);

        }
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsWhitespace_ShouldNotGenerateStatement()
        {
            _houseKeeper.Email = " ";
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
              sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)),
              Times.Never);
        }
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsEmpty_ShouldNotGenerateStatement()
        {
            _houseKeeper.Email = "";
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
           sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)),
         Times.Never);
        }
    }
}







        