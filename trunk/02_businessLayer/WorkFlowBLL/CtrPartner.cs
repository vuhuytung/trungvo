using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityBLL;
using DAL;
using DataContext;
using VTCO.Config;

namespace WorkFlowBLL
{
   public class CtrPartner
    {
       private List<uspPartnersGetAllResult> GetListPartner()
       {
           return BDS.Partner.uspPartnersGetAll().ToList();
       }

       public string GenHtml()
       {
           StringBuilder sb = new StringBuilder();
           List<uspPartnersGetAllResult> pn = new List<uspPartnersGetAllResult>();
           pn = GetListPartner();

           foreach (uspPartnersGetAllResult item in pn)
           {
               sb.Append("<a href=" + item.Website + ">");
               sb.Append("<img src=" + item.Img + ""+" alt='anh' width='166' height='124'/>");
               sb.Append("</a>");
           }
           return sb.ToString();
       }
    }
}
