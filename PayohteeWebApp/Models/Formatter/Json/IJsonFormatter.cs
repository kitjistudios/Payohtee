using System;
using System.Collections.Generic;

namespace Payohtee.Models
{
    interface IJsonFormatter
    {
        /// <summary>
        /// Get object and return json string
        /// </summary>
        /// <value>
        /// this should get object class serialise it and return json string
        /// </value>
        String ObjectToJson(object obj);

        /// <summary>
        /// Get string and return class object
        /// </summary>
        /// <value>
        /// this should get json string dserialise it and return class object
        /// </value>
        object JsonToObject(string json); 
    }
}
