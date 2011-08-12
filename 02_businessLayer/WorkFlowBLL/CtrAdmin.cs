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

        public int GetMenuIDByLink(string url)
        {
            return BDS.AdminInstance.uspFunctionGetIDByUrl(url);
        }
        public int GetParentIDByChildID(int functionID)
        {
            return BDS.AdminInstance.uspFunctionGetParentID(functionID);
        }
        public int CheckPermission(int adminID, string url)
        {
            return BDS.AdminInstance.uspPermissionCheck(adminID,url);
        }
        #endregion

        #region Quản lý nhóm quyền
        public List<uspRoleGetAllResult> RoleGetAll()
        {
            return BDS.AdminInstance.uspRoleGetAll().ToList();
        }
        public int RoleInsert(string name,string description,int status)
        {
            return BDS.AdminInstance.uspRoleInsert(name, description, status);
        }
        public int RoleUpdate(int roleID, string name, string description, int status)
        {
            return BDS.AdminInstance.uspRoleUpdateByRoleID(roleID,name,description,status);
        }
        public int RoleDelete(int roleID)
        {
            return BDS.AdminInstance.uspRoleDeleteByRoleID(roleID);
        }
        public int RoleUpdateStatus(int roleID, int status)
        {
            return BDS.AdminInstance.uspRoleUpdateStatus(roleID, status);
        }
        public uspRoleGetInfoByRoleIDResult RoleGetInfo(int roleID)
        {
            return BDS.AdminInstance.uspRoleGetInfoByRoleID(roleID).FirstOrDefault();
        }
        public List<uspRoleGetListByFunctionResult> RoleGetListByFunction(int functionID)
        {
            return BDS.AdminInstance.uspRoleGetListByFunction(functionID).ToList();
        }
        #endregion

        public List<uspFunctionGetChildInRoleResult> FunctionGetChildInRole(int roleID)
        {
            return BDS.AdminInstance.uspFunctionGetChildInRole(roleID).ToList();
        }
        public int RoleFunctionUpdate(int roleID,int functionID,int permission)
        {
            return BDS.AdminInstance.uspRoleFunctionUpdate(roleID, functionID, permission);
        }

        #region Quản lý admin
        public ClassExtend<int, uspAdminGetListResult> AdminGetList(string keyword,int roleID,int status, int cur, int ps)
        {
            ClassExtend<int, uspAdminGetListResult> ret = new ClassExtend<int, uspAdminGetListResult>();
            int? total=0;
            ret.Items = BDS.AdminInstance.uspAdminGetList(keyword, roleID, status,cur,ps, ref total).ToList();
            ret.TotalRecord = total.Value;
            return ret;
        }
        public int AdminUpdateStatus(int adminID, int status)
        {
            return BDS.AdminInstance.uspAdminUpdateStatus(adminID, status);
        }
        public int AdminDelete(int adminID)
        {
            return BDS.AdminInstance.uspAdminDeleteByAdminID(adminID);
        }
        public uspAdminGetInfoByAdminIDResult AdminGetInfo(int adminID)
        {
            return BDS.AdminInstance.uspAdminGetInfoByAdminID(adminID).FirstOrDefault();
        }
        public int AdminInsert(string userName,string password,string fullName,DateTime birthday,string email,string telephone,string description,int status)
        {
            return BDS.AdminInstance.uspAdminInsert(userName, password, status, fullName, birthday, email, telephone, description, DateTime.Now, 2);
        }
        public int AdminUpdate(int adminID,string fullName,DateTime birthday,string email,string telephone,string description,int status)
        {
            return BDS.AdminInstance.uspAdminUpdate(adminID, status, fullName, birthday, email, telephone, description);
        }
        public List<uspAdminGetListByRoleResult> AdminGetListByRole(int roleID)
        {
            return BDS.AdminInstance.uspAdminGetListByRole(roleID).ToList();
        }
        public List<uspAdminGetListNotInRoleResult> AdminGetListNotInRole(int roleID)
        {
            return BDS.AdminInstance.uspAdminGetListNotInRole(roleID).ToList();
        }
        public int PermissionDelete(int permissionID)
        {
            return BDS.AdminInstance.uspPermissionDeleteByPermissionID(permissionID);
        }
        public int PermissionInsert(int roleID, int adminID)
        {
            return BDS.AdminInstance.uspPermissionInsert(adminID, roleID);
        }
        public uspAdminLoginResult AdminLogin(string userName,string password)
        {
            return BDS.AdminInstance.uspAdminLogin(userName, password).FirstOrDefault();
        }
        #endregion
        /*
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
