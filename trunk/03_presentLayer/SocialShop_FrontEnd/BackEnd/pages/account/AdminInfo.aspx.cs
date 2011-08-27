using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DataContext;
using System.Web.UI.HtmlControls;
using VTCO.Library;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using VTCO.Config;

public partial class BackEnd_pages_account_AdminInfo : System.Web.UI.Page
{
    public int AdminID
    {
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["AdminID"]);
            }
            catch
            {
                return -1;
            }
        }

        set
        {
            ViewState["AdminID"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session[Constants.SESSION_ADMIN_ISLOGIN] ?? false))
            Response.Redirect("/admin/login");
        if (!IsPostBack)
        {
            AdminID = Convert.ToInt32(Session[Constants.SESSION_ADMIN_ID] ?? "-1");
            CtrAdmin ctrAdmin = new CtrAdmin();
            var info = ctrAdmin.AdminGetInfo(AdminID);
            lblUserName.Text = HtmlUtility.HtmlEncode(info.UserName);
            txtFullName.Text = HtmlUtility.HtmlDecode(info.FullName);
            lblUserName.Visible = true;
            txtEmail.Text = HtmlUtility.HtmlDecode(info.Email);
            txtTelephone.Text = HtmlUtility.HtmlDecode(info.Telephone);
            lblCreateDate.Text = info.DateCreate.Value.ToString("dd/MM/yyyy");
            rdpBirthday.SelectedDate = info.Birthday;
            txtAbstract.Text = HtmlUtility.HtmlDecode(info.Description);
        }
    }    
    protected void lbtSave_Click(object sender, EventArgs e)
    {        
        if (AdminID != Convert.ToInt32(Session[Constants.SESSION_ADMIN_ID] ?? "-1"))
        {
            Response.Redirect("~/admin/notpermission");
        }
        CtrAdmin ctrAdmin = new CtrAdmin();
        var ret = ctrAdmin.AdminUpdate(AdminID, HtmlUtility.HtmlEncode(txtFullName.Text), rdpBirthday.SelectedDate.Value, HtmlUtility.HtmlEncode(txtEmail.Text), 
            HtmlUtility.HtmlEncode(txtTelephone.Text), HtmlUtility.HtmlEncode(txtAbstract.Text));     
        if (ret> 0)
        {
            lblMsg.Text = "Cập nhật thành công";
        }
        else
            lblMsg.Text = "Cập nhật thất bại!";
    }   
}