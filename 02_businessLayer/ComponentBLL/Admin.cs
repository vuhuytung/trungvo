using System;
using System.Linq;
using DAL;
using VTCO.Library;
namespace ComponentBLL
{
    public class Admin
    {
        /// <summary>
        /// Kiểm tra tên công ty đã tồn tại hay chưa (thêm mới)
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public bool ExistCompanyName(string companyName)
        {
            int? ret = 0;
           // BDS.AdminInstance.uspCompanyNameExist(companyName, ref ret);
            return ret == 1 ? true : false;
        }

        /// <summary>
        /// Kiểm tra tên công ty đã tồn tại hay chưa (cập nhật)
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool ExistCompanyNameUpdate(string companyName, int companyId)
        {
            int? ret = 0;
            //BDS.AdminInstance.uspCompanyNameUpdateExist(companyName, companyId, ref ret);
            return ret == 1 ? true : false;
        }

        /// <summary>
        /// Kiểm tra địa chỉ email công ty đã tồn tại hay chưa
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistEmailCompany(string email)
        {
            int? ret = 0;
            //BDS.AdminInstance.uspCompanyExistEmail(email, ref ret);
            return ret == 1 ? true : false;
        }

        /// <summary>
        /// Kiểm tra địa chỉ email đã tồn tại hay chưa khi update
        /// </summary>
        /// <param name="email"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public bool ExistEmailCompanyUpdate(string email, int companyID)
        {
            int? ret = 0;
            //BDS.AdminInstance.uspCompanyExistEmailUpdate(email, companyID, ref ret);
            return ret == 1 ? true : false;
        }

        /// <summary>
        /// Kiểm tra công ty có tồn tại công ty con hay không
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public bool ExistCompanyChild(int companyID)
        {
            int? ret = 0;
           // BDS.AdminInstance.uspCompanyExistChild(companyID, ref ret);
            return ret == 1 ? true : false;
        }

        /// <summary>
        /// Kiểm tra thông tin trước khi thêm mới công ty
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="tel"></param>
        /// <param name="email"></param>
        /// <param name="taxCode"></param>
        /// <param name="parentCompanyID"></param>
        /// <returns></returns>
        public int ValidateCompanyInsert(string name, string address, string tel, string email, string taxCode, int parentCompanyID)
        {
            name = name.Trim();
            if (ExistEmailCompany(email)) return -2;     
            if(!Validate.IsEmail(email)) return -3;
            if (ExistCompanyName(name)) return -4;
            if ((name.Length == 0) || (address.Length == 0) || (tel.Length == 0) || (email.Length == 0) || (taxCode.Length == 0)) return -5;
            return 1;
        }

        /// <summary>
        /// Kiểm tra thông tin Company trước khi cập nhật
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="tel"></param>
        /// <param name="email"></param>
        /// <param name="taxCode"></param>
        /// <param name="parentCompanyID"></param>
        /// <returns></returns>
        public int ValidateCompanyUpdate(int companyId,string name, string address, string tel, string email, string taxCode, int parentCompanyID)
        {
            name = name.Trim();
            if (ExistEmailCompanyUpdate(email,companyId)) return -2;
            if(!Validate.IsEmail(email)) return -3;
            if(ExistCompanyNameUpdate(name,companyId)) return -4;
            if ((name.Length == 0) || (address.Length == 0) || (tel.Length == 0) || (email.Length == 0) || (taxCode.Length == 0)) return -5;
            return 1;
        }

        /// <summary>
        /// Kiểm tra dữ liệu trước khi xóa công ty
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public int ValidateDeleteCompany(int companyID)
        {            
            if (ExistCompanyChild(companyID)) return -2;
            return 1;
        }

        /// <summary>
        /// Lấy quyền truy cập chức năng
        /// </summary>
        public static int GetPermission(string funtion)
        {
            var mPermission = 0;
            if (!String.IsNullOrEmpty(VTCO.Utils.AdminUtils.Permission) && !funtion.Equals(string.Empty))
            {
                var permissionList = VTCO.Utils.AdminUtils.Permission.Split('|');
                mPermission = (from permission in permissionList
                               select permission.Split('#')
                               into arrTemp where arrTemp[0].ToLower().Equals(funtion.ToLower()) select Convert.ToInt32(arrTemp[1])).FirstOrDefault();
            }
            return mPermission;
        }
    }
}
