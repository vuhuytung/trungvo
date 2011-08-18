using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class userControls_ucWeather : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadData("http://vnexpress.net/ListFile/Weather/hanoi.xml");
            }
            catch {
                divWeather.Visible = false;
            }
        }
    }

    // Hàm bind dữ liệu xml ra DataTable

    private DataTable GetTable(string FileName)
    {
        DataTable dtb = new DataTable();
        DataSet authorsDataSet;
        string filePath = FileName;
        authorsDataSet = new DataSet();
        authorsDataSet.ReadXml(filePath);
        dtb = authorsDataSet.Tables[0];
        return dtb;
    }

    // Load dữ liệu theo filepath

    private void LoadData(string xmlFilePath)
    {
        DataTable dtb = GetTable(xmlFilePath);
        if (dtb.Rows.Count > 0)
        {
            Literal1.Text = "<div style='width:100px;' class='nl'>&nbsp;<img src='http://vnexpress.net/Images/Weather/" + dtb.Rows[0][0].ToString().Trim() + "'>";
            Literal1.Text += "&nbsp;<img src='http://vnexpress.net/Images/Weather/" + dtb.Rows[0][1].ToString().Trim() + "'>";
            Literal1.Text += "&nbsp;<img src='http://vnexpress.net/Images/Weather/" + dtb.Rows[0][2].ToString().Trim() + "'>";
            Literal1.Text += "&nbsp;<img src='http://vnexpress.net/Images/Weather/c.gif'></div>";
            Literal1.Text += "" + dtb.Rows[0][6].ToString().Trim();
        }

        dtb.Dispose();

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData("http://vnexpress.net/ListFile/Weather/" + DropDownList1.SelectedValue.ToString());

    }
}