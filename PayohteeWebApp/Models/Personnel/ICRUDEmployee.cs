using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payohtee.Models.Personnel
{
    interface ICRUDEmployee
    {
        /// <summary>
        /// My contract should create a new employee record
        /// </summary>
        /// <value>
        /// this should create a new employee
        /// </value>
        void CreateEmployee(Employee employee);

        /// <summary>
        /// My contract should get a list of employee objects
        /// </summary>
        /// <value>
        /// this should return a list of all employee records
        /// </value>
        List<Employee> GetListEmployee();

        /// <summary>
        /// My contract should get a list of employee names
        /// </summary>
        /// <value>
        /// this should return a list of employee names
        /// </value>
        List<string> GetListEmployeeName();

        /// <summary>
        /// My contract should get a suggestive list of employees
        /// </summary>
        /// <value>
        /// this should allow the asynch list search of employee names
        /// this is for the asynchronous search for suggestive search in UI
        /// </value>
        Task<List<string>> GetAsyncListEmployeeName(string c);

        /// <summary>
        /// My contract should get employee object 
        /// </summary>
        /// <value>
        /// this should select the employee object by name
        /// </value>
        Employee GetEmployee(string employeename);

        /// <summary>
        /// My contract should get employee object 
        /// </summary>
        /// <value>
        /// this should select the employee object by name
        /// </value>
        void GetEmployee(int? id);

        /// <summary>
        /// My contract should select a company to be edited
        /// </summary>
        /// <value>
        /// this should select the record to be edited by id
        /// </value>
        void EditEmployee(int id, Employee employee);

        /// <summary>
        /// My contract should flag a company for deletion
        /// </summary>
        /// <value>
        /// this should flag the record for deletion
        /// </value>
        void DeleteEmployee(int id);

        /// <summary>
        /// My contract should check to see if the company exists
        /// </summary>
        /// <value>
        /// this should check to see it the company exists
        /// </value>
        bool EmployeeExists(int id);

    }
}
