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
      public List<uspDocumentGetAllResult> DocumentGetAll(int CategoryID,int CurrentPage,int Record,int PageSize)
      {
          return BDS.DocumentInstance.uspDocumentGetAll(CategoryID, CurrentPage, Record, PageSize).ToList();
      }
      public List<uspDocumentGetPageResult> DocumentGetPage(int CategoryID, int CurrentPage, int Record, int PageSize)
      {
          return BDS.DocumentInstance.uspDocumentGetPage(CategoryID, CurrentPage, Record, PageSize).ToList();
      }
    }
}
