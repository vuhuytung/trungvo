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
           StringBuilder sb = new StringBuilder();
          List<uspProjectGetTop3Result> a = new List<uspProjectGetTop3Result>();
           a = GetProjectTop3();
          
           sb.Append("<div id='bigPic'>");
           foreach (uspProjectGetTop3Result item in a)
           {
               sb.Append("<div class='box'>");
               sb.Append("<div class='box_img'>");
               sb.Append("<a href='#'><img alt='anh' src='" + item.Img + "'/></a></div>");

               sb.Append("<div class='box_title'>"+ item.Title + " </div>");
               sb.Append("</div>");
           }
           sb.Append("</div>");

           sb.Append("<div class='leftSlide'>");
           sb.Append("<ul id='thumbs'>");
           int rel = 1;
           foreach (uspProjectGetTop3Result item in a)
           {

               sb.Append("<li rel='" + rel.ToString() + "'>");
               sb.Append("<div class='my_Title'>" + item.Title + "</div>");
               sb.Append("<div class='my_Img'><img src='" + item.Img + "' alt='anh'/></div>");
               sb.Append("</li>");
               rel++;
           }

           sb.Replace("rel='1'", "rel='1' class='active'");
           sb.Append("</ul>");
           sb.Append("</div>");
           return sb.ToString();
  
       }
      
    }
}
