using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using VTCO.Config;

public partial class ChangePass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session[Constants.SESSION_USER_ISLOGIN] ?? false))
            Response.Redirect("~/login");
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session[Constants.SESSION_USER_ISLOGIN] ?? false))
            Response.Redirect("~/login");
        int id = Convert.ToInt32(Session[Constants.SESSION_USER_ID] ?? -1);
        CtrUser acc = new CtrUser();
        var dt = acc.ChangePass(id, VTCO.Utils.Encryption.GetMD5(this.txtPassOld.Text.Trim()), VTCO.Utils.Encryption.GetMD5(this.txtPassword.Text.Trim()));
       
        if (dt>0)
        {
            this.lblmsg.Text = "Cập nhật thành công !!<br/><br/>";
        }
        else
        {
            if(dt==-1)
                this.lblmsg.Text = "Mật khẩu cũ không đúng!<br/><br/>";
            else
                this.lblmsg.Text = "Có lỗi xảy ra!<br/><br/>";
        }
    }
}