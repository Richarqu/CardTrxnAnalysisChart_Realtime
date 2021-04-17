using Sterling.MSSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
    public Utils()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetTerminalHTML(string crd, string term)
    {
        var ds = new DataSet();
        var dte = DateTime.Now;
        DataTable dt = new DataTable();
        dt.Columns.Add("Hour", typeof(string));
        dt.Columns.Add("Success", typeof(int));
        dt.Columns.Add("Failed", typeof(int));
        dt.Columns.Add("Timeout", typeof(int));

        //right([pos_data_code],2)
        //pos_terminal_type
        string totals_grp = string.Empty;
        if(crd == "1")
        {
            totals_grp = "'SBPFLUTGrp','SBPGroup','MASTERGroup','SBPVISACGrp','SBPVISADGrp'";
        }
        else if(crd == "2")
        {
            totals_grp = "'IMALNAIRAGrp'";
        }
        else if (crd == "3")
        {
            totals_grp ="'SBPABUGroup','SBPACEGroup','SBPAFEGroup','SBPALEKGroup','SBPALHAGroup','SBPAMMLGrp','SBPAPPLEGrp','SBPAPViGroup','SBPBABURAGrP','SBPBARNAWGrp','SBPBCKASHGrp','SBPBISGroup','SBPBOKKOSGrp','SBPBORSTGrp','SBPBOWENGrp','SBPBUKGroup','SBPCALGroup','SBPCALMGroup','SBPCEDGroup','SBPCHAGroup','SBPCITGrp','SBPCONPRGrp','SBPCONSGroup','SBPCORGroup','SBPCRDAFRGrp','SBPCROSGroup','SBPDRSGroup','SBPDYNAGroup','SBPEBARGroup','SBPECHGroup','SBPEKOGroup','SBPEMPGroup','SBPESOEGroup','SBPFCTGroup','SBPFFSGroup','SBPFIMGroup','SBPFINGroup','SBPFRANGEGrp','SBPFROYGroup','SBPGARKIGrp','SBPGARUGroup','SBPGATEGroup','SBPGUFGroup','SBPHEADGroup','SBPSBPHINAGrp','SBPILORINGrp','SBPIMOWOGrp','SBPKADGroup','SBPKCMBGroup','SBPKEBBIGrp','SBPMARIGroup','SBPMBGroup','SBPMETGroup','SBPMFBGenGrp','SBPNAGARGrp','SBPNDIOGroup','SBPNIGPRIGrp','SBPNORTHBGrp','SBPNPFCrGrp','SBPNPFGroup','SBPOHAGroup','SBPOOUGrp','SBPPARCGroup','SBPPARGroup','SBPPOLGroup','SBPPROGGroup','SBPPTRUSTGrp','SBPREFGroup','SBPRICGroup','SBPSABIGroup','SBPSHALOMGrp','SBPSHONGGrp','SBPSOVGroup','SBPSTANGrp','SBPSTGroup','SBPSULSAPGrp','SBPTCFGroup','SBPUDAGrp','SBPVIRTUEGrp','SBPVirtuGrp','SBPVISGroup','SBROYALEXGrp','STERLFIGroup','VISAGroup'";
        }
        else
        {
            totals_grp = "'SBPFLUTGrp','SBPGroup','MASTERGroup','SBPVISACGrp','SBPVISADGrp'";
        }

        var cond = string.Empty; var grps = string.Empty;
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
                         // WHERE totals_group IN(SELECT totals_group FROM tbl_totalsGroup_mapping WHERE category IN (@crd))
                         // AND message_type IN ('0100', '0200', '0600', '0220') " + cond + "AND Transaction_Date BETWEEN @dt1 AND @dt2 " +
                         //"GROUP BY Response ORDER BY Count desc ";

            string sql = @"select MAX(rsp_code_req_rsp), CASE
					WHEN rsp_code_req_rsp = '00' THEN 'Approved or completed successfully'
					WHEN rsp_code_req_rsp = '01' THEN 'Refer to card issuer'
					WHEN rsp_code_req_rsp = '05' THEN 'Do not honor'
					WHEN rsp_code_req_rsp = '06' THEN 'Error'
					WHEN rsp_code_req_rsp = '51' THEN 'Not sufficient funds'
					WHEN rsp_code_req_rsp = '52' THEN 'No check account'
					WHEN rsp_code_req_rsp = '53' THEN 'No savings account'
					WHEN rsp_code_req_rsp = '54' THEN 'Expired card'
					WHEN rsp_code_req_rsp = '55' THEN 'Incorrect PIN'
					WHEN rsp_code_req_rsp = '56' THEN 'No card record'
					WHEN rsp_code_req_rsp = '57' THEN 'Transaction not permitted to cardholder'
					WHEN rsp_code_req_rsp = '61' THEN 'Exceeds withdrawal limit'
					WHEN rsp_code_req_rsp = '65' THEN 'Exceeds withdrawal frequency'
					WHEN rsp_code_req_rsp = '68' THEN 'Response received too late'
					WHEN rsp_code_req_rsp = '75' THEN 'PIN tries exceeded'
					WHEN rsp_code_req_rsp = '91' THEN 'Issuer or switch inoperative'
					ELSE rsp_code_req_rsp+'-Unlisted Response Code'
				END as Response, count(ret_ref_no) as Count
				from tm_trans with (nolock) where totals_group in (@crd) 
AND msg_type IN ('512', '256', '1536', '544')  " + cond + " AND in_req BETWEEN @dt1 AND @dt2 GROUP BY rsp_code_req_rsp ORDER BY Count(ret_ref_no) desc ";

            //BETWEEN '2021-04-17 00:00:00.000' AND '2021-04-17 06:00:00.000'
            //right([pos_data_code],2) NOT IN ('01','02')

            Connect cn = new Connect("FEPConn")
            {
                Persist = true
            };
            //sql = "select top 10 ret_ref_no from tm_trans with (nolock) where totals_group in ('SBPFLUTGrp','SBPGroup','MASTERGroup','SBPVISACGrp','SBPVISADGrp') AND msg_type IN('512', '256', '1536', '544')   AND right([pos_data_code],2) = '01'  AND in_req BETWEEN '2021-04-17 21:00:00.000' AND '2021-04-17 21:59:59.999'";
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

                dt.Rows.Add(hr, suc, fail,timeout);
            }
        }
        //dt.DefaultView.Sort = "Hour ASC";
        //dt = dt.DefaultView.ToTable();
        return dt;
    }

    public DataSet GetOnUsTerminalHourSummary(string crd, string term, string dte,string hr)
    {
        var ds = new DataSet();

        var cond = string.Empty; var grps = string.Empty;
       

        if (crd == "1")
        {
            cond += " category = 1)";
        }
        else if (crd == "2")
        {
            cond += " category = 2)";
        }
        else if (crd == "3")
        {
            cond += " category  NOT IN (1,2,4))";
        }

        if (term == "ATM")
        {
            cond += " AND pos_terminal_type = '02'";
        }
        else if (term == "POS")
        {
            cond += " AND pos_terminal_type = '01'";
        }
        else
        {
            cond += " AND pos_terminal_type NOT IN ('01','02')";
        }

        var dt1 = dte + " "+hr+ ":00:00.000";
        var dt2 = dte + " " + hr + ":59:59.999";
        string sql = @"SELECT @term AS Terminal,totals_group AS Institution,sink AS 'Authoriser',Response,COUNT(RRN) AS Count FROM [postilion_office].[dbo].[vw_FullTrxnDet]
                        WHERE totals_group IN (SELECT totals_group FROM tbl_totalsGroup_mapping WHERE "+
                        cond + " AND message_type IN ('0100', '0200', '0600', '0220') AND Transaction_Date BETWEEN @dt1 AND @dt2 GROUP BY Response,totals_group,sink  ORDER BY Response ASC,Count DESC";
        Connect cn = new Connect("OfficeConn")
        {
            Persist = true
        };
        cn.SetSQL(sql);
        cn.AddParam("@dt1", dt1);
        cn.AddParam("@dt2", dt2);
        cn.AddParam("@crd", crd);
        cn.AddParam("@term", term);
        ds = cn.Select();
        cn.CloseAll();
        
        return ds;
    }

    public DataSet GetNOUTerminalHourSummary(string crd, string term, string dte, string hr)
    {
        var ds = new DataSet();

        var cond = string.Empty; var grps = string.Empty;
        if (term == "ATM")
        {
            cond = " AND pos_terminal_type = '02' ";
        }
        else if (term == "POS")
        {
            cond = " AND pos_terminal_type = '01' ";
        }
        else
        {
            cond = " AND pos_terminal_type NOT IN ('01','02') ";
        }

        var dt1 = dte + " " + hr + ":00:00.000";
        var dt2 = dte + " " + hr + ":59:59.999";
        string sql = @"SELECT @term AS Terminal,sink AS 'Authoriser',Response,COUNT(RRN) AS Count FROM [postilion_office].[dbo].[vw_FullTrxnDet]
                        WHERE totals_group IN (SELECT totals_group FROM tbl_totalsGroup_mapping WHERE category NOT IN (1,2))
                        AND message_type IN ('0100', '0200', '0600', '0220')  " +
                        cond + "AND Transaction_Date BETWEEN @dt1 AND @dt2 GROUP BY Response,sink  ORDER BY Count DESC";
        Connect cn = new Connect("OfficeConn")
        {
            Persist = true
        };
        cn.SetSQL(sql);
        cn.AddParam("@dt1", dt1);
        cn.AddParam("@dt2", dt2);
        cn.AddParam("@crd", crd);
        cn.AddParam("@term", term);
        ds = cn.Select();
        cn.CloseAll();

        return ds;
    }
}