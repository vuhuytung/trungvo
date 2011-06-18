using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class DBCategory
    {
        public DataContext.CategoryDataContext CreateInstance()
        {
            return new DataContext.CategoryDataContext(VTCO.Config.Global.Settings.ConnectionString);
        }


    }
}
