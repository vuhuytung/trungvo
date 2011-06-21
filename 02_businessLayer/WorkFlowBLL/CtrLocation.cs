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
           a.Name = "-------Tất cả-------";
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
           a.Name = "-------Tất cả-------";
           a.VillageCode = -1;
           b.Add(a);
           foreach (uspLocationGetAllResult pro in Village)
           {
               b.Add(pro);
           }
           return b;

       }

    }
}
