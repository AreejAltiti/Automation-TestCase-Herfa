using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreejTest.Data
{   
    public class GlobalConstants
    {
        // URL for the Contact page.
        public static readonly string loginLink = "https://localhost:44349/Home/ContactUs";

        // Path to the Excel file containing test data. This path can be used to load test data during automated tests.
        public static readonly string TestDataPath = "C:\\Users\\HP\\OneDrive\\Documents\\Project\\ContactData.xlsx";

        // Connection string for the Oracle database used in the project. This includes the database location, user ID, and password for connecting to the database.
        public static readonly string connectionString = "Data Source=localhost:1521/xe;User Id=C##QA;Password=areej1234;";
    }

}
