
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PayohteeWebApp.Models.Geo
{
    public class Places
    {
        #region Constructor
        public Places()
        {
            GetParishList();
        }
        #endregion

        #region Properties

        protected List<string> Parishes { get; set; }

        #endregion

        #region Methods

        public List<String> GetParishList()
        {
            List<String> parish = new List<string>();
            parish.Add("St.Michael");
            parish.Add("St.Andrew");
            parish.Add("St.Philip");
            parish.Add("St.John");
            parish.Add("St.Joseph");
            parish.Add("St.Thomas");
            parish.Add("St.George");
            parish.Add("St.Peter");
            parish.Add("St.Lucy");
            parish.Add("St.James");
            parish.Add("Christ Church");


            Parishes = parish;
            return Parishes;
            
        }
        #endregion
    }
}
