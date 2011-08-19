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
            lblUserName.Text = info.UserName;
            txtFullName.Text = info.FullName;
            txtUserName.Visible = false;
            lblUserName.Visible = true;
            txtEmail.Text = info.Email;
            txtTelephone.Text = info.Telephone;
            lblCreateDate.Text = info.DateCreate.Value.ToString("dd/MM/yyyy");
            rdpBirthday.SelectedDate = info.Birthday;
            txtAbstract.Text = info.Description;
            txtUserName.Text = info.UserName;
            txtUserName.Visible = false;
            lblUserName.Visible = true;
        }
    }    
    protected void lbtSave_Click(object sender, EventArgs e)
    {        
        CtrAdmin ctrAdmin = new CtrAdmin();
        var ret = ctrAdmin.AdminUpdate(AdminID, txtFullName.Text, rdpBirthday.SelectedDate.Value, txtEmail.Text, txtTelephone.Text, txtAbstract.Text);     
        if (ret> 0)
        {
            lblMsg.Text = "Cập nhật thành công";
        }
        else
            lblMsg.Text = "Cập nhật thất bại!";
    }   
}