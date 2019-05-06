using Newtonsoft.Json;
using Payohtee.Models.Personnel;
using Payohtee.Models.Settings.Rates;
using PayohteeWebApp.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Accounting
{
    /// <summary>
    /// Payment base class that has properties and methods that all OT payments suscribe to
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [NotMapped]
    public class Payment
    {
        #region Constructor

        public Payment()
        {

        }

        #endregion

        #region Properties
        /// <summary>
        ///Transaction Id
        /// </summary>
        /// <value>
        /// Value should be unique generated id number
        /// </value>
        [Key]
        [JsonRequired]
        [JsonProperty("TranId")]
        public int TranId { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("TransactionNumber")]
        [JsonRequired]
        public string TransactionNumber { get; set; }

        /// <summary>
        /// Company Coordinates
        /// </summary>
        /// <value>
        /// Value should refer to pipe delimited company coordinates
        /// </value>
        [NotMapped]
        [StringLength(50)]
        [JsonProperty("CompanyCoordinates")]
        [JsonRequired]
        public string CompanyCoordinates { get; set; }

        /// <summary>
        /// Latitude Coordinates
        /// </summary>
        /// <value>
        /// Value should refer to latitude coordinates
        /// </value>
        [StringLength(50)]
        [JsonProperty("CompanyLatitude")]
        [JsonRequired]
        public string CompanyLatitude { get; set; }

        /// <summary>
        /// Longitude Coordinates
        /// </summary>
        /// <value>
        /// Value should refer to longitude coordinates
        /// </value>
        [StringLength(50)]
        [JsonProperty("CompanyLongitude")]
        [JsonRequired]
        public string CompanyLongitude { get; set; }

        /// <summary>
        /// Officer Coordinates
        /// </summary>
        /// <value>
        /// Value should refer to pipe delimited officer coordinates
        /// </value>
        [NotMapped]
        [StringLength(50)]
        [JsonProperty("OfficerCoordinates")]
        [JsonRequired]
        public string OfficerCoordinates { get; set; }

        /// <summary>
        /// Latitude Coordinates
        /// </summary>
        /// <value>
        /// Value should refer to latitude coordinates
        /// </value>
        [StringLength(50)]
        [JsonProperty("OfficerLatitude")]
        [JsonRequired]
        public string OfficerLatitude { get; set; }

        /// <summary>
        /// Longitude Coordinates
        /// </summary>
        /// <value>
        /// Value should refer to longitude coordinates
        /// </value>
        [StringLength(50)]
        [JsonProperty("OfficerLongitude")]
        [JsonRequired]
        public string OfficerLongitude { get; set; }

        /// <summary>
        /// Post Name
        /// </summary>
        /// <value>
        /// Value should refer to given post name of an employee
        /// </value>
        [StringLength(50)]
        [JsonProperty("PostName")]
        [JsonRequired]
        public string PostName { get; set; }

        /// <summary>
        /// Pay Rate
        /// </summary>
        /// <value>
        /// Value should refer to given overtime payment rate of an employee
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("PayRate")]
        public decimal PayRate { get; set; }

        /// <summary>
        /// Rate Code
        /// </summary>
        /// <value>
        /// Value should refer to given for overtime rate code for the post
        /// </value>
        [StringLength(50)]
        [JsonProperty("RateCode")]
        [JsonRequired]
        public string RateCode { get; set; }

        /// <summary>
        /// Hours Worked
        /// </summary>
        /// <value>
        /// Value should refer to the number of hours actually worked
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("HoursWorked")]
        public decimal HoursWorked { get; set; }

        /// <summary>
        /// Hours Claimed
        /// </summary>
        /// <value>
        /// Value should refer to the number of hours actually claimed
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("HoursClaimed")]
        public decimal HoursClaimed { get; set; }

        /// <summary>
        /// Inspection Date
        /// </summary>
        /// <value>
        /// Value should refer to the date the inspection was requested
        /// </value>
        [JsonProperty("ServiceDate")]
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// Start Inspection Date
        /// </summary>
        /// <value>
        /// Value should refer to the date the inspection was executed
        /// </value>
        [JsonProperty("StartDateService")]
        public DateTime StartDateService { get; set; }

        /// <summary>
        /// End Inspection Date
        /// </summary>
        /// <value>
        /// Value should refer to the date the inspection was completed
        /// </value>
        [JsonProperty("EndDateService")]
        public DateTime EndDateService { get; set; }

        public bool IsWeekend { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsRegular { get; set; }
        public bool IsDateRange { get; set; }

        #endregion

        //define a delegate
        //defines shape or signature
        //define and event based on that delegate
        //raise the event
        public event EventHandler<EventArgs> DatesChecked;
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public void CheckIsWeekend(DateTime startservicedate, DateTime endservicedate)
        {
            IsWeekend = false;
            //check to see if start day is less than end day
            CheckDateIsRange(startservicedate, endservicedate);
            if (IsDateRange)
            {
                string startday = startservicedate.ToString("d");
                string endday = endservicedate.ToString("d");
                //check to see if the days entered is a weekend
                if ((startday == DayOfWeek.Saturday.ToString()) || (startday == DayOfWeek.Saturday.ToString()))
                {
                    IsWeekend = true;
                }
            }
            else
            {
                IsWeekend = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public void CheckIsHoliday(object source, EventArgs args)
        {
            //get date values from UI
            //check the holidays datastore for list of holidays
            //if dataset has values check to see if date values from UI are in list
            //set Isholiday property
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public void CheckDateIsRange(DateTime startservicedate, DateTime endservicedate)
        {
            if (startservicedate == endservicedate)
            {
                IsDateRange = false;
            }
            else
            {
                IsDateRange = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public void CheckIsBusinessDay(DateTime startservicedate, DateTime endservicedate)
        {
            //if is not weekend
            //if is not holiday
            //then is businessday

        }


        public void GetEmployeePayRate(Employee employee)
        {
            var payrate = new PayRate();
            var context = new PayohteeDbContext(null);
            try
            {
                //var employeeresult = context.DbContextCustomsOfficers.Find(employee.EmployeeId);
                //if (employeeresult == null)
                //{
                //    this.PayRate = 0;
                //}
                //else
                //{
                //    var rateresult = context.DbContextCustomsRate.Where(x => x.RateCode == employeeresult.RateCode).Single();
                //    this.PayRate = rateresult.RateAmount;
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void CalculatePayotee()
        {

        }


        public void CheckDates()
        {
            this.DatesChecked += this.CheckIsHoliday;

        }

        protected void OnDatesSubmitted()
        {
            DatesChecked?.Invoke(this, EventArgs.Empty);
        }

        #endregion

    }
}
