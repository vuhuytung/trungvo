using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataContext;
using EntityBLL;
using System.IO;
namespace WorkFlowBLL
{
    public class CtrDocument
    {

        public ClassExtend<string, uspDocumentGetAllResult> GetListDocByCategory(int CatID, int cur, int ps)
        {
            ClassExtend<string, uspDocumentGetAllResult> ret = new ClassExtend<string, uspDocumentGetAllResult>();
            int? total = 0;
            ret.Items = BDS.DocumentInstance.uspDocumentGetAll(CatID, cur, ps, ref total).ToList();
            ret.TotalRecord = total.Value;
            return ret;
        }

        public ClassExtend<string, uspDocumentGetByConditionResult> GetAllDoc(int CatID, int cur, int ps, string CreateDate, int status)
        {
            ClassExtend<string, uspDocumentGetByConditionResult> ret = new ClassExtend<string, uspDocumentGetByConditionResult>();
            int? total = 0;
            ret.Items = BDS.DocumentInstance.uspDocumentGetByCondition(CatID, cur, ps, CreateDate, status, ref total).ToList();
            ret.TotalRecord = total.Value;
            return ret;
        }

        public List<uspDocumentGetInfoByDocumentIDResult> GetInfoDocByID(int docID)
        {
            return BDS.DocumentInstance.uspDocumentGetInfoByDocumentID(docID).ToList();
        }
        public void UpdateDocByID(int DocID, string Title, string desc, string Url, DateTime day,int cate, int status)
        {
            BDS.DocumentInstance.uspDocumentUpdateByDocumentID(DocID, Title, desc, Url,day,cate, status);
        }
        public void DeleteDocByID(int docID)
        {
            BDS.DocumentInstance.uspDocumentDeleteByDocumentID(docID);
        }
        public void InsertDoc(string Title, string desc, string Url, DateTime day, int cate, int status)
        {
            BDS.DocumentInstance.uspDocumentInsert(Title, desc, Url, day, cate, status);
        }
        public void DeleteDocument(string Url, HttpRequest request)
        {
            string pathFile = Path.Combine(request.PhysicalApplicationPath, "Resource\\" + Url);
            if (File.Exists(pathFile))
            {
                //lấy thông tin file
                FileInfo f=new FileInfo(pathFile);
                if(f.Exists)
                {
                    f.Attributes = FileAttributes.Archive;
                    f.Delete();
                }
            }
        }
    }

}