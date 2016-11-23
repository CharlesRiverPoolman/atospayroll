using PayrollDatabaseAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HelperClassLibrary
{
    public static class Mail
    {
        private static AtosPayrollEntities db = new AtosPayrollEntities();
        public static bool SendMail(int roleid)
        {
            bool result;
            try
            {
                string email = db.Employees.Single(c => c.EmployeeRoleID == roleid).Email;

                MailMessage mail = new MailMessage();
                
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //   client.Host = "emea.it-solutions.myatos.net";
                client.Host = "10.92.32.13";
                mail = new MailMessage(email, email);
                mail.Subject = "You\'ve got a Notification Expense Form to fill in.";
               
                 mail.Body = @"http://localhost:52216/MonthlyExpenseClaims/Index";
             //  mail.Body = ReadTextFromUrl("http://localhost:52216/MonthlyExpenseClaims/Index");
                mail.IsBodyHtml = true;
                client.Send(mail);
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

      

    }
}
