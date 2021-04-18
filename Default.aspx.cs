﻿using Sterling.MSSQL;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    Utils u = new Utils();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    ChartATM.Series["Series1"].ToolTip = "#VALX";
        //    ChartATM.Series["Series2"].ToolTip = "#VALX";

        //    ChartPOS.Series["Series1"].ToolTip = "#VALX";
        //    ChartPOS.Series["Series2"].ToolTip = "#VALX";

        //    ChartOTH.Series["Series1"].ToolTip = "#VALX";
        //    ChartOTH.Series["Series2"].ToolTip = "#VALX";
        //}
        
        DataTable atmDt = u.GetTerminalHTML("1","ATM");
        ChartATM.DataSource = atmDt;
        ChartATM.DataBind();
        ChartATM.Titles[0].Font = new Font("Century Gothic", 15, FontStyle.Bold);
        ChartATM.ChartAreas[0].AxisX.Interval = 1;
        ChartATM.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        ChartATM.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
        ChartATM.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        ChartATM.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        ChartATM.Series[0].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartATM.Series[1].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartATM.Series[2].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartATM.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Bold);
        ChartATM.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Bold);


        DataTable posDt = u.GetTerminalHTML("1", "POS");
        ChartPOS.DataSource = posDt;
        ChartPOS.DataBind();
        ChartPOS.Titles[0].Font = new Font("Century Gothic", 15, FontStyle.Bold);
        ChartPOS.ChartAreas[0].AxisX.Interval = 1;
        ChartPOS.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        ChartPOS.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
        ChartPOS.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        ChartPOS.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        ChartPOS.Series[0].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartPOS.Series[1].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartPOS.Series[2].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartPOS.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Bold);
        ChartPOS.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Bold);

        DataTable othDt = u.GetTerminalHTML("1", "OTHERS");
        ChartOTH.DataSource = othDt;
        ChartOTH.DataBind();
        ChartOTH.Titles[0].Font = new Font("Century Gothic", 15, FontStyle.Bold);
        ChartOTH.ChartAreas[0].AxisX.Interval = 1;
        ChartOTH.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        ChartOTH.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
        ChartOTH.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        ChartOTH.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        ChartOTH.Series[0].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartOTH.Series[1].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartOTH.Series[2].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartOTH.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Bold);
        ChartOTH.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Bold);

        DataTable nouDt = u.GetTerminalHTML("4", "ATM");
        ChartNOU.DataSource = nouDt;
        ChartNOU.DataBind();
        ChartNOU.Titles[0].Font = new Font("Century Gothic", 15, FontStyle.Bold);
        ChartNOU.ChartAreas[0].AxisX.Interval = 1;
        ChartNOU.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        ChartNOU.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
        ChartNOU.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        ChartNOU.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        ChartNOU.Series[0].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartNOU.Series[1].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartNOU.Series[2].Font = new Font("Arial", 8, FontStyle.Bold);
        ChartNOU.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Bold);
        ChartNOU.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Bold);
    }
    public DataTable GetTerminalHTML(string crd, string term)
    {
        var ds = new DataSet();
        var dte = DateTime.Now;
        DataTable dt = new DataTable();
        dt.Columns.Add("Date", typeof(string));
        dt.Columns.Add("Hour",typeof(string));
        dt.Columns.Add("Success", typeof(int));
        dt.Columns.Add("Failed", typeof(int));
        dt.Columns.Add("Timeout", typeof(int));

        string totals_grp = string.Empty;
        if (crd == "1")
        {
            totals_grp = "'SBPFLUTGrp','SBPGroup','MASTERGroup','SBPVISACGrp','SBPVISADGrp'";
        }
        else if (crd == "2")
        {
            totals_grp = "'IMALNAIRAGrp'";
        }
        else if (crd == "3")
        {
            totals_grp = "'SBPABUGroup','SBPACEGroup','SBPAFEGroup','SBPALEKGroup','SBPALHAGroup','SBPAMMLGrp','SBPAPPLEGrp','SBPAPViGroup','SBPBABURAGrP','SBPBARNAWGrp','SBPBCKASHGrp','SBPBISGroup','SBPBOKKOSGrp','SBPBORSTGrp','SBPBOWENGrp','SBPBUKGroup','SBPCALGroup','SBPCALMGroup','SBPCEDGroup','SBPCHAGroup','SBPCITGrp','SBPCONPRGrp','SBPCONSGroup','SBPCORGroup','SBPCRDAFRGrp','SBPCROSGroup','SBPDRSGroup','SBPDYNAGroup','SBPEBARGroup','SBPECHGroup','SBPEKOGroup','SBPEMPGroup','SBPESOEGroup','SBPFCTGroup','SBPFFSGroup','SBPFIMGroup','SBPFINGroup','SBPFRANGEGrp','SBPFROYGroup','SBPGARKIGrp','SBPGARUGroup','SBPGATEGroup','SBPGUFGroup','SBPHEADGroup','SBPSBPHINAGrp','SBPILORINGrp','SBPIMOWOGrp','SBPKADGroup','SBPKCMBGroup','SBPKEBBIGrp','SBPMARIGroup','SBPMBGroup','SBPMETGroup','SBPMFBGenGrp','SBPNAGARGrp','SBPNDIOGroup','SBPNIGPRIGrp','SBPNORTHBGrp','SBPNPFCrGrp','SBPNPFGroup','SBPOHAGroup','SBPOOUGrp','SBPPARCGroup','SBPPARGroup','SBPPOLGroup','SBPPROGGroup','SBPPTRUSTGrp','SBPREFGroup','SBPRICGroup','SBPSABIGroup','SBPSHALOMGrp','SBPSHONGGrp','SBPSOVGroup','SBPSTANGrp','SBPSTGroup','SBPSULSAPGrp','SBPTCFGroup','SBPUDAGrp','SBPVIRTUEGrp','SBPVirtuGrp','SBPVISGroup','SBROYALEXGrp','STERLFIGroup','VISAGroup'";
        }
        else
        {
            totals_grp = "'SBPFLUTGrp','SBPGroup','MASTERGroup','SBPVISACGrp','SBPVISADGrp'";
        }

        var cond = string.Empty;var grps = string.Empty;
        if (term == "ATM")
        {
            cond = " AND right([pos_data_code],2) = '02' ";
        }
        else if (term == "POS")
        {
            cond = " AND right([pos_data_code],2) = '01' ";
        }
        else
        {
            cond = " AND right([pos_data_code],2) NOT IN ('01','02') ";
        }

        int y = 0;//for (int i = 0; i < 12; i++)
        for (int i = 11; i >= 0; i--)
        {
            if (i != 0)
            {
                y = Convert.ToInt16("-" + i);
            }
            else
            {
                y = 0;
            }
            var dt0 = dte.AddHours(y);
            var hr = dt0.ToString("HH");
            var h = dt0.ToString("yyyy-MM-dd HH");
            var dt1 = h + ":00:00.000";
            var dt2 = h + ":59:59.999";
            //string sql = @"SELECT MAX(rsp_code_rsp),Response,COUNT(RRN) AS Count FROM[postilion_office].[dbo].[vw_FullTrxnDet]
            //              WHERE totals_group IN(SELECT totals_group FROM tbl_totalsGroup_mapping WHERE category IN (@crd))
            //              AND message_type IN ('0100', '0200', '0600', '0220') " + cond + "AND Transaction_Date BETWEEN @dt1 AND @dt2 " +
            //             "GROUP BY Response ORDER BY Count desc ";

            string sql = @"select MAX(rsp_code_req_rsp), CASE
					WHEN rsp_code_req_rsp = '00' THEN 'Approved or completed successfully'
					WHEN rsp_code_req_rsp = '01' THEN 'Refer to card issuer'
					WHEN rsp_code_req_rsp = '02' THEN 'Refer to card issuer, special condition'
					WHEN rsp_code_req_rsp = '04' THEN 'Pick-up card'
					WHEN rsp_code_req_rsp = '05' THEN 'Do not honor'
					WHEN rsp_code_req_rsp = '06' THEN 'Error'
					WHEN rsp_code_req_rsp = '09' THEN 'Request in progress'
					WHEN rsp_code_req_rsp = '12' THEN 'Invalid transaction'
					WHEN rsp_code_req_rsp = '13' THEN 'Invalid amount'
					WHEN rsp_code_req_rsp = '14' THEN 'Invalid card number'
					WHEN rsp_code_req_rsp = '15' THEN 'No such issuer'
					WHEN rsp_code_req_rsp = '17' THEN 'Customer cancellation'
					WHEN rsp_code_req_rsp = '20' THEN 'Invalid response'
					WHEN rsp_code_req_rsp = '22' THEN 'Suspected malfunction'
					WHEN rsp_code_req_rsp = '25' THEN 'Unable to locate record'
					WHEN rsp_code_req_rsp = '26' THEN 'Duplicate record'
					WHEN rsp_code_req_rsp = '30' THEN 'Format error'
					WHEN rsp_code_req_rsp = '36' THEN 'Restricted card, pick-up'
					WHEN rsp_code_req_rsp = '38' THEN 'PIN tries exceeded, pick-up'
					WHEN rsp_code_req_rsp = '39' THEN 'No credit account'
					WHEN rsp_code_req_rsp = '40' THEN 'Function not supported'
					WHEN rsp_code_req_rsp = '41' THEN 'Lost card, pick-up'
					WHEN rsp_code_req_rsp = '42' THEN 'No universal account'
					WHEN rsp_code_req_rsp = '43' THEN 'Stolen card, pick-up'
					WHEN rsp_code_req_rsp = '51' THEN 'Not sufficient funds'
					WHEN rsp_code_req_rsp = '52' THEN 'No check account'
					WHEN rsp_code_req_rsp = '53' THEN 'No savings account'
					WHEN rsp_code_req_rsp = '54' THEN 'Expired card'
					WHEN rsp_code_req_rsp = '55' THEN 'Incorrect PIN'
					WHEN rsp_code_req_rsp = '56' THEN 'No card record'
					WHEN rsp_code_req_rsp = '57' THEN 'Transaction not permitted to cardholder'
					WHEN rsp_code_req_rsp = '58' THEN 'Transaction not permitted on terminal'
					WHEN rsp_code_req_rsp = '59' THEN 'Suspected fraud'
					WHEN rsp_code_req_rsp = '60' THEN 'Contact acquirer'
					WHEN rsp_code_req_rsp = '61' THEN 'Exceeds withdrawal limit'
					WHEN rsp_code_req_rsp = '62' THEN 'Restricted card'
					WHEN rsp_code_req_rsp = '65' THEN 'Exceeds withdrawal frequency'
					WHEN rsp_code_req_rsp = '68' THEN 'Response received too late'
					WHEN rsp_code_req_rsp = '75' THEN 'PIN tries exceeded'
					WHEN rsp_code_req_rsp = '90' THEN 'Cut-off in progress'
					WHEN rsp_code_req_rsp = '91' THEN 'Issuer or switch inoperative'
					WHEN rsp_code_req_rsp = '92' THEN 'Routing error'
					WHEN rsp_code_req_rsp = '94' THEN 'Duplicate transaction'
					WHEN rsp_code_req_rsp = '95' THEN 'Reconcile error'
					WHEN rsp_code_req_rsp = '96' THEN 'System malfunction'
					ELSE rsp_code_req_rsp+'-Unlisted Response Code'
				END as Response, count(ret_ref_no) as Count
				from tm_trans with (nolock) where totals_group in (@crd) 
AND msg_type IN ('512', '256', '1536', '544')  " + cond + " AND in_req BETWEEN @dt1 AND @dt2 GROUP BY rsp_code_req_rsp ORDER BY Count(ret_ref_no) desc ";

            Connect cn = new Connect("FEPConn")
            {
                Persist = true
            };
            cn.SetSQL(sql);
            cn.AddParam("@dt1", dt1);
            cn.AddParam("@dt2", dt2);
            cn.AddParam("@crd", totals_grp);
            ds = cn.Select();
            cn.CloseAll();
            var termHTL = string.Empty;

            bool hasRow = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);
            if (hasRow)
            {
                var tot = 0; var suc = 0; var fail = 0; var userf = 0; var systemf = 0;
                var timeout = 0;
                var rows = ds.Tables[0].Rows.Count;
                var tru = string.Empty; var trs = string.Empty;
                var dttt = dt0.ToString("yyyy-MM-dd");
                for (int j = 0; j < rows; j++)
                {
                    DataRow dr = ds.Tables[0].Rows[j];
                    var rsp = dr[0].ToString();
                    var cnt = dr[2].ToString();

                    tot += Convert.ToInt32(cnt);
                    if (rsp == "00")
                    {
                        suc += Convert.ToInt32(cnt);
                    }
                    else if ((rsp == "02") || (rsp == "51") || (rsp == "55") || (rsp == "75") || (rsp == "61") || (rsp == "65") || (rsp == "52") || (rsp == "53"))
                    {
                        fail += Convert.ToInt32(cnt);
                        userf += Convert.ToInt32(cnt);
                    }
                    else if (rsp == "91")
                    {
                        timeout += Convert.ToInt32(cnt);
                        userf += Convert.ToInt32(cnt);
                    }
                    else
                    {
                        fail += Convert.ToInt32(cnt);
                        systemf += Convert.ToInt32(cnt);
                    }
                }

                dt.Rows.Add(dttt,hr, suc, fail,timeout);
            }
        }
        //dt.DefaultView.Sort = "Hour ASC";
        //dt = dt.DefaultView.ToTable();
        return dt;
    }
    public static string CardHTML(string dt1, string dt2, string crd)
    {
        var crdType = string.Empty;
        var htmlTableStart = "<table style=\"border-collapse:collapse; text-align:left;\" >";
        var htmlTableEnd = "</table>";
        var htmlTrStart = "<tr style =\"color:#555555;\">";
        var htmlTrEnd = "</tr>";
        var atm = "";// etTerminalHTML(dt1, dt2, crd, "ATM");
        var pos = "";// GetTerminalHTML(dt1, dt2, crd, "POS");
        var oth = "";// GetTerminalHTML(dt1, dt2, crd, "OTHERS");

        if (crd == "2")
        {
            crdType = "IMAL ";
        }

        var messageBody = htmlTableStart;
        messageBody += htmlTrStart;
        messageBody += "<td colspan=\"3\" style=\" border-color:#990000;  border-style:solid; border-width:thin; padding: 5px;background-color:#990000; color:#ffffff\">" + crdType + "CARD TRANSACTIONS ANALYSIS</td>";
        messageBody += htmlTrEnd + htmlTrStart;
        messageBody += atm;
        messageBody += pos;
        messageBody += oth;
        messageBody += htmlTrEnd + htmlTableEnd;

        return messageBody;
    }

    protected void ChartATM_Load(object sender, EventArgs e)
    {

    }



    protected void ChartATM_DataBound(object sender, EventArgs e)
    {
        int ptCount = ChartATM.Series[0].Points.Count;
        for (int i = 0; i < ptCount; i++)
        {
            ChartATM.Series[0].Points[i].Url = @"~/Query.aspx?rq=1&ch=ATM"  +
                "&dtm="+i+"&data=" + ChartATM.Series[0].Points[i].AxisLabel;
            ChartATM.Series[1].Points[i].Url = @"~/Query.aspx?rq=1&ch=ATM" +
                "&dtm=" + i + "&data=" + ChartATM.Series[1].Points[i].AxisLabel;
        }
    }

    protected void ChartPOS_DataBound(object sender, EventArgs e)
    {
        int ptCount = ChartPOS.Series[0].Points.Count;
        for (int i = 0; i < ptCount; i++)
        {
            ChartPOS.Series[0].Points[i].Url = @"~/Query.aspx?rq=1&ch=POS" +
                "&dtm=" + i + "&data=" + ChartPOS.Series[0].Points[i].AxisLabel;
            ChartPOS.Series[1].Points[i].Url = @"~/Query.aspx?rq=1&ch=POS" +
                "&dtm=" + i + "&data=" + ChartPOS.Series[1].Points[i].AxisLabel;
        }
    }

    protected void ChartOTH_DataBound(object sender, EventArgs e)
    {
        int ptCount = ChartOTH.Series[0].Points.Count;
        for (int i = 0; i < ptCount; i++)
        {
            ChartOTH.Series[0].Points[i].Url = @"~/Query.aspx?rq=1&ch=OTH" +
                "&dtm=" + i + "&data=" + ChartOTH.Series[0].Points[i].AxisLabel;
            ChartOTH.Series[1].Points[i].Url = @"~/Query.aspx?rq=1&ch=OTH" +
                "&dtm=" + i + "&data=" + ChartOTH.Series[1].Points[i].AxisLabel;
        }
    }
}