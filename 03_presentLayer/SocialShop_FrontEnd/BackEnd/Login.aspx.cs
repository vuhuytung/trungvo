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
//using BusinessObject;
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
        //AccountManagement acc = new AccountManagement();
        //DataTable dt =acc.LoginAuthentication(this.txtusename.Text.Trim(),this.txtpassword.Text.Trim());
        //DataTable dt1 = acc.CheckUser(this.txtusename.Text.Trim());
        //if (dt.Rows.Count > 0)
        //{
        //    if (this.ckremember.Checked == true)
        //    {
        //        HttpCookie obj = new HttpCookie("Login");
        //        string username = this.txtusename.Text;
        //        obj.Values["name"] = username;
        //        obj.Expires = DateTime.Now.AddYears(1);
        //        Response.Cookies.Add(obj);
        //    }
        //    Session[Constants.SESSION_USERNAME] = dt.Rows[0]["UserName"].ToString();
        //    Session[Constants.SESSION_ACCOUNTID] = dt.Rows[0]["AccountID"].ToString();
        //    Session[Constants.SESSION_ACCOUNTFULLNAME] = dt.Rows[0]["FullName"].ToString();
        //    Session[Constants.SESSION_ACCOUNTTYPE] = dt.Rows[0]["Type"].ToString();
        //    Response.Redirect("/Default/Index.html");
        //    this.lblmsg.Text = "";
        //}
        //else if(dt1.Rows.Count>0)
        //{
        //    this.lblmsg.Text = "Tài khoản của bạn đã bị khóa.<br/> Hãy liên hệ với ban quản trị để biết thêm thông tin !!";
        //}
        //else
        //{
        //    this.lblmsg.Text = "Sai UserName hoặc Password. Hãy đăng nhập lại!";
        //}
    }
}
