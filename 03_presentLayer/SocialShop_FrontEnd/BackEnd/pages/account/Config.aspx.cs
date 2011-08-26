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

public partial class BackEnd_pages_account_Config : System.Web.UI.Page
{
    protected int permission = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session[Constants.SESSION_ADMIN_ISLOGIN] ?? false))
            Response.Redirect("/admin/login");
        if (!IsPostBack)
        {
            CtrAdmin ctrAdmin = new CtrAdmin();
            var info = ctrAdmin.GetConfigInfo();
            txtAddress.Text=info.Address;
            txtEmail.Text = info.Email;
            txtPhone.Text = info.Phone;
            txtYahoo1.Text = info.Yahoo1;
            txtTextYahoo1.Text = info.TextYahoo1;
            txtYahoo2.Text = info.Yahoo2;
            txtTextYahoo2.Text = info.TextYahoo2;
            txtYahoo3.Text = info.Yahoo3;
            txtTextYahoo3.Text = info.TextYahoo3;

            txtSkype1.Text = info.Skype1;
            txtTextSkype1.Text = info.TextSkype1;
            txtSkype2.Text = info.Skype2;
            txtTextSkype2.Text = info.TextSkype2;
            txtSkype3.Text = info.Skype3;
            txtTextSkype3.Text = info.TextSkype3;
        }
        lblMsg.Text = "";
    }    
    protected void lbtSave_Click(object sender, EventArgs e)
    {        
        
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        if (!((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT))
            lblMsg.Text = "Bạn không có quyền!";
        CtrAdmin ctrAdmin = new CtrAdmin();
        var ret = ctrAdmin.UpdateSiteConfig(txtYahoo1.Text.Trim(), txtTextYahoo1.Text.Trim(), txtYahoo2.Text.Trim(), txtTextYahoo2.Text.Trim(), txtYahoo3.Text.Trim(), txtTextYahoo3.Text.Trim(),
                                            txtSkype1.Text.Trim(), txtTextSkype1.Text.Trim(), txtSkype2.Text.Trim(), txtTextSkype2.Text.Trim(), txtSkype3.Text.Trim(), txtTextSkype3.Text.Trim(),
                                            txtPhone.Text.Trim(), txtAddress.Text.Trim(), txtEmail.Text.Trim());
        if (ret> 0)
        {
            lblMsg.Text = "Cập nhật thành công";
        }
        else
            lblMsg.Text = "Cập nhật thất bại!";
    }   
}