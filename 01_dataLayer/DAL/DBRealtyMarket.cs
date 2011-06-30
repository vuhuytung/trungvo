using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;
namespace DAL
{
  public  class DBRealtyMarket
    {
      public DataContext.RealtyMarketDataContext CreateInstance()
      {
          return new RealtyMarketDataContext(VTCO.Config.Global.Settings.ConnectionString);
      }

    }
}
