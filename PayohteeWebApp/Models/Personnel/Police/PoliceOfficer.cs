using Microsoft.EntityFrameworkCore;
using Payohtee.Data;
using PayohteeWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Personnel.Police
{
    /// <summary>
    /// Employee class to capture personal employee info. Employees interact with companies/customers
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [Table("PoliceEmployee")]
    public class PoliceOfficer //: Employee, ICRUDEmployee
    {
        #region Constructor

        public PoliceOfficer()
        {

        }

        #endregion

        #region Destructor

        ~PoliceOfficer()
        {
            _context.Dispose();
        }

        #endregion

        #region Variables

        readonly PayohteeDbContext _context = new PayohteeDbContext(options: new DbContextOptions<PayohteeDbContext>());

        #endregion

        #region Properties

        [Required]
        [StringLength(10)]
        [Display(Name = "Police Officer #")]
        /// <summary>
        ///Police Officer Number
        /// </summary>
        /// <value>
        /// Value should refer to given department or organisation number for police officer
        /// </value>
        public string PoliceOfficerNumber { get; set; }

        #endregion

        #region Methods

        public List<Employee> GetListEmployee()
        {
            throw new NotImplementedException();
        }

        //public void DeleteEmployee(int id)
        //{
        //    var policeofficer = _context.DbConextPoliceOfficers.FindAsync(id);
        //    policeofficer.Result.Status = "Inactive";
        //    _context.DbConextPoliceOfficers.Update(policeofficer.Result);
        //    _context.SaveChangesAsync();
        //    _context.Dispose();
        //}

        //public void EditEmployee(int id, Employee policeofficer)
        //{
        //    if (id != policeofficer.EmployeeId)
        //    {

        //    }

        //    try
        //    {
        //        _context.Update(policeofficer);
        //        _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(policeofficer.EmployeeId))
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

        //    var policeOfficer = _context.DbConextPoliceOfficers
        //        .FirstOrDefaultAsync(m => m.EmployeeId == id);
        //    if (policeOfficer == null)
        //    {

        //    }

        //    _context.Dispose();
        //}

        public void CreateEmployee(Employee policeofficer)
        {
            if (policeofficer != null)
            {
                policeofficer.RecEntered = DateTime.Now;
                policeofficer.RecModified = DateTime.Now;
                _context.Add(policeofficer);
                _context.SaveChangesAsync();
                _context.Dispose();
            }
        }

        //public bool EmployeeExists(int id)
        //{
        //    return _context.DbConextPoliceOfficers.Any(e => e.EmployeeId == id);
        //}

        #endregion

    }
}
