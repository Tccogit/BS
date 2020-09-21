﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusTicketFailureTransactionSendReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                         ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now.AddDays(-1));
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now.AddDays(-1));
            }
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusTicketFailureTransactionSend");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusTicketFailureTransactionSend"+(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+"_"+ (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.ClassName = "WebBusMaintenance_JBusTicketFailureTransactionSend_GetReport";
            jGridView.SQL = @"select top 100 percent ab.Code,az.Name ZoneName,ab.LastLineNumber LineNumber,ab.BUSNumber,
                                ab.TicketLastDate,ab.LastSimCardCharge from autbus ab
                                left join AUTLine al on ab.LastLineNumber = al.LineNumber
                                left join AUTZone az on az.Code = al.ZoneCode
                                WHERE ab.[Active]=1 and ab.TicketLastDate between '" + StartEventDate.Value.ToShortDateString() + @" 00:00:00'
                                and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + @" 23:59:59'
								and LEN(BUSNumber)=4 and BUSNumber between 1000 and 6999
								and LastLineNumber is not null and az.Code is not null
                                ORDER BY ab.TicketLastDate desc";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusTicketFailureTransactionSendReportControl";
            jGridView.Buttons = "excel,print";
            jGridView.Bind();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                         ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            catch { }
        }
    }
}