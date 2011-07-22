﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityBLL;
using DAL;
using DataContext;
using System.Web;
using System.IO;
namespace WorkFlowBLL
{
  public class CtrRealtyMarket
    {
      public ClassExtend<string, uspRealtyMarketGetByConditionResult> GetListRealtyMarketByCondition(int Code,int TypeCode, int TypeBDS,double PriceStart,double PriceEnd,int Cur, int ps)
      {

          ClassExtend<string, uspRealtyMarketGetByConditionResult> ret = new ClassExtend<string, uspRealtyMarketGetByConditionResult>();
          int? total = 0;
          ret.Items = BDS.RealtymarketInstance.uspRealtyMarketGetByCondition(Code, TypeCode, TypeBDS, PriceStart, PriceEnd, Cur, ps,ref total).ToList();
          ret.TotalRecord = total.Value;
          return ret;
      }
      public List<uspRealtyMarketGetInfoByRealtyMarketIDResult> GetDetailRealtyMarketByID(int id)
      {
          return BDS.RealtymarketInstance.uspRealtyMarketGetInfoByRealtyMarketID(id).ToList();
      }
      public void UpdateMarket(int ID, string Title, string Desc, string user, string phone, string email, double price, int TypeBDS, string Img, string ImgThumb,string Legal, string Acreage, string ClientRoom, string bedRoom, string bathroom, string Position,string address, string Floor, int Location,string Street,  bool maugiao, bool hospital, bool school, bool market, bool university, bool Status)
      {
          BDS.RealtymarketInstance.uspRealtyMarketUpdateByRealtyMarketID(ID, Title, Img, ImgThumb, Desc, user, phone, email, price, TypeBDS, Legal, Acreage, ClientRoom, bedRoom, bathroom, Position, Floor, maugiao, hospital, school, market, university, address, Location, Street, Status);
      }
      public void InsertMarket(string Title, string Desc, string user, string phone, string email, double price, int TypeBDS, string Img,string ImgThumb, string Legal, string Acreage, string ClientRoom, string bedRoom, string bathroom, string Position, string address, string Floor, int Location,string Street, bool maugiao, bool hospital, bool school, bool market, bool university, bool Status)
      {
          BDS.RealtymarketInstance.uspRealtyMarketInsert(Title, Desc, Img, ImgThumb, user, phone, email, price, TypeBDS, Legal, Acreage, ClientRoom, bedRoom, bathroom, Position, Floor, maugiao, hospital, school, market, university, address, Location, Street, Status);
      }
      public void DeleteMarket(int ID)
      {
          BDS.RealtymarketInstance.uspRealtyMarketDeleteByRealtyMarketID(ID);
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
