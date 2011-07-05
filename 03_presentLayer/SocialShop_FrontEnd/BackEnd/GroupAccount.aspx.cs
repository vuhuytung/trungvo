using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using DataObject;
using Telerik.Web.UI;
using VTCO.Config;
using System.Collections.Generic;
using System.Data;
using VTCO.Encrypt;

public partial class GroupAccount : BasePage 
{
    public int GroupID
    {
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["GroupID"]);
            }
            catch
            {
                return -1;
            }
        }

        set
        {
            ViewState["GroupID"] = value;
        }
    }
    public int AccountID
    {
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["AccountID"]);
            }
            catch
            {
                return -1;
            }
        }

        set
        {
            ViewState["AccountID"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Group();
            divListUser.Visible = true;
            divInfo .Visible = false;
        }

    }

    protected void Bind_Group()
    {
        GroupDB GroupDB = new GroupDB();
        DataTable tblGroup = GroupDB.GetAll();
        tblGroup.Columns.Add("STT");
        for (int i = 1; i <= tblGroup.Rows.Count; i++)
        {
            tblGroup.Rows[i - 1]["STT"] = i;
        }
        rptNewsList.DataSource = tblGroup;
        rptNewsList.DataBind();
    }

    protected void Bind_User(int GroupID)
    {
        AccountManagement AccMNG = new AccountManagement();
        DataTable tblUser = AccMNG.GetAllAccountOfGroupForManager(GroupID);
        tblUser.Columns.Add("STT");
        int i = 0;
        foreach (DataRow dr in tblUser.Rows)
        { 
            i++;
            dr["STT"] = i;
        }
        rptListUser.DataSource = tblUser;
        rptListUser.DataBind();

    }
    protected void rptNewsList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
        if (e.CommandName == "edit")
        {
            GroupID = Convert.ToInt32(e.CommandArgument);
            Bind_User(GroupID);
            divListUser.Visible = true;
            divInfo.Visible = false;
        }
    }
    protected void rptNewsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void linkAddNewUser_Click(object sender, EventArgs e)
    {
        NationalDB NationalDB = new NationalDB();
        ddlNational.DataSource = NationalDB.GetAll();
        ddlNational.DataBind();

        txtUserName.Text = "";
        txtPass.Text = "";
        txtFullName.Text = "";
        txtDateOfBirth.SelectedDate = DateTime.Now;

        rptSex.Items[0].Selected = true;
        txtEmail.Text = "";
        txtMobile .Text  = "";
        chkEnable.Checked = false ;

        linkSaveEdit.Visible = false ;
        linkSave.Visible = true ;

        divListUser.Visible = false;
        divInfo.Visible = true;

        


    }
    protected void linkSaveEdit_Click(object sender, EventArgs e)
    {
        AccountDB  AccountDB = new AccountDB();
        AccountInfo objAcc = new AccountInfo();
        objAcc.AccountID = AccountID;
        objAcc.NationalID = Convert.ToInt32 (ddlNational.Text);
        objAcc.UserName = txtUserName.Text;
        objAcc.Password = Encryption.GetMD5( txtPass.Text);
        objAcc.Name = txtFullName.Text;
        objAcc.DateOfBirth = txtDateOfBirth.SelectedDate.Value;
        objAcc.Email = txtEmail.Text;
        objAcc.Mobile = txtMobile.Text;
        objAcc.Sex = rptSex.Items[0].Selected;
        objAcc.isAdmin = false;
        objAcc.Status = chkEnable.Checked;
        AccountDB.Update(objAcc);
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void linkSave_Click(object sender, EventArgs e)
    {
        AccountDB AccountDB = new AccountDB();
        AccountInfo objAcc = new AccountInfo();
        objAcc.NationalID = Convert.ToInt32(ddlNational.Text);
        objAcc.UserName = txtUserName.Text;
        objAcc.Password = Encryption.GetMD5(txtPass.Text);
        objAcc.Name = txtFullName.Text;
        objAcc.DateOfBirth = txtDateOfBirth.SelectedDate.Value;
        objAcc.Email = txtEmail.Text;
        objAcc.Mobile = txtMobile.Text;
        objAcc.Sex = rptSex.Items[0].Selected;
        objAcc.isAdmin = false;
        objAcc.Status = chkEnable.Checked;
        int AccID=AccountDB.Insert(objAcc).Value ;

        GroupUserDB GroupUserDB = new GroupUserDB();
        GroupUserInfo objGroupUser=new GroupUserInfo ();
        objGroupUser.AccountID =AccID ;
        objGroupUser.GroupID =GroupID;
        GroupUserDB.Insert(objGroupUser);

        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void linkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void rptListUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        AccountDB AccDB = new AccountDB();
        if (e.CommandName == "delete")
        {
            AccountID  = Convert.ToInt32(e.CommandArgument);
            AccountManagement AccMNG = new AccountManagement();
            AccMNG.DeleteAccIntoGroupUser(AccountID);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        if (e.CommandName == "edit")
        {
            AccountID = Convert.ToInt32(e.CommandArgument);
            AccountInfo objAcc = AccDB.GetInfo(AccountID);

            NationalDB NationalDB = new NationalDB();
            ddlNational.DataSource = NationalDB.GetAll();
            ddlNational.DataBind();

            ddlNational.Text = objAcc.NationalID.Value.ToString ();
            txtUserName.Text = objAcc.UserName;
            txtPass.Text = objAcc.Password;
            txtFullName.Text = objAcc.Name;
            if (objAcc.DateOfBirth != null)
                txtDateOfBirth.SelectedDate = objAcc.DateOfBirth.Value;
            else txtDateOfBirth.SelectedDate = DateTime.Now;

            if(objAcc.Sex.Value ==true )
                rptSex.Items[0].Selected = true; 
            else
                rptSex.Items[1].Selected = true;
             txtEmail.Text=objAcc.Email ;
             txtMobile .Text  = objAcc.Mobile;
             chkEnable.Checked = objAcc.Status.Value;
 
            
            divListUser.Visible = false;
            divInfo.Visible = true;

            linkSaveEdit.Visible = true;
            linkSave.Visible = false;
        }
    }
}
