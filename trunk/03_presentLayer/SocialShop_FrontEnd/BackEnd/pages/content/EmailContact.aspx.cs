using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class BackEnd_pages_content_EmailContact : System.Web.UI.Page
{
    CtrSendMail mail = new CtrSendMail();   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRpt();
        }
    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (mail.insertEmail(txtEmail.Text, chkstatus.Checked == true ? 1 : 0) > 0)
            {
                BindRpt();
                ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Thêm mới thành công !')", true);
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Thêm mới thất bại !')", true);
        }
        catch
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Thêm mới thất bại !')", true);
        }
    }
    protected void btnHuy1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = true;
    }

            
    void BindRpt()
    {
        RptEmail.DataSource = mail.GetEmailAll(0);
        RptEmail.DataBind();
    }
    protected void RptEmail_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        LinkButton lblUpdate = (LinkButton)RptEmail.Items[e.Item.ItemIndex].FindControl("lbtUpdate");
        LinkButton lblCancel = (LinkButton)RptEmail.Items[e.Item.ItemIndex].FindControl("lbtCancel");
        LinkButton lblEdit = (LinkButton)RptEmail.Items[e.Item.ItemIndex].FindControl("lbtEdit");
        TextBox txtEmail = (TextBox)RptEmail.Items[e.Item.ItemIndex].FindControl("txtEmail");
        Label lblEmail = (Label)RptEmail.Items[e.Item.ItemIndex].FindControl("lblEmail");
        if (e.CommandName == "Edit")
        {
            try
            {
                
                if(lblCancel!=null && lblEdit!=null && lblUpdate!=null)
                {
                    lblUpdate.Visible = true;
                    lblCancel.Visible = true;
                    lblEdit.Visible = false;
                    lblEmail.Visible = false;
                    txtEmail.Visible = true;
                }

            }
            catch
            {
            }
        }
        else if(e.CommandName=="Cancel")
        {
            try
            {
                /*LinkButton lblUpdate = (LinkButton)RptEmail.Items[e.Item.ItemIndex].FindControl("lbtUpdate");
                LinkButton lblCancel = (LinkButton)RptEmail.Items[e.Item.ItemIndex].FindControl("lbtCancel");
                LinkButton lblEdit = (LinkButton)RptEmail.Items[e.Item.ItemIndex].FindControl("lbtEdit");
                TextBox txtEmail = (TextBox)RptEmail.Items[e.Item.ItemIndex].FindControl("txtEmail");
                Label lblEmail = (Label)RptEmail.Items[e.Item.ItemIndex].FindControl("lblEmail");*/
                if (lblCancel != null && lblEdit != null && lblUpdate != null)
                {
                    lblUpdate.Visible = false;
                    lblCancel.Visible = false;
                    lblEdit.Visible = true;
                    txtEmail.Visible = false;
                    lblEmail.Visible = true;
                    BindRpt();
                }

            }
            catch
            {
            }
        }
        else if (e.CommandName == "Update")
        {
            try
            {
                //TextBox txtEmail = (TextBox)RptEmail.Items[e.Item.ItemIndex].FindControl("txtEmail");
                CheckBox chkStatus = (CheckBox)RptEmail.Items[e.Item.ItemIndex].FindControl("chkStatus");
                if (mail.UpdateEmail(Int32.Parse(e.CommandArgument.ToString()), txtEmail.Text, chkStatus.Checked == true ? 1 : 0) > 0)
                {
                    lblUpdate.Visible = false;
                    lblCancel.Visible = false;
                    lblEdit.Visible = true;
                    txtEmail.Visible = false;
                    lblEmail.Visible = true;
                    BindRpt();
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Cập nhật thành công !')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Cập nhật thất bại!')", true);
                }
                    
            }
            catch
            {

            }

        }
        else if (e.CommandName == "Delete")
        {
            try
            {
                if (mail.DeleteEmail(Int32.Parse(e.CommandArgument.ToString())) > 0)
                {
                    BindRpt();
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Xóa thành công !')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Xóa thất bại !')", true);
                }
            }
            catch
            {
            }
        }
    }
}