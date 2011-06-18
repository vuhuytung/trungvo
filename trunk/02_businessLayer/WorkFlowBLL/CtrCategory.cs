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
        List<uspCategoryGetAllResult> menu;
        private List<uspCategoryGetAllResult> GetListCategory()
        {
            return BDS.Category.uspCategoryGetAll().ToList();
        }

        private void GenHtmlMenu(List<uspCategoryGetAllResult> menu, int ParentID,int y)
        {
            try
            {
                if (menu == null)
                {
                    menu = new List<uspCategoryGetAllResult>();
                    menu = GetListCategory();
                }
                var t = menu
                     .Where(x => x.ParentID == ParentID)
                     .Select(x => x);
                 string CssClass = "ul" + y.ToString();
                 string CssClass1="li"+y.ToString();
                string CssClass2="aa"+y.ToString();
                if (t.Count() != 0)
                {
                    sb.Append("<ul class='"+CssClass+"'>");
                    foreach (var i in t)
                    {
                        sb.Append("<li class='"+ CssClass1 +"'>");
                        sb.Append("<a class='" + CssClass2 + "'>" + i.Name + "</a>");
                        GenHtmlMenu(menu, i.CategoryID, y + 1);
                        sb.Append("</li>");

                    }
                    sb.Append("</ul>");
                }
                
            }
            catch
            {

            }

        }

        public string ReturnHtmlMenu()
        {

            GenHtmlMenu(menu, 0, 1);
            sb.Replace("ul2", "ulChild1");
            sb.Replace("ul3", "ulChild2");
            sb.Replace("li1", "liParent");
            sb.Replace("li2", "liChildren");
            sb.Replace("class='li3'", " ");
            sb.Replace("aa1", "menuParent Menufirst");
            sb.Replace("aa2", "menuChildren");
            sb.Replace("aa3", "menuChildren");
            return sb.ToString();
        }

        private void GenHtmlMenu(List<uspCategoryGetAllResult> menu, int? nullable, int p)
        {
            throw new NotImplementedException();
        }


    }
}
