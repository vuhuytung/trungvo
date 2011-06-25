using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;
namespace DAL
{
   public class BDDocument
    {
        public DataContext.DocumentDataContext CreateInstance()
        {
            return new DocumentDataContext(VTCO.Config.Global.Settings.ConnectionString);
        }
    }
}
