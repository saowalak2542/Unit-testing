using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private readonly IEployeeStorage_storage
        public EmployeeController(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _storage.DeleteEmployee(id);

            return RedirectToAction("Employees");
        }
        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }
    public class ActionResult { }
   
}