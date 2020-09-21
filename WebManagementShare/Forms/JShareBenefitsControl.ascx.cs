﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Forms
{
    public partial class JShareBenefitsControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GatDate();
        }

        public string GetPaymentSqlQuery(int PersonCode = 0)
        {
            return @"SELECT Code,Title,Cost FROM SahamCourse";
        }

        private void GatDate()
        {
            ClassLibrary.JPerson person = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson;
            // Finance.JAsset jAsset = new Finance.JAsset();
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusReports_JBusReports");
            jGridView.SQL = GetPaymentSqlQuery(person.Code);
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "Benefits";
            jGridView.Buttons = "excel";
            jGridView.PageOrderByField = "Code DESC";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridAsset).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridAsset).LoadGrid(true);
        }
    }
}