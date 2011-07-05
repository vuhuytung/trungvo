using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class DBUser
    {
        /// <summary>
        /// Hàm tạo đối tượng thể hiện của UserDataContext
        /// </summary>
        /// <returns></returns>
        public DataContext.UserDataContext CreateInstance()
        {
            return new DataContext.UserDataContext(VTCO.Config.Global.Settings.ConnectionString);
        }
    }
}
