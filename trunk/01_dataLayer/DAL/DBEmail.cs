using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;
namespace DAL
{
   public class DBEmail
    {
       public DataContext.EmailContactDataContext CreateInstance()
       {
           return new EmailContactDataContext(VTCO.Config.Global.Settings.ConnectionString);
       }
    }
}
