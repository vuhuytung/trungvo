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
    public class CtrCategory
    {
        StringBuilder sb = new StringBuilder();
        //private List<uspCategoryGetAllResult> GetListCategory()
        //{
        //    return BDS.CategoryInstance.uspCategoryGetAll().ToList();
        //}


        public List<uspCategoryGetListResult> GetListCategory(int status)
        {
            return BDS.CategoryInstance.uspCategoryGetList(status).ToList();
        }
        
        /// <summary>
        /// Lấy danh sách chuyên mục và các chuyên mục con
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<uspCategoryGetByParentIDResult> GetByParentID(int parentID, int status)
        {
            return BDS.CategoryInstance.uspCategoryGetByParentID(parentID, status).ToList();
        }

        /// <summary>
        /// Lấy thông tin một chuyên mục
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        public uspCategoryGetInfoByCategoryIDResult GetInfo(int CatID)
        {
            return BDS.CategoryInstance.uspCategoryGetInfoByCategoryID(CatID).FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="name"></param>
        /// <param name="uRL"></param>
        /// <param name="status"></param>
        /// <param name="order"></param>
        /// <param name="type"></param>
        /// <returns>-1: Tên menu rỗng, >0: Insert thành công</returns>
        public int Insert(int parentID,string name,string uRL,int status,int order, int type)
        {
            int ret = ComponentBLL.Category.ValidateInsert(name);
            if(ret<0) return ret;
            return BDS.CategoryInstance.uspCategoryInsert(parentID, name, uRL, status, order, type);
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="parentID"></param>
        /// <param name="name"></param>
        /// <param name="uRL"></param>
        /// <param name="status"></param>
        /// <param name="order"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Update(int categoryID,int parentID,string name,string uRL,int status,int order,int type)
        {
            return BDS.CategoryInstance.uspCategoryUpdateByCategoryID(categoryID, parentID, name, uRL, status, order, type);
        }

        public int Delete(int categoryID)
        {            
            return BDS.CategoryInstance.uspCategoryDeleteByCategoryID(categoryID);
        }

        public List<uspCategoryGetNavigatorResult> GetNavigator(int categoryID)
        {
            return BDS.CategoryInstance.uspCategoryGetNavigator(categoryID).ToList();
        }

        //private void GenHtmlMenu(List<uspCategoryGetAllResult> menu, int ParentID,int y)
        //{
        //    try
        //    {
        //        if (menu == null)
        //        {
        //            menu = new List<uspCategoryGetAllResult>();
        //            menu = GetListCategory();
        //        }
        //        var t = menu
        //             .Where(x => x.ParentID == ParentID)
        //             .Select(x => x);
        //         string CssClass = "ul" + y.ToString();
        //         string CssClass1="li"+y.ToString();
        //        string CssClass2="aa"+y.ToString();
        //        if (t.Count() != 0)
        //        {
        //            sb.Append("<ul class='"+CssClass+"'>");
        //            foreach (var i in t)
        //            {
        //                sb.Append("<li class='"+ CssClass1 +"'>");
        //                sb.Append("<a class='" + CssClass2 + "'>" + i.Name + "</a>");
        //                GenHtmlMenu(menu, i.CategoryID, y + 1);
        //                sb.Append("</li>");

        //            }
        //            sb.Append("</ul>");
        //        }
                
        //    }
        //    catch
        //    {

        //    }

        //}

        //public string ReturnHtmlMenu()
        //{

        //    GenHtmlMenu(menu, 0, 1);
        //    sb.Replace("ul2", "ulChild1");
        //    sb.Replace("ul3", "ulChild2");
        //    sb.Replace("li1", "liParent");
        //    sb.Replace("li2", "liChildren");
        //    sb.Replace("class='li3'", " ");
        //    sb.Replace("aa1", "menuParent Menufirst");
        //    sb.Replace("aa2", "menuChildren");
        //    sb.Replace("aa3", "menuChildren");
        //    return sb.ToString();
        //}

        //private void GenHtmlMenu(List<uspCategoryGetAllResult> menu, int? nullable, int p)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
