using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using DataContext;
using DAL;
namespace WorkFlowBLL
{
  public class CtrSendMail
    {
      private List<uspEmailContactGetAllResult> GetEmailAll()
      {
          return BDS.EmailInstance.uspEmailContactGetAll().ToList();
      }
      public bool Send_Email(string SendFrom, string Subject, string Body)
       {
           
           try
           {
                   //System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                   System.Net.Mail.SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                   smtp.EnableSsl = true;
                   List<uspEmailContactGetAllResult> Email = new List<uspEmailContactGetAllResult>();
                   Email = GetEmailAll();
                   foreach (uspEmailContactGetAllResult SendTo in Email)
                   {
                       System.Net.Mail.MailMessage msg = new MailMessage(SendFrom, SendTo.Email, Subject, Body);
                       msg.IsBodyHtml = true;
                       //smtp.Host = "smtp.gmail.com";//Sử dụng SMTP của gmail
                       smtp.Send(msg);
                   }
                   return true;
           }
           catch
           {
               return false;
           }
       }  
    }
}
