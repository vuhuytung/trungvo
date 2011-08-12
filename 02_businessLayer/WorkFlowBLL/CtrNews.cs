using System;
using System.Collections.Generic;
using System.Linq;
using EntityBLL;
using DAL;
using DataContext;
using VTCO.Config;
using System.Text;
using System.Web;
using System.IO;

namespace WorkFlowBLL
{
    public class CtrNews
    {
        /// <summary>
        /// Lấy danh sách các tin trong chuyên mục
        /// </summary>
        /// <param name="CatID"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<uspNewsGetByCategoryIDHomeResult> GetListNewsByCategory(int CatID, int top)
        {
            return BDS.NewsInstance.uspNewsGetByCategoryIDHome(CatID, top).ToList();
        }

        /// <summary>
        /// Lấy danh sách các tin khác các ID trong newsIDOther
        /// </summary>
        /// <param name="CatID"></param>
        /// <param name="newsIDOther"></param>
        /// <param name="cur"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public ClassExtend<string,uspNewsGetByCategoryIDOtherResult> GetListNewsByCategoryOther(int CatID, string newsIDOther, int cur, int ps)
        {
            ClassExtend<string, uspNewsGetByCategoryIDOtherResult> ret = new ClassExtend<string, uspNewsGetByCategoryIDOtherResult>();
            int? total = 0;
            ret.Items= BDS.NewsInstance.uspNewsGetByCategoryIDOther(CatID, newsIDOther, cur,ps, ref total).ToList();
            ret.TotalRecord = total.Value;
            return ret;
        }

        /// <summary>
        /// Lấy danh sách tin tức cho phần quản lý tin
        /// </summary>
        /// <param name="CatID"></param>
        /// <param name="status"></param>
        /// <param name="cur"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public ClassExtend<string, uspNewsGetListForAdminResult> GetListForAdmin(int CatID, string keyWord,DateTime fromDate, DateTime toDate, int status, int isHot, int cur, int ps)
        {
            ClassExtend<string, uspNewsGetListForAdminResult> ret = new ClassExtend<string, uspNewsGetListForAdminResult>();
            int? total = 0;
            ret.Items = BDS.NewsInstance.uspNewsGetListForAdmin(CatID,keyWord, fromDate, toDate, status,isHot, cur, ps, ref total).ToList();
            ret.TotalRecord = total.Value;
            return ret;
        }

        /// <summary>
        /// Lấy các chuyên mục lớn đi kèm các top 5 tin tức trong chuyên mục đó
        /// </summary>
        /// <returns></returns>
        public ClassExtend<string, ClassExtend<uspCategoryGetByParentIDResult, uspNewsGetByCategoryIDHomeResult>> GetListCategoryNewsForHome()
        {
            ClassExtend<string, ClassExtend<uspCategoryGetByParentIDResult, uspNewsGetByCategoryIDHomeResult>> ret = new ClassExtend<string, ClassExtend<uspCategoryGetByParentIDResult, uspNewsGetByCategoryIDHomeResult>>();
            ClassExtend<uspCategoryGetByParentIDResult, uspNewsGetByCategoryIDHomeResult> obj;
            var lstCat = BDS.CategoryInstance.uspCategoryGetByParentID(0,1).ToList();
            foreach (var menu1 in lstCat)
            {
                obj = new ClassExtend<uspCategoryGetByParentIDResult, uspNewsGetByCategoryIDHomeResult>();
                obj.Info = menu1;
                obj.Items = BDS.NewsInstance.uspNewsGetByCategoryIDHome(menu1.CategoryID, 5).ToList();
                obj.TotalRecord = obj.Items.Count;
                if(obj.TotalRecord>0)
                ret.Items.Add(obj);
            }
            return ret;

        }

        /// <summary>
        /// Lấy thông tin 1 tin tức
        /// </summary>
        /// <param name="newsID"></param>
        /// <returns></returns>
        public uspNewsGetInfoByNewsIDResult GetInfo(int newsID)
        {
            return BDS.NewsInstance.uspNewsGetInfoByNewsID(newsID).FirstOrDefault();
        }

        public int UpdateStatus(int newsID, bool status)
        {
            return BDS.NewsInstance.uspNewsUpdateStatus(newsID, status);
        }
        public int UpdateHot(int newsID, bool isHot)
        {
            return BDS.NewsInstance.uspNewsUpdateHot(newsID, isHot);
        }
        public int Delete(int newsID)
        {
            return BDS.NewsInstance.uspNewsDeleteByNewsID(newsID);
        }
        public int DeleteMulti(string newsIDs)
        {
            return BDS.NewsInstance.uspNewsDeleteMulti(newsIDs);
        }
        public int Insert(string title,string description,string content,string img, DateTime publishDate, int categoryID,string resource,bool status,bool isHot, int adminID)
        {
            return BDS.NewsInstance.uspNewsInsert(title, description, content, img,publishDate, adminID,categoryID, resource, status, isHot);
        }
        public int Update(int newsID, string title, string description, string content, string img, DateTime publishDate, int categoryID, string resource, bool status, bool isHot, int lastModifyAdminID)
        {
            return BDS.NewsInstance.uspNewsUpdateByNewsID(newsID, title, description, content, img, publishDate,lastModifyAdminID, categoryID, resource, status, isHot);
        }
        public void DeleteImage(HttpRequest Request, string urlimg)
        {
            string strImagePath = Request.PhysicalApplicationPath + urlimg;
            if (File.Exists(strImagePath) && !urlimg.Contains("noimage"))
            {
                FileInfo file = new FileInfo(Request.PhysicalApplicationPath + urlimg);
                if (file.Exists)
                {
                    file.Attributes = FileAttributes.Archive;
                    file.Delete();
                }
                file = new FileInfo(Request.PhysicalApplicationPath + urlimg+".thumb");
                if (file.Exists)
                {
                    file.Attributes = FileAttributes.Archive;
                    file.Delete();
                }
            }
        }
    }
}
