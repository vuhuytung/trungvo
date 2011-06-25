using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataContext;
namespace WorkFlowBLL
{
  public class CtrDocument
    {
      public List<uspDocumentGetAllResult> DocumentGetAll(int CategoryID)
      {
          return BDS.DocumentInstance.uspDocumentGetAll(CategoryID).ToList();
      }
    }
}
