using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;

namespace DAL
{
   public class DBProject
    {
       public DataContext.ProjectDataContext CreateProjectInstance()
       {
           return new ProjectDataContext(VTCO.Config.Global.Settings.ConnectionString);
       }
    }
}
