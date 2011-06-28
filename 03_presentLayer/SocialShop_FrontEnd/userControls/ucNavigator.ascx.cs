using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userControls_ucNavigator : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrNavigator.Text = "<a href='#'>Trang chủ</a> » <a href='#'>Giới thiệu</a>";
    }
}