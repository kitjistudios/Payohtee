using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PayohteeWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public class CustomsOfficer  //:Employee, //ICRUDEmployee
    {
        #region Constructor

        #endregion

        #region Destructor

        ~CustomsOfficer()
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
        [Display(Name = "Customs Officer #")]
        [JsonProperty("CustomsOfficerNumber")]
        /// <summary>
        ///Customs Officer Number
        /// </summary>
        /// <value>
        /// Value should refer to given department or organisation number for customs official
        /// </value>
        public string CustomsOfficerNumber { get; set; }

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

        //public bool EmployeeExists(int id)
        //{
        //    return _context.DbContextCustomsOfficers.Any(e => e.EmployeeId == id);
        //}

        #endregion
    }
}
