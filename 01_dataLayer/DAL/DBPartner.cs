using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class DBPartner
    {
       public DataContext.PartnersDataContext CreateInstance()
       {
           return new DataContext.PartnersDataContext(VTCO.Config.Global.Settings.ConnectionString);
       }
    }
}
