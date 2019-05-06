using Payohtee.Models.Personnel.Police;
using System.Collections.Generic;

namespace Payohtee.Models.Personnel
{
    interface ICRUDEmployee
    {
        List<Employee> GetListEmployee();
        void DeleteEmployee(int id);
        void EditEmployee(int id, Employee employee);
        void GetEmployee(int? id);
        void CreateEmployee(Employee employee);
        bool EmployeeExists(int id);
    }
}
