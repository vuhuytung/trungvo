using System;
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
      public ClassExtend<string, uspRealtyMarketGetByConditionResult> GetListRealtyMarketByCondition(int TypeUser,int Code,int TypeCode, int TypeBDS,double PriceStart,double PriceEnd,int Cur, int ps)
      {

          ClassExtend<string, uspRealtyMarketGetByConditionResult> ret = new ClassExtend<string, uspRealtyMarketGetByConditionResult>();
          int? total = 0;
          ret.Items = BDS.RealtymarketInstance.uspRealtyMarketGetByCondition(TypeUser,Code, TypeCode, TypeBDS, PriceStart, PriceEnd, Cur, ps, ref total).ToList();
          ret.TotalRecord = total.Value;
          return ret;
      }
      public ClassExtend<string, uspRealtyMarketGetAllByStatusResult> GetListRealtyMarketByStatus(int Code, int TypeCode, int TypeBDS, double PriceStart, double PriceEnd, int Cur, int ps)
      {

          ClassExtend<string, uspRealtyMarketGetAllByStatusResult> ret = new ClassExtend<string, uspRealtyMarketGetAllByStatusResult>();
          int? total = 0;
          ret.Items = BDS.RealtymarketInstance.uspRealtyMarketGetAllByStatus(Code, TypeCode, TypeBDS, PriceStart, PriceEnd, Cur, ps, ref total).ToList();
          ret.TotalRecord = total.Value;
          return ret;
      }
      public string GetFullAddressbyLocationID(int LocationID)
      {
          var ret = BDS.RealtymarketInstance.uspRealtyMarketGetFullAddByLoactionID(LocationID).FirstOrDefault();
          try
          {
              return ret.address1;
          }
          catch
          {
              return "";
          }
      }
      public ClassExtend<string, uspRealtyMarketGetAllByCatIDResult> GetListRealtyMarketByCatID(int CatID, int Cur, int ps)
      {

          ClassExtend<string, uspRealtyMarketGetAllByCatIDResult> ret = new ClassExtend<string, uspRealtyMarketGetAllByCatIDResult>();
          int? total = 0;
          ret.Items = BDS.RealtymarketInstance.uspRealtyMarketGetAllByCatID(CatID, Cur, ps, ref total).ToList();
          ret.TotalRecord = total.Value;
          return ret;
      }
      public uspRealtyMarketGetInfoByRealtyMarketIDResult GetDetailRealtyMarketByID(int id)
      {
          return BDS.RealtymarketInstance.uspRealtyMarketGetInfoByRealtyMarketID(id).FirstOrDefault();
      }
      public List<uspRealtyMarketGetCatIdByTypeResult> GetCatByType()
      {
          return BDS.RealtymarketInstance.uspRealtyMarketGetCatIdByType(4).ToList();
      }

      public int UpdateMarket(int ID, string Title, string Desc, string user, string phone, string email, double price, int TypeBDS, string Img, string ImgThumb,string Legal, string Acreage, string ClientRoom, string bedRoom, string bathroom, string Position,string address, string Floor, int Location,string Street,  bool maugiao, bool hospital, bool school, bool market, bool university, bool Status)
      {
          return BDS.RealtymarketInstance.uspRealtyMarketUpdateByRealtyMarketID(ID, Title, Img, ImgThumb, Desc, user, phone, email, price, TypeBDS, Legal, Acreage, ClientRoom, bedRoom, bathroom, Position, Floor, maugiao, hospital, school, market, university, address, Location, Street, Status);
      }
      public int InsertMarket(string Title, string Desc, string user, string phone, string email, double price, int TypeBDS, string Img,string ImgThumb, string Legal, string Acreage, string ClientRoom, string bedRoom, string bathroom, string Position, string address, string Floor, int Location,string Street, bool maugiao, bool hospital, bool school, bool market, bool university, bool Status,int Shower)
      {
          return BDS.RealtymarketInstance.uspRealtyMarketInsert(Title, Desc, Img, ImgThumb, user, phone, email, price, TypeBDS, Legal, Acreage, ClientRoom, bedRoom, bathroom, Position, Floor, maugiao, hospital, school, market, university, address, Location, Street,Shower, Status);
      }
      public int DeleteMarket(int ID)
      {
          return BDS.RealtymarketInstance.uspRealtyMarketDeleteByRealtyMarketID(ID);
      }
      public int UpdateStatus(int ID, bool status)
      {
          return BDS.RealtymarketInstance.uspRealtyMarketupdateStatus(ID, status);
      }
      public int GetShower(int id)
      {
          return BDS.RealtymarketInstance.uspRealtyMarketGetShower(id);
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
