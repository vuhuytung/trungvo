using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataContext;
using EntityBLL;
namespace WorkFlowBLL
{
  public class CtrDocument
    {

      public ClassExtend<string, uspDocumentGetAllResult> GetListDocByCategory(int CatID,int cur, int ps)
      {
          ClassExtend<string, uspDocumentGetAllResult> ret = new ClassExtend<string, uspDocumentGetAllResult>();
          int? total = 0;
          ret.Items = BDS.DocumentInstance.uspDocumentGetAll(CatID, cur, ps, ref total).ToList();
          ret.TotalRecord = total.Value;
          return ret;
      }

    }
}
