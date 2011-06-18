using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataContext;
namespace WorkFlowBLL
{
   public class CtrProject
    {

       private List<uspProjectGetTop3Result> GetProjectTop3()
       {
           return BDS.Project.uspProjectGetTop3(4).ToList();
       }
       public string GenHtmlSlide()
       {
           List<uspProjectGetTop3Result> a = new List<uspProjectGetTop3Result>();
           a = GetProjectTop3();
           StringBuilder sb = new StringBuilder();
           sb.Append("<div id='bigPic'>");
           foreach (uspProjectGetTop3Result item in a)
           {
               sb.Append("<div class='img'>");
               sb.Append("<img alt='anh' src='" + item.Img + "'/>");
               sb.Append("</div>");
           }
           sb.Append("</div>");
           return sb.ToString();
       }
       public string GenHtmlThumb()
       {
           int rel = 1;
           List<uspProjectGetTop3Result> a = new List<uspProjectGetTop3Result>();
           a = GetProjectTop3();
           StringBuilder sb = new StringBuilder();
           sb.Append("<div class='ssLeft'>");
           sb.Append("<ul id='thumbs'>");
           foreach (uspProjectGetTop3Result item in a)
           {

               sb.Append("<li rel='" + rel.ToString() + "'>");
               sb.Append("<div><div class='title_left'><img alt='anh' src='" + item.Img + "'/></div>");
               sb.Append("<div class='title_right'><a href='#'>" + item.Title + "</a></div></div>");
               sb.Append("</li>");
               rel++;
           }

           sb.Append("</ul>");
           sb.Append("</div>");
           return sb.ToString();
       }
    }
}
