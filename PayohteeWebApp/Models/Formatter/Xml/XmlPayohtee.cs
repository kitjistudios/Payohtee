using Payohtee.Models.Personnel;
using System.IO;
using System.Xml.Serialization;

namespace Payohtee.Models.Formatter.Xml
{
    public class XmlPayohtee
    {
        public XmlPayohtee()
        {
            var employee = new Employee();
            employee.EmployeeId = 1234;
            SerializeXml(employee, @"C:\Users\Shayne Marshall\Desktop\");
        }
        
        private XmlSerializer SerializeXml(Employee employee, string path)
        {
            employee.NationalRegNo = "NRN";
            employee.NISNo = "NIS";
            employee.TIN = "TIN";
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            serializer.Serialize(File.Create(path + employee.EmployeeId), employee);
            return serializer;
        }

    }
}
