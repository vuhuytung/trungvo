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

        public List<uspNewsGetByCategoryIDHomeResult> GetListNewsByCategory(int CatID, int top)
        {
            return BDS.NewsInstance.uspNewsGetByCategoryIDHome(CatID, top).ToList();
        }

        public ClassExtend<string,uspNewsGetByCategoryIDOtherResult> GetListNewsByCategoryOther(int CatID, string newsIDOther, int cur, int ps)
        {
            ClassExtend<string, uspNewsGetByCategoryIDOtherResult> ret = new ClassExtend<string, uspNewsGetByCategoryIDOtherResult>();
            int? total = 0;
            ret.Items= BDS.NewsInstance.uspNewsGetByCategoryIDOther(CatID, newsIDOther, cur,ps, ref total).ToList();
            ret.TotalRecord = total.Value;
            return ret;
        }

        public ClassExtend<string, ClassExtend<uspCategoryGetForHomeResult, uspNewsGetByCategoryIDHomeResult>> GetListCategoryNewsForHome()
        {
            ClassExtend<string, ClassExtend<uspCategoryGetForHomeResult, uspNewsGetByCategoryIDHomeResult>> ret=new ClassExtend<string,ClassExtend<uspCategoryGetForHomeResult,uspNewsGetByCategoryIDHomeResult>>();
            ClassExtend<uspCategoryGetForHomeResult, uspNewsGetByCategoryIDHomeResult> obj;
            var lstCat = BDS.CategoryInstance.uspCategoryGetForHome().ToList();
            foreach (var menu1 in lstCat)
            {
                obj = new ClassExtend<uspCategoryGetForHomeResult, uspNewsGetByCategoryIDHomeResult>();
                obj.Info = menu1;
                obj.Items = BDS.NewsInstance.uspNewsGetByCategoryIDHome(menu1.CategoryID, 5).ToList();
                obj.TotalRecord = obj.Items.Count;
                if(obj.TotalRecord>0)
                ret.Items.Add(obj);
            }
            return ret;

        }
    }
}
