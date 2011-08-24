using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;
using DAL;
namespace WorkFlowBLL
{
   public class CtrLocation
    {
       List<uspLocationGetAllResult> list = new List<uspLocationGetAllResult>();
       private List<uspLocationGetAllResult> LocationGetAll()
       {
           return BDS.LocationInstance.uspLocationGetAll().ToList();
       }
       public List<uspLocationGetAllResult> LocationGetProvince()
       {
           List<uspLocationGetAllResult> b = new List<uspLocationGetAllResult>();
           list = LocationGetAll();
           var Province = list
                          .Where(x => x.DistrictCode == 0)
                          .Select(x=> x);
           uspLocationGetAllResult a = new uspLocationGetAllResult();
           a.Name = "---------Tất cả---------";
           a.ProvinceCode = -1;
           b.Add(a);
           foreach (uspLocationGetAllResult pro in Province)
           {
               b.Add(pro);
           }
           return b;
       }
       public List<uspLocationGetAllResult> LocationGetDistrict(int ProvinceCode)
       {

           if (list.Count == 0 || list==null)
           {
               list = new List<uspLocationGetAllResult>();
               list = LocationGetAll();
           }
        
              var  District = list
                            .Where(x => (x.ProvinceCode == ProvinceCode) && (x.DistrictCode != 0) && (x.VillageCode == 0))
                            .Select(x => x);
           List<uspLocationGetAllResult> b = new List<uspLocationGetAllResult>();
           uspLocationGetAllResult a = new uspLocationGetAllResult();
           a.Name = "---------Tất cả---------";
           a.DistrictCode = -1;
           b.Add(a);
           foreach (uspLocationGetAllResult pro in District)
           {
               b.Add(pro);
           }
           return b;
       }
       public List<uspLocationGetAllResult> LocationGetVillage(int DistricCode)
       {
           if (list.Count == 0 || list==null)
           {
               list = new List<uspLocationGetAllResult>();
               list = LocationGetAll();
           }
           var Village = list
                        .Where(x => (x.DistrictCode == DistricCode) && (x.VillageCode != 0))
                        .Select(x => x);
           List<uspLocationGetAllResult> b = new List<uspLocationGetAllResult>();
           uspLocationGetAllResult a = new uspLocationGetAllResult();
           a.Name = "---------Tất cả---------";
           a.VillageCode = -1;
           b.Add(a);
           foreach (uspLocationGetAllResult pro in Village)
           {
               b.Add(pro);
           }
           return b;

       }

       /// <summary>
       /// Lấy danh sách các tỉnh
       /// </summary>
       /// <returns></returns>
       public List<uspLocationGetProvincesResult> GetProvince()
       {
           return BDS.LocationInstance.uspLocationGetProvinces().ToList();
       }
       /// <summary>
       /// Lấy danh sách các huyện dựa vào mã tỉnh
       /// </summary>
       /// <param name="proviceCode"></param>
       /// <returns></returns>
       public List<uspLocationGetListDistrictResult> GetDistrict(int proviceCode)
       {
           return BDS.LocationInstance.uspLocationGetListDistrict(proviceCode).ToList();
       }
       /// <summary>
       /// Lấy danh sách các xã thuộc huyện dựa vào mã huyện
       /// </summary>
       /// <param name="destrictCode"></param>
       /// <returns></returns>
       public List<uspLocationGetListVillageResult> GetVillage(int destrictCode)
       {
           return BDS.LocationInstance.uspLocationGetListVillage(destrictCode).ToList();
       }

       public int getLocationIDByCode(int provinceCode, int districtCode, int villageCode)
       {
           return BDS.LocationInstance.uspLocationGetIDByCode(provinceCode, districtCode, villageCode);
       }

    }
}
