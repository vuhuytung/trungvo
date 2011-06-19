using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;

namespace DAL
{
   public class BDS
    {

       public static CategoryDataContext Category
       {
           get 
           {
              return new CategoryDataContext(); 
           }
       }

       public static PartnersDataContext Partner
       {
           get
           {
               return new PartnersDataContext();
           }
       }
       public static  ProjectDataContext Project
       {
           get
           {
               return new ProjectDataContext();
           }
       }
       public static LocationDataContext Location
       {
           get
           {
               return new LocationDataContext();
           }
       }


    }
}
