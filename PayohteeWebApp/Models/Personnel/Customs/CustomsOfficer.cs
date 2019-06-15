using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Payohtee.Models.Banking;
using PayohteeWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Payohtee.Models.Personnel.Customs
{
    /// <summary>
    /// Employee class to capture personal employee info. Employees interact with companies/customers
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    /// 

    [Table("CustomsEmployee")]
    [JsonObject("CustomsEmployee")]
    public class CustomsOfficer : Employee, ICRUDEmployee
    {
        #region Variables

        readonly PayohteeDbContext _context = new PayohteeDbContext(options: new DbContextOptions<PayohteeDbContext>());

        #endregion

        #region Constructor

        public CustomsOfficer()
        {

        }

        #endregion

        #region Destructor

        ~CustomsOfficer()
        {
            _context.Dispose();
        }

        #endregion

        #region Properties

        /// <summary>
        ///Customs Officer Number
        /// </summary>
        /// <value>
        /// Value should refer to given department or organisation number for customs official
        /// </value>
        [Required]
        [StringLength(10)]
        [Display(Name = "Customs Officer #")]
        [JsonProperty("CustomsOfficerNumber")]
        [JsonRequired]
        public string CustomsOfficerNumber { get; set; }

        #endregion

        #region Full Properties

        [NotMapped]
        [JsonIgnore]
        public BankAccount BankDetails { get; set; }

        #endregion

        #region Relationship

        public virtual ICollection<BankAccount> BankInfo { get; set; }
        #endregion

        #region Methods

        public List<Employee> GetListEmployee()
        {
            throw new NotImplementedException();
        }

        //public void DeleteEmployee(int id)
        //{
        //    var customsofficer = _context.DbContextCustomsOfficers.FindAsync(id);
        //    customsofficer.Result.Status = "Inactive";
        //    _context.DbContextCustomsOfficers.Update(customsofficer.Result);
        //    _context.SaveChangesAsync();
        //    _context.Dispose();
        //}

        //public void EditEmployee(int id, Employee customsofficer)
        //{
        //    if (id != customsofficer.EmployeeId)
        //    {

        //    }

        //    try
        //    {
        //        _context.Update(customsofficer);
        //        _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(customsofficer.EmployeeId))
        //        {

        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    _context.Dispose();
        //}

        //public void GetEmployee(int? id)
        //{
        //    if (id == null)
        //    {

        //    }

        //    var customsofficer = _context.DbContextCustomsOfficers
        //        .FirstOrDefaultAsync(m => m.EmployeeId == id);
        //    if (customsofficer == null)
        //    {

        //    }

        //    _context.Dispose();
        //}

        public void CreateEmployee(Employee customsofficer)
        {
            if (customsofficer != null)
            {
                customsofficer.RecEntered = DateTime.Now;
                customsofficer.RecModified = DateTime.Now;
                _context.Add(customsofficer);
                _context.SaveChangesAsync();
                _context.Dispose();
            }
        }

        public List<string> GetListEmployeeName()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetAsyncListEmployeeName(string c)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(string employeename)
        {
            throw new NotImplementedException();
        }

        public void GetEmployee(int? id)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(int id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public bool EmployeeExists(int id)
        {
            throw new NotImplementedException();
        }

        //public bool EmployeeExists(int id)
        //{
        //    return _context.DbContextCustomsOfficers.Any(e => e.EmployeeId == id);
        //}

        #endregion
    }
}
