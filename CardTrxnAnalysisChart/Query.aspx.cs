using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Query : System.Web.UI.Page
{
    public string rq;
    public string dtm;
    public string hr;
    public string ch;
    Utils u = new Utils();
    protected void Page_Load(object sender, EventArgs e)
    {
        rq = "0";dtm = "0";
        var dte = DateTime.Now;
        var dtp = dte.ToString("yyyy-MM-dd");
        hr = "0";ch = "ATM";
        try
        {
            rq = Convert.ToString(Request.Params["rq"]);
            dtm = Convert.ToString(Request.Params["dtm"]);
            hr = Convert.ToString(Request.Params["data"]);
            ch = Convert.ToString(Request.Params["ch"]);
            int h = 0;
            int p = 0;

            try
            {
                h = Convert.ToInt16(hr);
                p = Convert.ToInt16(dtm);
            }
            catch (Exception ex)
            {

            }

            if ((h > 12) && ((h - 12) > p))
            {
                dtp = dte.AddDays(-1).ToString("yyyy-MM-dd");
            }
        }
        catch
        {

        }
        lblRpt.Text = "Report Details for " + dtp + " " + hr;
        GridView1.DataSource = u.GetOnUsTerminalHourSummary(rq,ch,dtp,hr);
        GridView1.DataBind();
    }
}