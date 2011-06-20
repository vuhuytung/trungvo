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

       public static DataContext.ProjectDataContext ProjectInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<DBProject>.Instance.CreateInstance();
           }
       }

       public static DataContext.LocationDataContext LocationInstance
       {
           get
           {
               return VTCO.Config.Pattern.Singleton<DBLocation>.Instance.CreateInstance();
           }
       }       

    }
}
