using System;
using System.Linq;
using DAL;
using VTCO.Library;
namespace ComponentBLL
{
    public class Category
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>-1: Tên menu rỗng</returns>
        public static int ValidateInsert(string name)
        {
            if (name.Trim().Equals(string.Empty))
                return -1;
            return 1;
        }
    }
}
