using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;

namespace DAL
{
   public class BDS
    {

       public static DataContext.CategoryDataContext CategoryInstance
       {
           get 
           {
               return VTCO.Config.Pattern.Singleton<DBCategory>.Instance.CreateInstance();
           }
       }

       public static DataContext.PartnersDataContext PartnerInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<DBPartner>.Instance.CreateInstance();
           }
       }

       public static DataContext.SlideShowDataContext SlideShowInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<DBSlideShow>.Instance.CreateInstance();
           }
       }

       public static DataContext.LocationDataContext LocationInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<DBLocation>.Instance.CreateInstance();
           }
       }
       public static DataContext.NewsDataContext NewsInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<DBNews>.Instance.CreateInstance();
           }
       }

    }
}
