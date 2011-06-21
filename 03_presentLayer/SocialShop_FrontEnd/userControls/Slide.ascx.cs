using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class userControls_Slide : System.Web.UI.UserControl
{
    CtrSlideShow project = new CtrSlideShow();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal1.Text = project.GenHtmlSlide();
        
        } 
           
    }
    
}