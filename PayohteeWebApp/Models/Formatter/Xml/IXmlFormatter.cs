using System;
using System.Collections.Generic;

namespace Payohtee.Models
{
    interface IFormatter
    {
        
        /// <summary>
        /// Get object and return xml string
        /// </summary>
        /// <value>
        /// this should get object class serialise it and return xml string
        /// </value>
        String ObjectToXml(object obj);

        /// <summary>
        /// Get string and return class object
        /// </summary>
        /// <value>
        /// this should get xml string dserialise it and return class object
        /// </value>
        object XmlToObject(string obj );

    }
}
