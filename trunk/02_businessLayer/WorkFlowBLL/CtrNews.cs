using System;
using System.Collections.Generic;
using System.Linq;
using EntityBLL;
using DAL;
using DataContext;
using VTCO.Config;
using System.Text;

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
    }
}
