using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class userControls_ucExRate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ds.ReadXml("http://www.vietcombank.com.vn/ExchangeRates/ExrateXML.aspx");
            DataTable tb = ds.Tables[1];
            DataTable tb1 = new DataTable();
            tb1.Columns.Add("CurrencyCode");
            tb1.Columns.Add("Buy");
            tb1.Columns.Add("Sell");
            foreach (DataRow row in tb.Rows)
            {
                double buy = 0.0;
                double sell = 0.0;
                try { buy = Convert.ToDouble(row["Buy"]); sell = Convert.ToDouble(row["Sell"]); }
                catch { }
                if ((buy!=0) && (sell!=0))
                {
                    var r1=tb1.NewRow();
                    r1["CurrencyCode"] = row["CurrencyCode"].ToString();
                    r1["Buy"] = buy.ToString("0,0.00");
                    r1["Sell"] = sell.ToString("0,0.00");
                    tb1.Rows.Add(r1);
                }
            }
            GridView1.DataSource = tb1;
            GridView1.DataBind();

            if (tb1.Rows.Count == 0)
                divExRate.Visible = false;
        }
       catch
        {
            divExRate.Visible = false;
        }
    }
}