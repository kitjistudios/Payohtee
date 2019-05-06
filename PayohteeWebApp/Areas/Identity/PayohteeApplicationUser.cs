using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Payohtee.Areas.Identity
{
    public class PayohteeApplicationUser : IdentityUser
    {
        #region Enumerator

        public enum PayohteeRoles
        {
            Admin,
            SuperUser,
            Manager,
            Clerk,
            PoliceOfficer,
            CustomsOfficer,
            Supervisor,
            Company,
            User
        }

        #endregion

        #region Constructor

        public PayohteeApplicationUser()
        {
            ListOfRoles();
        }

        #endregion

        #region Properties


        public override string Email { get; set; }

        [Required]
        [Display(Name = "What are you?")]
        public string UserRole { get; set; }

        #endregion

        #region Methods

        public List<string> ListOfRoles()
        {
            var rolelist = Enum.GetNames(typeof(PayohteeRoles)).ToList();
            return rolelist;
        }

        #endregion
    }
}
