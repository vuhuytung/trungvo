//
// Author:      hoan.trinh
// Create Date: 2010-06-28
// Description: Lớp các đối tượng tương tác với CSDL SocialShop
//
namespace DAL
{
    /// <summary>
    /// Lớp tương tác với cơ sở dữ liệu
    /// </summary>
    public class SocialShop
    {
        /// <summary>
        /// Thể hiện của lớp AdminDataContext
        /// </summary>
        public static DataContext.AdminDataContext AdminInstance
        {
            get
            {
                return VTCO.Config.Pattern.Singleton<DBAdmin>.Instance.CreateInstance();
            }
        }

    }
}
