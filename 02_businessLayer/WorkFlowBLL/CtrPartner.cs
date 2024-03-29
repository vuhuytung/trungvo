﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityBLL;
using DAL;
using DataContext;
using VTCO.Config;
using System.Web;
using System.IO;


namespace WorkFlowBLL
{
   public class CtrPartner
    {
       public List<uspPartnersGetAllResult> GetListPartner()
       {
           return BDS.PartnerInstance.uspPartnersGetAll().ToList();
       }       
       
       public uspPartnersGetInfoByPartnersIDResult GetInfoByID(int ID)
       {
           return BDS.PartnerInstance.uspPartnersGetInfoByPartnersID(ID).FirstOrDefault();
       }
       public int  UpdatePartner(int ID,string Name,string Img,string Web,bool Status)
       {
           return BDS.PartnerInstance.uspPartnersUpdateByPartnersID(ID, Name, Img, Web, Status);
       }
       public int DeletePartner(int ID)
       {
           return BDS.PartnerInstance.uspPartnersDeleteByPartnersID(ID);
       }
       public int InsertPartner(string Name, string Img, string Web, bool status)
       {
           return BDS.PartnerInstance.uspPartnersInsert(Name, Img, Web, status);
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
       public void DeleteImgTemp(HttpRequest request)
       {
           try
           {
              /* //string newurl = Url.Substring(1);
               string pathFile = Path.Combine(request.PhysicalApplicationPath, @"images/temp/" + Url);
               if (File.Exists(pathFile))
               {
                   //lấy thông tin file
                   FileInfo f = new FileInfo(pathFile);
                   if (f.Exists)
                   {
                       f.Attributes = FileAttributes.Archive;
                       f.Delete();
                   }
               }*/
               DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(request.PhysicalApplicationPath, @"images\\temp"));
               if (directoryInfo.Exists)
               {
                   foreach (FileInfo file in directoryInfo.GetFiles())
                   {

                       file.Delete();
                   }
               }
           }
           catch
           {
           }
       }
    }
}
