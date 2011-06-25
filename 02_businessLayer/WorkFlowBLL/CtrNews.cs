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
        /*
        /// <summary>
        /// Lấy danh sách các sản phẩm trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        public ClassExtend<SiteInfo, ClassExtend<uspCartGetListShopIDByUserIDResult, uspCartGetListProductByShopIDResult>> GetListProductForCart()
        {
            if (!UserUtils.IsLogin) return null;
            ClassExtend<SiteInfo, ClassExtend<uspCartGetListShopIDByUserIDResult, uspCartGetListProductByShopIDResult>> objReturn = new ClassExtend<SiteInfo, ClassExtend<uspCartGetListShopIDByUserIDResult, uspCartGetListProductByShopIDResult>>();
            ClassExtend<uspCartGetListShopIDByUserIDResult, uspCartGetListProductByShopIDResult> obj;
            var lstShopIDByUserID = SocialShop.ProductInstance.uspCartGetListShopIDByUserID(UserUtils.UserID).ToList();
            foreach (uspCartGetListShopIDByUserIDResult _obj in lstShopIDByUserID)
            {
                obj = new ClassExtend<uspCartGetListShopIDByUserIDResult, uspCartGetListProductByShopIDResult>();
                obj.Info = _obj;
                obj.Items = SocialShop.ProductInstance.uspCartGetListProductByShopID(UserUtils.UserID, _obj.ShopID).ToList();
                obj.TotalRecord = obj.Items.Count;
                objReturn.Items.Add(obj);
            }
            objReturn.Info = SiteInfo.Instance;
            objReturn.TotalRecord = lstShopIDByUserID.Count;
            return objReturn;
        }
         * */

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
