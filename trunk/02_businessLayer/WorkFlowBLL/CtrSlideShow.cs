using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataContext;
namespace WorkFlowBLL
{
   public class CtrSlideShow
    {

       private List<uspSlideShowGetGroupResult> SlideGetGroup()
       {
           return BDS.SlideShowInstance.uspSlideShowGetGroup(3).ToList();
       }
       public List<uspSlideShowGetAllResult> SlideGetAll()
       {
           return BDS.SlideShowInstance.uspSlideShowGetAll().ToList();
       }
       public List<uspSlideShowGetInfoByIDResult> GetSlideInfo(int ID)
       {
           return BDS.SlideShowInstance.uspSlideShowGetInfoByID(ID).ToList();
       }
       public void SlideUpdate(int ID,string title, string img, int status)
       {
            BDS.SlideShowInstance.uspSlideShowUpdateByID(ID, title, img, status);
       }
       public void SlideInsert(string title, string img, int status)
       {
           BDS.SlideShowInstance.uspSlideShowInsert(title, img, status);
       }
       public void SlideDeleteByID(int ID)
       {
           BDS.SlideShowInstance.uspSlideShowDeleteByID(ID);
       }
       public string GenHtmlSlide()
       {
           StringBuilder sb = new StringBuilder();
          List<uspSlideShowGetGroupResult> a = new List<uspSlideShowGetGroupResult>();
          a = SlideGetGroup();
          
           sb.Append("<div id='bigPic'>");
           foreach (uspSlideShowGetGroupResult item in a)
           {
               sb.Append("<div class='box'>");
               sb.Append("<div class='box_img'>");
               sb.Append("<img alt='anh' src='" + item.Img + "'/></div>");

               sb.Append("<div class='box_title'>"+ item.Title + " </div>");
               sb.Append("</div>");
           }
           sb.Append("</div>");

           sb.Append("<div class='leftSlide'>");
           sb.Append("<ul id='thumbs'>");
           int rel = 1;
           foreach (uspSlideShowGetGroupResult item in a)
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
