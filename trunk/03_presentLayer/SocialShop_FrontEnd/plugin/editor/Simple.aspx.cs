using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VTCO.Library;
public partial class plugin_editor_Simple : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnComment_Click(object sender, EventArgs e)
    {
        string strComment = Lib.ReplaceEmotion(txtComment.Value.Trim()).Replace("\r\n", string.Empty).Replace("\n", string.Empty);
        lblComment.Text = strComment;
    }
}