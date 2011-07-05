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
        public int Insert(string userName,string passWord,string fullName,string address,string phone,string email)
        {
            var pass = VTCO.Utils.Encryption.GetMD5(passWord);
            return BDS.UserInstance.uspUserInsert(userName, pass, fullName, address, phone, email, DateTime.Now, true);
        }
       
    }
}