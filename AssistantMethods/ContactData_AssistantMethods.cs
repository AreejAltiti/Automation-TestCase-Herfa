using AreejTest.Data;
using AreejTest.Helpers;
using AreejTest.POM;
using AreejTest.WebDriver;
using Bytescout.Spreadsheet;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreejTest.dsada
{
    public class ContactData_AssistantMethods
    {
        public static void FillRegisterForm(ContactData_Data ContactData_Data)
        {
            ContactData_POM ContactData_POM = new ContactData_POM(ManageDriver.driver);

            ContactData_POM.EnterFullName(ContactData_Data.fullName);

            ContactData_POM.EnterEmail(ContactData_Data.email);

            ContactData_POM.EnterPhoneNumber(Convert.ToString(ContactData_Data.phoneNumber));

            ContactData_POM.EnterSubject(ContactData_Data.subject);

            ContactData_POM.EnterMessage(ContactData_Data.message);

            ContactData_POM.EnterIsCopy(ContactData_Data.isCopy);

            ContactData_POM.ClickSubmitButton();
        }
        //Data-Driven Testing(DDT) is a software testing approach where test input and expected output are stored in external data sources like files(Excel, CSV, XML), databases, or spreadsheets.Instead of hardcoding the test data within test scripts, DDT pulls data from these sources and uses it to run multiple test iterations with different inputs.
        //Key Features of DDT:
        //Separation of Data and Logic: Test logic is written once, and the data is stored separately, making tests more flexible and maintainable.
        //Multiple Test Scenarios: By running the same test case with various data sets, DDT increases test coverage and ensures the application behaves correctly for different inputs.
        //Reusability: The same test script can be reused with different sets of data, reducing code duplication.

        public static ContactData_Data ReadContactDataFromExcel(int row)
        {
            ContactData_Data ContactData_Data = new ContactData_Data();

            Worksheet worksheet = CommonMethods.ReadExcel("Contact");
            ContactData_Data.fullName = Convert.ToString(worksheet.Cell(row, 0).Value);
            ContactData_Data.email    = (string)worksheet.Cell(row, 1).Value;
            ContactData_Data.phoneNumber = (double)worksheet.Cell(row, 2).Value;
            ContactData_Data.subject = Convert.ToString(worksheet.Cell(row, 3).Value);
            ContactData_Data.message = Convert.ToString(worksheet.Cell(row, 4).Value);
            ContactData_Data.isCopy = Convert.ToString(worksheet.Cell(row, 5).Value);
  
            return ContactData_Data;
        }
        public static bool CheckSuccessContact(string email)
        {
            bool isDataExist = false;
            string query = "select count(*) from contactus_fp where email  = :value";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter(":value", email));
                int result = Convert.ToInt32(command.ExecuteScalar());
                isDataExist = result > 0;

                return isDataExist;

            }
        }
    }
}
