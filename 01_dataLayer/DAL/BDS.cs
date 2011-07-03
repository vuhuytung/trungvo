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
       public static DataContext.DocumentDataContext DocumentInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<BDDocument>.Instance.CreateInstance();
           }
       }
       
       public static DataContext.NewsDataContext NewsInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<DBNews>.Instance.CreateInstance();
           }
       }
       public static DataContext.RealtyMarketDataContext RealtymarketInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<DBRealtyMarket>.Instance.CreateInstance();
           }
       }
       public static DataContext.AdminDataContext AdminInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<DBAdmin>.Instance.CreateInstance();
           }
       }

    }
}

