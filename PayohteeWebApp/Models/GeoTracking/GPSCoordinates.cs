using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Payohtee.Models.GeoTracking
{
    public class GPSCoordinates
    {

        private string latitude;

        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        private string longitude;

        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }



    }
}
