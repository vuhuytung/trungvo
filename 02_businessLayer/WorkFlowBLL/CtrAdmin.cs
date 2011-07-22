using System;
using System.Collections.Generic;
using System.Linq;
using EntityBLL;
using DAL;
using DataContext;
using VTCO.Config;

namespace WorkFlowBLL
{
    public class CtrAdmin
    {
        #region Quản lý chức năng
        public List<uspFunctionByParentIDResult> FunctionGetByParentID(int @parentID, int @status)
        {
            return BDS.AdminInstance.uspFunctionByParentID(@parentID, @status).ToList();
        }

        public uspFunctionGetInfoByFunctionIDResult FunctionGetInfo(int functionID)
        {
            return BDS.AdminInstance.uspFunctionGetInfoByFunctionID(functionID).FirstOrDefault();
        }
        public int FunctionInsert(string name, string url, int order, int parrentID, int status)
        {
            return BDS.AdminInstance.uspFunctionInsert(name, url, order, parrentID, status);
        }
        public int FunctionUpdate(int functionID, string name, string url, int order, int parrentID, int status)
        {
            return BDS.AdminInstance.uspFunctionUpdateByFunctionID(functionID, name, url, order, parrentID, status);
        }

        public int FunctionDelete(int functionID)
        {
            return BDS.AdminInstance.uspFunctionDeleteByFunctionID(functionID);
        }
        #endregion

        public List<uspRoleGetAllResult> RoleGetAll()
        {
            return BDS.AdminInstance.uspRoleGetAll().ToList();
        }
        

        /*
        /// <summary>
        /// Check Login BackEnd
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool CheckLoginBackEnd(string userName, string pass)
        {
            int? ret = 0;
            SocialShop.AdminInstance.uspCheckLoginBackEnd(userName, pass, ref ret);
            if (ret != null) return (int)ret == 1 ? true : false;
            return false;
        }

        /// <summary>
        /// Set mọi Session
        /// </summary>
        public static void Login(string userName, string permission)
        {
            uspAdminGetInfoByUserNameResult infoAdmin = SocialShop.AdminInstance.uspAdminGetInfoByUserName(userName).ToList().FirstOrDefault();
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_ID, infoAdmin.AdminID.ToString());
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_USER_NAME, infoAdmin.UserName);
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_LEVER, infoAdmin.Level.ToString());
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_FULL_NAME, infoAdmin.FullName);
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_COMPANY_ID, "-1");
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_COMPANY_NAME, "");
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_PERMISSION, permission);
        }

        /// <summary>
        /// Xóa mọi Session
        /// </summary>
        public static void Logout()
        {
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_ID, string.Empty);
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_USER_NAME, string.Empty);
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_LEVER, string.Empty);
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_FULL_NAME, string.Empty);
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_COMPANY_ID, string.Empty);
            VTCO.Utils.AdminUtils.SetCookie(Constants.COOKIE_ADMIN_COMPANY_NAME, string.Empty);
        }

        public uspAdminGetInfoByAdminIDResult GetInfoAdminByAdminID(int adminID)
        {
            return SocialShop.AdminInstance.uspAdminGetInfoByAdminID(adminID).ToList().FirstOrDefault();
        }

        public int ComparePassAdmin(string password)
        {
            var passMd5 = VTCO.Utils.Encryption.GetMD5(password);
            var passCurrent = GetInfoAdminByAdminID(VTCO.Utils.AdminUtils.AdminID).Password;
            return passMd5.Equals(passCurrent) ? 1 : 0;
        }

        public uspAdminGetInfoByUserNameResult GetInfoAdminByUserName(string userName)
        {
            return SocialShop.AdminInstance.uspAdminGetInfoByUserName(userName).ToList().FirstOrDefault();
        }

        public List<uspAdminGetAllResult> GetListAdminAll()
        {
            return SocialShop.AdminInstance.uspAdminGetAll().ToList();
        }

        public ClassExtend<int, uspAdminGetListResult> GetListAdmin(string userName, int status, int roleID, int companyID, int currentPage, int pageSize)
        {
            var objReturn = new ClassExtend<int, uspAdminGetListResult>();
            int? totalRecord = 0;
            objReturn.Items = SocialShop.AdminInstance.uspAdminGetList(userName, status, roleID, companyID, currentPage, pageSize, ref totalRecord).ToList();
            if (totalRecord != null) objReturn.TotalRecord = totalRecord.Value;
            objReturn.Info = 0;
            return objReturn;
        }

        public ClassExtend<int, uspAdminGetListToAddShopResult> GetListAdminToAddShop(int companyID)
        {
            var objReturn = new ClassExtend<int, uspAdminGetListToAddShopResult>
            {
                Items = SocialShop.AdminInstance.uspAdminGetListToAddShop(companyID).ToList()
            };
            objReturn.TotalRecord = objReturn.Items.Count;
            objReturn.Info = 0;
            return objReturn;
        }


        public int InsertAdmin(string userName, string password, int status, string fullName, DateTime birthday, string email, string telephone, string description, int companyID, int level)
        {
            var passMd5 = VTCO.Utils.Encryption.GetMD5(password);
            return SocialShop.AdminInstance.uspAdminInsert(userName, passMd5, status, fullName, birthday, email, telephone, description, DateTime.Now, companyID, level);
        }

        /// <summary>
        /// Cập nhật thông tin cá nhân Admin (do admin đó tự cập nhật thông tin cá nhân của mình)
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="birthday"></param>
        /// <param name="email"></param>
        /// <param name="telephone"></param>
        /// <returns></returns>
        public int UpdateAdminInfoPersonal(string fullName, DateTime birthday, string email, string telephone)
        {
            return SocialShop.AdminInstance.uspAdminUpdateInfoPersonal(VTCO.Utils.AdminUtils.AdminID, fullName, birthday, email, telephone);
        }

        /// <summary>
        /// Cập nhật Password cua Admin backend
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public int UpdateAdminPassword(string password)
        {
            var passMd5 = VTCO.Utils.Encryption.GetMD5(password);
            return SocialShop.AdminInstance.uspAdminUpdatePassword(VTCO.Utils.AdminUtils.AdminID, passMd5);
        }

        /// <summary>
        /// Admin cấp cao nhất cập nhật thông tin cua các user admin trong backend
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="status"></param>
        /// <param name="fullName"></param>
        /// <param name="birthday"></param>
        /// <param name="email"></param>
        /// <param name="telephone"></param>
        /// <param name="description"></param>
        /// <param name="companyID"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public int UpdateAdminInfo(int adminID, int status, string fullName, DateTime birthday, string email, string telephone, string description, int companyID, int level)
        {
            return SocialShop.AdminInstance.uspAdminUpdateInfo(adminID, fullName, birthday, email, telephone, description, companyID, status, level);
        }

        public int DeleteAdmin(int adminID)
        {
            return SocialShop.AdminInstance.uspAdminDelete(adminID);
        }

        /// <summary>
        /// Lấy danh sách Role của của Admin
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public ClassExtend<int, uspPermissionGetListRoleInUserResult> GetListRoleInAdmin(int adminID)
        {
            var objReturn = new ClassExtend<int, uspPermissionGetListRoleInUserResult>
            {
                Items = SocialShop.AdminInstance.uspPermissionGetListRoleInUser(adminID).ToList()
            };
            objReturn.TotalRecord = objReturn.Items.Count;
            objReturn.Info = 0;
            return objReturn;
        }

        /// <summary>
        /// Lấy danh sách Role không thuộc Admin
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public ClassExtend<int, uspPermissionGetListRoleNotInUserResult> GetListRoleNotInAdmin(int adminID)
        {
            var objReturn = new ClassExtend<int, uspPermissionGetListRoleNotInUserResult>
            {
                Items = SocialShop.AdminInstance.uspPermissionGetListRoleNotInUser(adminID).ToList()
            };
            objReturn.TotalRecord = objReturn.Items.Count;
            objReturn.Info = 0;
            return objReturn;
        }

        public bool CheckExistUserNameAdmin(string userName)
        {
            int? ret = 0;
            SocialShop.AdminInstance.uspAdminCheckUserName(userName, ref ret);
            return ret == 1 ? true : false;
        }
         * */

        //****************************ShopManager*****************************************//
        /*
        public int InsertShopManager(int companyID, int shopID, int status)
        {
            return SocialShop.AdminInstance.uspShopManagerInsert(companyID, shopID, DateTime.Now, 1);
        }

        public ClassExtend<int, uspShopManagerGetListShopByCompanyResult> GetListShopByCompany(int companyID)
        {
            var objReturn = new ClassExtend<int, uspShopManagerGetListShopByCompanyResult>
            {
                Items =
                    SocialShop.AdminInstance.uspShopManagerGetListShopByCompany(companyID).ToList()
            };
            objReturn.TotalRecord = objReturn.Items.Count;
            objReturn.Info = 0;
            return objReturn;
        }

        public int UpdateShopManagerStatus(int shopManagerID, int status)
        {
            return SocialShop.AdminInstance.uspShopManagerUpdateStatus(shopManagerID, status);
        }

        /// <summary>
        /// Thêm mới Log
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public int InsertLog(char action, string description, string function)
        {
            return SocialShop.AdminInstance.uspLogInsert(VTCO.Utils.AdminUtils.AdminID, VTCO.Utils.AdminUtils.UserName, action, description, function);
        }*/

    }
}
