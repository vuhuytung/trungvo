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
            txtAddress.Text = HtmlUtility.HtmlDecode(info.Address);
            txtEmail.Text = HtmlUtility.HtmlDecode(info.Email);
            txtPhone.Text = HtmlUtility.HtmlDecode(info.Phone);
            txtYahoo1.Text = HtmlUtility.HtmlDecode(info.Yahoo1);
            txtTextYahoo1.Text = HtmlUtility.HtmlDecode(info.TextYahoo1);
            txtYahoo2.Text = HtmlUtility.HtmlDecode(info.Yahoo2);
            txtTextYahoo2.Text = HtmlUtility.HtmlDecode(info.TextYahoo2);
            txtYahoo3.Text = HtmlUtility.HtmlDecode(info.Yahoo3);
            txtTextYahoo3.Text = HtmlUtility.HtmlDecode(info.TextYahoo3);

            txtSkype1.Text = HtmlUtility.HtmlDecode(info.Skype1);
            txtTextSkype1.Text = HtmlUtility.HtmlDecode(info.TextSkype1);
            txtSkype2.Text = HtmlUtility.HtmlDecode(info.Skype2);
            txtTextSkype2.Text = HtmlUtility.HtmlDecode(info.TextSkype2);
            txtSkype3.Text = HtmlUtility.HtmlDecode(info.Skype3);
            txtTextSkype3.Text = HtmlUtility.HtmlDecode(info.TextSkype3);
        }
        lblMsg.Text = "";
    }    
    protected void lbtSave_Click(object sender, EventArgs e)
    {        
        
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        if (!((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT))
            lblMsg.Text = "Bạn không có quyền!";
        CtrAdmin ctrAdmin = new CtrAdmin();
        var ret = ctrAdmin.UpdateSiteConfig(HtmlUtility.HtmlEncode(txtYahoo1.Text.Trim()), HtmlUtility.HtmlEncode(txtTextYahoo1.Text.Trim()),HtmlUtility.HtmlEncode(txtYahoo2.Text.Trim()),HtmlUtility.HtmlEncode(txtTextYahoo2.Text.Trim()),HtmlUtility.HtmlEncode(txtYahoo3.Text.Trim()),HtmlUtility.HtmlEncode(txtTextYahoo3.Text.Trim()),
                                            HtmlUtility.HtmlEncode(txtSkype1.Text.Trim()),HtmlUtility.HtmlEncode(txtTextSkype1.Text.Trim()),HtmlUtility.HtmlEncode(txtSkype2.Text.Trim()),HtmlUtility.HtmlEncode(txtTextSkype2.Text.Trim()),HtmlUtility.HtmlEncode(txtSkype3.Text.Trim()),HtmlUtility.HtmlEncode(txtTextSkype3.Text.Trim()),
                                            HtmlUtility.HtmlEncode(txtPhone.Text.Trim()),HtmlUtility.HtmlEncode(txtAddress.Text.Trim()),HtmlUtility.HtmlEncode(txtEmail.Text.Trim()));
        if (ret> 0)
        {
            lblMsg.Text = "Cập nhật thành công";
        }
        else
            lblMsg.Text = "Cập nhật thất bại!";
    }   
}