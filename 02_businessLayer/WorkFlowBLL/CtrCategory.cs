using System;
using System.Collections.Generic;
using System.Linq;
using EntityBLL;
using DAL;
using DataContext;
using VTCO.Config;

namespace WorkFlowBLL
{
    public class CtrCategory
    {       

        public List<uspCategoryGetAllResult> GetListCategory(int status)
        {
           return BDS.CategoryInstance.uspCategoryGetAll(status).ToList();
        }        
    }
}
