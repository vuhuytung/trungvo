using System;
using System.Linq;
using VTCO.Config;

public partial class srv_errorhandle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        string strRequestPage = Request.ServerVariables["QUERY_STRING"].Replace("404;", "");
        string strServiceABSURL = Request.ServerVariables["SCRIPT_NAME"].Replace("srv_errorhandle.aspx", "");

        strServiceABSURL = strServiceABSURL.ToLower();

        // Nếu không phải photoservices --> trả về trang thông báo lỗi chuẩn
        if (strServiceABSURL != "/photoservices/")
        {
            Response.Redirect(Global.Settings.WebRoot + "error.aspx");
            return;
        }

        //Response.Write(strRequestPage + "<br/>");
        //Response.Write(strServiceABSURL + "<br/>");
        //return;

        // Nếu tham số không đúng --> trả về trang ảnh mặc định
        if (strRequestPage.Count(c => c == '/') < 3)
        {
            Response.Redirect(Global.Settings.ServicesPhoto + "photoServices.ashx");
            return;
        }

        // Cắt phần: aspxerrorpath=/ hoặc http://domainname:[port]/

        int iIndex = 0;

        if (strRequestPage.StartsWith("http", StringComparison.OrdinalIgnoreCase))
        {
            iIndex = strRequestPage.IndexOf("//");
            strRequestPage = strRequestPage.Substring(iIndex + 2);
        }

        iIndex = strRequestPage.IndexOf('/');
        strRequestPage = strRequestPage.Substring(iIndex + 1);

        // Loại bỏ: photoservices/
        iIndex = strRequestPage.IndexOf('/');
        strRequestPage = strRequestPage.Substring(iIndex + 1);

        // Lấy type của services
        iIndex = strRequestPage.IndexOf('/');
        string strType = strRequestPage.Substring(0, iIndex).ToLower();

        // Lấy path của ảnh
        string strPath = strRequestPage.Substring(iIndex + 1);

        // Nếu tham số không đúng --> trả về trang ảnh mặc định
        if (strRequestPage.Count(c => c == '.') < 3)
        {
            Response.Redirect(Global.Settings.ServicesPhoto + "photoServices.ashx");
            return;
        }

        // Loại bỏ .cache
        iIndex = strPath.LastIndexOf('.');
        strPath = strPath.Substring(0, iIndex);

        // Lấy height
        iIndex = strPath.LastIndexOf('.');
        int iHeight = Convert.ToInt32(strPath.Substring(iIndex + 1));
        strPath = strPath.Substring(0, iIndex);

        // Lấy width
        iIndex = strPath.LastIndexOf('.');
        int iWidth = Convert.ToInt32(strPath.Substring(iIndex + 1));

        string strName = strPath.Substring(0, iIndex);

        string strUrl = string.Format("{0}photoServices.ashx?type={1}&name={2}&w={3}&h={4}",
            Global.Settings.ServicesPhoto,
            strType,
            strName,
            iWidth,
            iHeight);

        Response.Redirect(strUrl);
        //}
        //catch
        //{
        //    Response.Redirect(Global.Settings.ServicesPhoto + "photoServices.ashx");
        //}

    }
}
