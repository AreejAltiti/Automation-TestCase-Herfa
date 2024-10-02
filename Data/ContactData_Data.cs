using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreejTest.Data
{
    public class ContactData_Data
    {
        public ContactData_Data() { }

 /*       public ContactData_Data(string fullName, string email, double phoneNumber,
                           string subject, string message,string isCopy)
        {
            this.fullName    = fullName;               
            this.email       = email;                     
            this.phoneNumber = phoneNumber;       
            this.subject     = subject;                   
            this.message     = message;              
            this.isCopy      = isCopy;   
        }*/

        public string fullName { get; set; }       
        public string email { get; set; }        
        public double phoneNumber { get; set; }   
        public string subject { get; set; }   
        public string message { get; set; }   
        public string isCopy { get; set; }  
    }
}
