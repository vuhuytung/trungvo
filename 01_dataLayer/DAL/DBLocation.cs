using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;

namespace DAL
{
  public class DBLocation
    {
      public DataContext.LocationDataContext CreatLocationInstance()
      {
          return new LocationDataContext(VTCO.Config.Global.Settings.ConnectionString);
      }
    }
}
