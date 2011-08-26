using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataContext;
using System.Web;
using System.IO;
using EntityBLL;

namespace WorkFlowBLL
{
   public class CtrSlideShow
    {

       private List<uspSlideShowGetGroupResult> SlideGetGroup()
       {
           return BDS.SlideShowInstance.uspSlideShowGetGroup().ToList();
       }
       public List<uspSlideShowGetAllResult> SlideGetAll()
       {
           return BDS.SlideShowInstance.uspSlideShowGetAll().ToList();
       }

       public ClassExtend<string, uspSlideShowGetAllForPageResult> GetSlideForPageAll( int cur, int ps)
       {
           ClassExtend<string, uspSlideShowGetAllForPageResult> ret = new ClassExtend<string, uspSlideShowGetAllForPageResult>();
           int? total = 0;
           ret.Items = BDS.SlideShowInstance.uspSlideShowGetAllForPage(cur, ps, ref total).ToList() ;
           ret.TotalRecord = total.Value;
           return ret;
       }

       public uspSlideShowGetInfoByIDResult GetSlideInfo(int ID)
       {
           return BDS.SlideShowInstance.uspSlideShowGetInfoByID(ID).FirstOrDefault();
       }
       public int SlideUpdate(int ID,string title, string img,string ImgThumb,string url, int status)
       {
           return BDS.SlideShowInstance.uspSlideShowUpdateByID(ID, title, img, ImgThumb,url, status);
       }
       public int SlideUpdateStatus(int ID, int status)
       {
           return BDS.SlideShowInstance.uspSlideShowUpdateStatus(ID, status);
       }
       public int SlideInsert(string title, string img, string ImgThumb,string url, int status)
       {
           return BDS.SlideShowInstance.uspSlideShowInsert(title, img,ImgThumb,url,status);
       }
       public int SlideDeleteByID(int ID)
       {
           return BDS.SlideShowInstance.uspSlideShowDeleteByID(ID);
       }
       public string GenHtmlSlide()
       {
           StringBuilder sb = new StringBuilder();
          List<uspSlideShowGetGroupResult> a = new List<uspSlideShowGetGroupResult>();
          a = SlideGetGroup();
          
           sb.Append("<div id='bigPic'>");
           foreach (uspSlideShowGetGroupResult item in a)
           {
               sb.Append("<div class='mybox'>");
               sb.Append("<div class='mybox_img'>");
               sb.Append("<img alt='Image' title=\" item.Title\" src='" + item.Img + "'/></div>");

               sb.Append("<div class='mybox_title'><a href=\""+item.Url+"\">"+ item.Title + "</a></div>");
               sb.Append("</div>");
           }
           sb.Append("</div>");

           sb.Append("<div class='leftSlide'>");
           sb.Append("<ul id='thumbs'>");
           int rel = 1;
           foreach (uspSlideShowGetGroupResult item in a)
           {

               sb.Append("<li rel='" + rel.ToString() + "'>");
               sb.Append("<div class='my_li'><div class='my_Title'>" + item.Title + "</div>");
               sb.Append("<div class='my_Img'><img src='" + item.Img + "' alt='anh'/></div>");
               sb.Append("</div></li>");
               rel++;
           }

           sb.Replace("rel='1'", "rel='1' class='active'");
           sb.Append("</ul>");
           sb.Append("</div>");
           return sb.ToString();
  
       }
       public void DeleteImg(string Url, HttpRequest request)
       {
           try
           {
               string newurl = Url.Substring(1);
               string pathFile = Path.Combine(request.PhysicalApplicationPath, newurl);
               if (File.Exists(pathFile))
               {
                   //lấy thông tin file
                   FileInfo f = new FileInfo(pathFile);
                   if (f.Exists)
                   {
                       f.Attributes = FileAttributes.Archive;
                       f.Delete();
                   }
               }
           }
           catch
           {
           }
       }
    }
}
