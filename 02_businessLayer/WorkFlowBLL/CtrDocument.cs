using System;
using System.Web;
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
      public List<uspDocumentGetInfoByDocumentIDResult> GetInfoDocByID(int docID)
      {
          return BDS.DocumentInstance.uspDocumentGetInfoByDocumentID(docID).ToList();
      }
      public void UpdateDocByID(int DocID, string Title, string desc, string Url, int cate, int status)
      {
          BDS.DocumentInstance.uspDocumentUpdateByDocumentID(DocID, Title, desc, Url, cate, status);
      }
    }

  public class NewDocument
  {
      private int _docID,_Cate,_status;
      private string _title;
      private string _desc;
      private string _url;
      
      public NewDocument(int DocID)
      {
          CtrDocument doc = new CtrDocument();
         // List<uspDocumentGetInfoByDocumentIDResult> list1 = new List<uspDocumentGetInfoByDocumentIDResult>();
         // list1 = doc.GetInfoDocByID(DocID);
          var list1 = doc.GetInfoDocByID(DocID)
                    .Select(x => x);
          
          foreach (var item in list1)
          {
              _Cate = item.CategoryID;
              _desc = HttpUtility.HtmlDecode(item.Description+ " ").Replace("</br>", "\n");
              _docID = item.DocumentID;
              _status = item.Status;
              _title = item.Title;
              _url = item.URL;
          }
      }
      public int DocID
      {
          get
          {
              return _docID;
          }
          set
          {
              _docID = value;
          }
      }
      public int Cate
      {
          get { return _Cate; }
          set { _Cate = value; }
      }
      public int Status
      {
          get { return _status; }
          set { _status = value; }
      }
      public string Title
      {
          get { return _title; }
          set { _title = value; }
      }
      public string Desc
      {
          get { return _desc; }
          set { _desc = value; }
      }
      public string URL
      {
          get { return _url; }
          set { _url = value; }
      }
      
  }
}
