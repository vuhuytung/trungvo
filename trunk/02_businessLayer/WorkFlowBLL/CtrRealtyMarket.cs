using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityBLL;
using DAL;
using DataContext;
namespace WorkFlowBLL
{
  public class CtrRealtyMarket
    {
      public ClassExtend<string, uspRealtyMarketGetByConditionResult> GetListRealtyMarketByCondition(int Code,int TypeCode, int TypeBDS,int PriceStart,int PriceEnd,int Cur, int ps)
      {

          ClassExtend<string, uspRealtyMarketGetByConditionResult> ret = new ClassExtend<string, uspRealtyMarketGetByConditionResult>();
          int? total = 0;
          ret.Items = BDS.RealtymarketInstance.uspRealtyMarketGetByCondition(Code, TypeCode, TypeBDS, PriceStart, PriceEnd, Cur, ps,ref total).ToList();
          ret.TotalRecord = total.Value;
          return ret;
      }
    }
}
