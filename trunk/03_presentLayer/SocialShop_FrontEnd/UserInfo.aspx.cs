using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;

public partial class UserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Thay đổi thông tin cá nhân";
        if (!Convert.ToBoolean(Session[VTCO.Config.Constants.SESSION_USER_ISLOGIN] ?? false))
            Response.Redirect("~/login");
        if (!IsPostBack)
        {
            CtrUser ctrU = new CtrUser();
            var info = ctrU.UserGetInfo(Convert.ToInt32(Session[VTCO.Config.Constants.SESSION_USER_ID] ?? -1));
            lblUserName.Text = info.UserName;
            txtFullName.Text = info.FullName;
            txtEmail.Text = info.Email;
            rdpBirthday.SelectedDate = info.Birthday;
            txtAddress.Text = info.Address;
            txtMobile.Text = info.Phone;
        }
    }
    protected void btnRegistor_Click(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session[VTCO.Config.Constants.SESSION_USER_ISLOGIN] ?? false))
            Response.Redirect("~/login");
        CtrUser ctrUser = new CtrUser();
        if (ctrUser.Update(Convert.ToInt32(Session[VTCO.Config.Constants.SESSION_USER_ID] ?? -1), txtFullName.Text.Trim(), rdpBirthday.SelectedDate.Value, txtAddress.Text.Trim(), txtMobile.Text.Trim(), txtEmail.Text.Trim()) > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Cập nhật thành công!')", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Có lỗi xảy ra! Xin lỗi bạn vì sự bất tiện này')", true);
        }
    }
}