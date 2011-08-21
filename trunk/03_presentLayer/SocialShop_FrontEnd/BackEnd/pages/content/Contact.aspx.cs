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

public partial class BackEnd_pages_content_Contact : System.Web.UI.Page
{

    protected int permission = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(pageChange);
        if (!IsPostBack)
        {
            rdpFromDate.SelectedDate = DateTime.Now.AddMonths(-12);
            rdpToDate.SelectedDate = DateTime.Now;

            CtrCategory ctrCat = new CtrCategory();
            var tb = ctrCat.GetNewsMenu();

            ucPaging1.PageSize = 10;
            ucPaging1.CurrentPage = 1;
            ucPaging1.PageDisplay = 10;
            pageChange(ucPaging1);
        }
        lblMsg.Text = "";
    }

    protected void pageChange(object sender)
    {
        ucPaging1.Visible = false;
        if ((!rdpFromDate.SelectedDate.HasValue) || (!rdpToDate.SelectedDate.HasValue))
        {
            lblMsg.Text = "Ngày tháng tìm kiếm không hợp lệ!";
            return;
        }

        if (rdpFromDate.SelectedDate.Value.CompareTo(rdpToDate.SelectedDate.Value)>0)
        {
            lblMsg.Text = "Ngày tháng tìm kiếm không hợp lệ!";
            return;
        }

        CtrNews ctrNews = new CtrNews();
        var list = ctrNews.ContactGetList(rdpFromDate.SelectedDate.Value, rdpToDate.SelectedDate.Value, Convert.ToInt32(ddlStatus.SelectedValue),ucPaging1.CurrentPage, ucPaging1.PageSize);

        ucPaging1.TotalRecord = list.TotalRecord;
        ucPaging1.Visible = ucPaging1.TotalPage > 1;

        rptAllNews.DataSource = list.Items;
        rptAllNews.DataBind();
        if (list.TotalRecord > 0)
        {
            rptAllNews.Visible = true;
            pNoRow.Visible = false;
        }
        else
        {
            rptAllNews.Visible = false;
            pNoRow.Visible = true;
        }
    }
    protected void rptAllNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlGenericControl divListRow = e.Item.FindControl("divListRow") as HtmlGenericControl;
            if (divListRow == null)
            {
                return;
            }
            if (e.Item.ItemIndex % 2 == 0)
            {
                divListRow.Attributes["class"] = "adminListRow-even";
            }

            if (Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "Status")))
            {
                if ((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT)
                    (e.Item.FindControl("lbtUnLock") as LinkButton).Visible = false;
            }
        }

    }
    protected void rptAllNews_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        CtrNews ctrNews = new CtrNews();
        if (e.CommandArgument == null) return;

        if (e.CommandName == "unlockNews")
        {
            if (ctrNews.ContactUpdateStatus(Convert.ToInt32(e.CommandArgument), 1) > 0)
            {
                pageChange(ucPaging1);
                lblMsg.Text = "Cập nhật thành công";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");
            }
            else
            {
                lblMsg.Text = "Cập nhật thất bại";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
            }
        }
        
        if (e.CommandName == "delete")
        {
            if (ctrNews.ContactDelete(Convert.ToInt32(e.CommandArgument)) > 0)
            {
                lblMsg.Text = "Đã xóa thành công";
                ucPaging1.CurrentPage = 1;
                pageChange(ucPaging1);
            }
            else
            {
                //RadAjaxPanel1.ResponseScripts.Add("alert('Không xóa được!')");
                lblMsg.Text = "Không xóa được";
            }
        }
    }    

    protected void lbtDeleteAll_Click(object sender, EventArgs e)
    {                
        CtrNews ctrNews = new CtrNews();
        var ids = "";
        foreach (RepeaterItem item in rptAllNews.Items)
        {
            CheckBox cbxCheck = item.FindControl("cbxCheck") as CheckBox;
            HiddenField hdfNewsID = item.FindControl("hdNewsID") as HiddenField;
            if (cbxCheck.Checked)
            {
                ids+=","+(hdfNewsID.Value);
            }
        }
        if (ctrNews.ContactDeleteMulti(ids) > 0)
        {
            lblMsg.Text = "Xóa thành công!";
            ucPaging1.CurrentPage = 1;
            pageChange(ucPaging1);
        }else
            lblMsg.Text = "Không xóa được!";
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        ucPaging1.CurrentPage = 1;
        pageChange(ucPaging1);
    }
}