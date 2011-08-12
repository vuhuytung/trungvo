using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using VTCO.Config;
using VTCO.Library;
using WorkFlowBLL;
//using VTCO.Encrypt;
public partial class backend_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session[Constants.SESSION_USERNAME].ToString().Trim() != "" && Session[Constants.SESSION_ACCOUNTID].ToString().Trim()!="")
        //{
        //    Response.Redirect("/Default/Index.html");
        //}
        //if (!IsPostBack)
        //{
        //    if (Request.Cookies["Login"] != null)
        //    {
        //        this.txtusename.Text = Request.Cookies["Login"]["name"].ToString();
        //        this.txtpassword.Focus();
        //    }
        //}
    }
    protected void btnclick_Click(object sender, EventArgs e)
    {
        CtrAdmin  acc = new CtrAdmin();
        var dt = acc.AdminLogin(this.txtusename.Text.Trim(), VTCO.Utils.Encryption.GetMD5(this.txtpassword.Text.Trim()));

        if ((dt!=null) && (dt.Status==1))
        {
            Session[Constants.SESSION_ADMIN_NAME] = dt.UserName;
            Session[Constants.SESSION_ADMIN_ID] = dt.AdminID;
            Session[Constants.SESSION_ADMIN_FULLNAME] = dt.FullName;
            Session[Constants.SESSION_ADMIN_LEVEL] = dt.Level;
            Session[Constants.SESSION_ADMIN_ISLOGIN] = true;

            Response.Redirect("/admin");
            this.lblmsg.Text = "";
        }
        else if ((dt != null) && (dt.Status == 0))
        {
            this.lblmsg.Text = "Tài khoản của bạn đã bị khóa.<br/> Hãy liên hệ với ban quản trị để biết thêm thông tin !!";
        }
        else
        {
            this.lblmsg.Text = "Sai UserName hoặc Password. Hãy đăng nhập lại!";
        }
    }
}
