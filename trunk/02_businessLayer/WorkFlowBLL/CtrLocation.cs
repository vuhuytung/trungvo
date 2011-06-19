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
       public List<uspLocationGetProvinceResult> GetProvince()
       {
           return BDS.Location.uspLocationGetProvince().ToList();
       }
       public List<uspLocationGetDistrictResult> GetDistrict(int ProvinceCode)
       {
           return BDS.Location.uspLocationGetDistrict(ProvinceCode).ToList();
       }
       public List<uspLocationGetVillageResult> GetVillage(int DistrictCode)
       {
           return BDS.Location.uspLocationGetVillage(DistrictCode).ToList();
       }
    }
}
