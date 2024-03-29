﻿using System;
using System.Collections.Generic;
using System.Linq;
using EntityBLL;
using DAL;
using DataContext;
using VTCO.Config;

namespace WorkFlowBLL
{
    public class CtrUser
    {
        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="userName">absdasđ</param>
        /// <param name="passWord"></param>
        /// <param name="fullName"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int Insert(string userName,string passWord,string fullName, DateTime birthday, string address,string phone,string email)
        {
            var pass = VTCO.Utils.Encryption.GetMD5(passWord);
            return BDS.UserInstance.uspUserInsert(userName, pass, fullName,birthday, address, phone, email, DateTime.Now, true);
        }

        public ClassExtend<int, uspUserGetListResult> UserGetList(string keyword, int status, int cur, int ps)
        {
            ClassExtend<int, uspUserGetListResult> ret = new ClassExtend<int, uspUserGetListResult>();
            int? total = 0;
            ret.Items = BDS.UserInstance.uspUserGetList(keyword, status, cur, ps, ref total).ToList();
            ret.TotalRecord = total.Value;
            return ret;
        }
        public int UserUpdateStatus(int userID, int status)
        {
            return BDS.UserInstance.uspUserUpdateStatus(userID, status);
        }
        public uspUserGetInfoByUserIDResult UserGetInfo(int userID)
        {
            return BDS.UserInstance.uspUserGetInfoByUserID(userID).FirstOrDefault();
        }
        public int UserDelete(int userID)
        {
            return BDS.UserInstance.uspUserDeleteByUserID(userID);
        }
        public uspUserLoginResult UserLogin(string userName, string password)
        {
            return BDS.UserInstance.uspUserLogin(userName, password).FirstOrDefault();
        }
        public int ChangePass(int adminID, string passOld, string passNew)
        {
            return BDS.UserInstance.uspUserUpdatePassword(adminID, passOld, passNew);
        }
        public int Update(int userID, string fullName, DateTime birthday, string address, string phone, string email)
        {
            return BDS.UserInstance.uspUserUpdateByUserID(userID, fullName, address, phone, email, birthday);
        }
    }
}
