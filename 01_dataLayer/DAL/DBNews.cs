using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class DBNews
    {
        public DataContext.NewsDataContext CreateInstance()
        {
            return new DataContext.NewsDataContext(VTCO.Config.Global.Settings.ConnectionString);
        }


    }
}
