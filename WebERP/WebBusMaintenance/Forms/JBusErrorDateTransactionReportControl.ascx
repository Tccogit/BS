﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusErrorDateTransactionReportControl.ascx.cs" Inherits="WebBusMaintenance.Forms.JBusErrorDateTransactionReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<div class="BigTitle">گزارش خطای تاریخ</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Report" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl runat="server" id="RadGridReport" />
        </td>
    </tr>
</table>