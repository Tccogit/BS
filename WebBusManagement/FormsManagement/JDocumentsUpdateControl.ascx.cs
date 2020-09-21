﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Documents;
using BusManagment.Reports;
using WebClassLibrary;
using ClassLibrary;

namespace WebBusManagement.FormsManagement
{
    public partial class JDocumentsUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
            //if (IsPostBack)
            //{
            //     RadGridTransactionDetail.MasterTableView.DataSource = GetRadGridDatatable();
            //    RadGridTransactionDetail.MasterTableView.DataBind();
            //}
        }

        private void LoadDates()
        {
            DataTable FleetsDt = BusManagment.Reports.JDailyPerformanceRportOnBus.GetFleetsToIssueDocument();
            foreach (DataRow FleetRow in FleetsDt.Rows)
            {

                DataTable YearDates = BusManagment.Reports.JDailyPerformanceRportOnBus.GetYearDatesToIssueDocument(Convert.ToInt32(FleetRow["FleetCode"].ToString()));
                Telerik.Web.UI.RadTreeNode RTNFleet = new Telerik.Web.UI.RadTreeNode();
                RTNFleet.Checkable = true;
                RTNFleet.Checked = true;
                RTNFleet.Text = FleetRow["FleetName"].ToString();
                RTNFleet.Value = FleetRow["FleetCode"].ToString();
                foreach (DataRow YearRow in YearDates.Rows)
                {
                    //ListItem LstItem = new ListItem();
                    //LstItem.Text = ClassLibrary.JDateTime.FarsiDate(Convert.ToDateTime(row["Date"]));
                    //LstItem.Value = ClassLibrary.JDateTime.FarsiDate(Convert.ToDateTime(row["Date"]));
                    //LstItem.Selected = true;
                    //LstItem.Enabled = false;
                    //ChklReciveDate.Items.Add(LstItem);

                    //New Version
                    DataTable MonthDates = BusManagment.Reports.JDailyPerformanceRportOnBus.GetMonthDatesToIssueDocument(Convert.ToInt32(YearRow["Date"]), Convert.ToInt32(FleetRow["FleetCode"].ToString()));
                    Telerik.Web.UI.RadTreeNode RTNYear = new Telerik.Web.UI.RadTreeNode();
                    RTNYear.Checkable = true;
                    RTNYear.Checked = true;
                    RTNYear.Text = YearRow["Date"].ToString();
                    RTNYear.Value = YearRow["Date"].ToString();
                    foreach (DataRow MonthRow in MonthDates.Rows)
                    {
                        Telerik.Web.UI.RadTreeNode RTNMonth = new Telerik.Web.UI.RadTreeNode();
                        RTNMonth.Checkable = true;
                        RTNMonth.Checked = true;
                        RTNMonth.Text = MonthRow["Date"].ToString();
                        RTNMonth.Value = MonthRow["Date"].ToString();
                        DataTable FullDates = BusManagment.Reports.JDailyPerformanceRportOnBus.GetFullDatesToIssueDocument(Convert.ToInt32(YearRow["Date"]), Convert.ToInt32(MonthRow["Date"]), Convert.ToInt32(FleetRow["FleetCode"].ToString()));
                        foreach (DataRow FullDatesRow in FullDates.Rows)
                        {
                            Telerik.Web.UI.RadTreeNode RTNFullDates = new Telerik.Web.UI.RadTreeNode();
                            RTNFullDates.Checkable = true;
                            RTNFullDates.Checked = true;
                            RTNFullDates.Text = ClassLibrary.JDateTime.FarsiDate(Convert.ToDateTime(FullDatesRow["Date"])) + " ( " + FullDatesRow["TCount"].ToString() + " )";
                            RTNFullDates.Value = ClassLibrary.JDateTime.FarsiDate(Convert.ToDateTime(FullDatesRow["Date"]));
                            RTNMonth.Nodes.Add(RTNFullDates);
                        }
                        RTNYear.Nodes.Add(RTNMonth);
                    }
                    RTNFleet.Nodes.Add(RTNYear);
                    //New Version

                }
                DateTreeView.Nodes.Add(RTNFleet);

            }

        }

        public void _SetForm()
        {
            ((WebControllers.MainControls.Date.JDateControl)txtCloseDocumentDate).SetDate(DateTime.Now);

            if (!IsPostBack)
            {
                LoadDates();
                txtDocumentCode.Text = Convert.ToString(JAUTDocuments.GetMaxDocumentCode() + 1);
            }

            if (Code > 0)
            {
            }
        }

        protected void ckhAllDateSelect_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DateTreeView.Nodes.Count; i++)
            {
                IList<Telerik.Web.UI.RadTreeNode> MonthNodeList = DateTreeView.Nodes[i].GetAllNodes();
                for (int MonthNode = 0; MonthNode < MonthNodeList.Count; MonthNode++)
                {
                    IList<Telerik.Web.UI.RadTreeNode> FullDatesList = MonthNodeList[MonthNode].GetAllNodes();
                    for (int FullDates = 0; FullDates < FullDatesList.Count; FullDates++)
                    {
                        if (ckhAllDateSelect.Checked == true)
                        {
                            FullDatesList[FullDates].Checked = true;
                            FullDatesList[FullDates].Enabled = false;
                        }
                        else if (ckhAllDateSelect.Checked == false)
                        {
                            FullDatesList[FullDates].Enabled = true;
                            FullDatesList[FullDates].Checked = false;
                        }
                    }
                }
            }
        }

        protected void btnShowOutput_Click(object sender, EventArgs e)
        {
            GetRadTransactionGridDataSource(true);
        }

        public void GetRadTransactionGridDataSource(bool BindMode = true)
        {
            DateTime[] dates = new DateTime[0];
            int[] FleetCode = new int[0];
            int j = 0, FeCounter = 0;
            for (int i = 0; i < DateTreeView.Nodes.Count; i++)
            {
                IList<Telerik.Web.UI.RadTreeNode> YearNodeList = DateTreeView.Nodes[i].GetAllNodes();
                if (DateTreeView.Nodes[i].Checked == true)
                {
                    Array.Resize(ref FleetCode, FleetCode.Length + 1);
                    FleetCode[FeCounter] = Convert.ToInt32(DateTreeView.Nodes[i].Value.ToString());
                    FeCounter = FeCounter + 1;
                }
                for (int YearNode = 0; YearNode < YearNodeList.Count; YearNode++)
                {
                    IList<Telerik.Web.UI.RadTreeNode> MonthNodeList = YearNodeList[YearNode].GetAllNodes();
                    for (int MonthNode = 0; MonthNode < MonthNodeList.Count; MonthNode++)
                    {
                        IList<Telerik.Web.UI.RadTreeNode> FullDatesList = MonthNodeList[MonthNode].GetAllNodes();
                        for (int FullDates = 0; FullDates < FullDatesList.Count; FullDates++)
                        {
                            if (FullDatesList[FullDates].Checked == true && FullDatesList[FullDates].Value.Length > 4)
                            {
                                Array.Resize(ref dates, dates.Length + 1);
                                dates[j++] = Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(FullDatesList[FullDates].Value.ToString()));
                            }
                        }
                    }
                }
            }
            txtDocumentDiscription.Text = "سند  شماره " + txtDocumentCode.Text + " از تاریخ " + ClassLibrary.JDateTime.FarsiDate(dates[0]) + " " + "تا تاریخ " + ClassLibrary.JDateTime.FarsiDate(dates[dates.Length - 1]);
            DataTable report = BusManagment.Reports.JDailyPerformanceRportOnBus.GetDriversReportByDate(dates, FleetCode);
            RadGridTransactionDetail.DataSource = report;
            RadGridTransactionDetail.MasterTableView.EditMode = Telerik.Web.UI.GridEditMode.InPlace;
            //if (BindMode == true)
            if (RadGridTransactionDetail.MasterTableView.DataSource == null)
            {
                RadGridTransactionDetail.Rebind();
            }
        }

        protected void RadGridTransactionDetail_PreRender(object sender, EventArgs e)
        {
            if (RadGridTransactionDetail.DataSource == null) return;
            foreach (DataColumn col in (RadGridTransactionDetail.DataSource as DataTable).Columns)
            {
                RadGridTransactionDetail.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
                if (col.ColumnName == "BusCode" || col.ColumnName == "OwnerCode" || col.ColumnName == "SendToBank")
                {
                    RadGridTransactionDetail.MasterTableView.GetColumn(col.ColumnName).Visible = false;
                }
            }
            RadGridTransactionDetail.MasterTableView.Rebind();
        }

        protected void RadGridTransactionDetail_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (IsPostBack)
            {
                string target = Request["__EVENTTARGET"] as string;
                if (target != null && target != String.Empty)
                {
                    var targetControl = this.Page.FindControl(target);
                    if (targetControl.ID != "ckhAllDateSelect" && targetControl.ID != "DateTreeView")
                    {
                        GetRadTransactionGridDataSource(false);
                    }
                }
                else
                {
                    GetRadTransactionGridDataSource(false);
                }
            }
        }



        //public DataTable GetRadGridDatatable()
        //{
        //    DataTable dtRecords = new DataTable();
        //    DateTime[] dates = new DateTime[0];
        //    int j = 0;
        //    for (int i = 0; i < DateTreeView.Nodes.Count; i++)
        //    {
        //        IList<Telerik.Web.UI.RadTreeNode> MonthNodeList = DateTreeView.Nodes[i].GetAllNodes();
        //        for (int MonthNode = 0; MonthNode < MonthNodeList.Count; MonthNode++)
        //        {
        //            IList<Telerik.Web.UI.RadTreeNode> FullDatesList = MonthNodeList[MonthNode].GetAllNodes();
        //            for (int FullDates = 0; FullDates < FullDatesList.Count; FullDates++)
        //            {
        //                if (FullDatesList[FullDates].Checked == true && FullDatesList[FullDates].Value.Length > 4)
        //                {
        //                    Array.Resize(ref dates, dates.Length + 1);
        //                    dates[j++] = Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(FullDatesList[FullDates].Value.ToString()));
        //                }
        //            }
        //        }
        //    }
        //    dtRecords = BusManagment.Reports.JDailyPerformanceRportOnBus.GetDriversReportByDate(dates);
        //    return dtRecords;
        //}

        protected void btnSaveCloseTransaction_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtCloseDocumentDate).GetFarsiDate().Length == 10)
            {
                if (RadGridTransactionDetail.MasterTableView.Items.Count > 0)
                {

                    JDataBase db = new JDataBase();
                    try
                    {
                        #region Save Document
                        JAUTDocument document = new JAUTDocument(db, Code);
                        document.Description = txtDocumentDiscription.Text;
                        document.DocumentCode = Convert.ToInt32(txtDocumentCode.Text);
                        DateTime DocumentInsertDate = ((WebControllers.MainControls.Date.JDateControl)txtCloseDocumentDate).GetDate();
                        DateTime CuDocIssueDate = new DateTime(DocumentInsertDate.Year, DocumentInsertDate.Month, DocumentInsertDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                        document.IssueDate = CuDocIssueDate;
                        document.AllDates = ckhAllDateSelect.Checked;
                        document.Register_Full_Title = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostTitle;
                        document.Register_Post_Code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode;
                        document.Register_User_Code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                        db.beginTransaction("SaveDocumentWeb");
                        //if (Code > 0)
                        //{
                        //    if (JAUTDocumentDates.DeleteDates(db, Code) < 0)
                        //        throw new Exception();
                        //    document.Update(db);
                        //}
                        //else
                        //{
                        Code = document.Insert(db, true);
                        if (Code == 0)
                            throw new Exception();
                        // }
                        DateTime[] dates = new DateTime[0];
                        int j = 0;
                        if (Code > 0)
                        {
                            string InsertDocumentDateQuery = "";
                            for (int i = 0; i < DateTreeView.Nodes.Count; i++)
                            {
                                IList<Telerik.Web.UI.RadTreeNode> YearNodeList = DateTreeView.Nodes[i].GetAllNodes();
                                for (int YearNode = 0; YearNode < YearNodeList.Count; YearNode++)
                                {
                                    IList<Telerik.Web.UI.RadTreeNode> MonthNodeList = YearNodeList[YearNode].GetAllNodes();
                                    for (int MonthNode = 0; MonthNode < MonthNodeList.Count; MonthNode++)
                                    {
                                        IList<Telerik.Web.UI.RadTreeNode> FullDatesList = MonthNodeList[MonthNode].GetAllNodes();
                                        for (int FullDates = 0; FullDates < FullDatesList.Count; FullDates++)
                                        {
                                            if (FullDatesList[FullDates].Checked == true && FullDatesList[FullDates].Value.Length > 4)
                                            {
                                                InsertDocumentDateQuery += @" Insert Into AUTDocumentDate(Code,DocumentCode,Date,IsIssued)
                                                                             values((select IsNULL(max(Code),0)+1 from AUTDocumentDate)," + Code +
                                                                             @",'" + ClassLibrary.JDateTime.GregorianDate(FullDatesList[FullDates].Value.ToString()) + @"',1) ";

                                                Array.Resize(ref dates, dates.Length + 1);
                                                dates[j++] = Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(FullDatesList[FullDates].Value.ToString()));

                                                //JAUTDocumentDate date = new JAUTDocumentDate(Code);
                                                //date.DocumentCode = Code;
                                                //date.Date = ClassLibrary.JDateTime.GregorianDate(FullDatesList[FullDates].Text.ToString());
                                                //date.IsIssued = FullDatesList[FullDates].Checked;
                                                ////if (date.Insert(db) == 0)
                                                //if (date.Insert(db) == 0)
                                                //{
                                                //    throw new Exception();
                                                //}
                                            }
                                        }
                                    }
                                }
                            }
                            db.setQuery(InsertDocumentDateQuery);
                            if (db.Query_Execute() <= 0)
                                throw new Exception();
                        }
                        else
                            throw new Exception();
                        #endregion Save

                        #region Save Details

                        int[] owners = new int[0];
                        long OwnerAccountNo = 0;
                        DataTable SelectedOwners = (DataTable)RadGridTransactionDetail.MasterTableView.DataSource;
                        bool[] SendToBankStatus = new bool[RadGridTransactionDetail.MasterTableView.Items.Count];
                        for (int i = 0; i < RadGridTransactionDetail.MasterTableView.Items.Count; i++)
                        {
                            if (((CheckBox)(RadGridTransactionDetail.MasterTableView.Items[i]["SendToBank"].FindControl("chbSelect"))).Checked == true &&
                                long.TryParse(RadGridTransactionDetail.MasterTableView.Items[i]["AccountNo"].Text.ToString(), out OwnerAccountNo) == true)
                            {
                                SendToBankStatus[i] = true;
                            }
                            else
                            {
                                SendToBankStatus[i] = false;
                            }
                        }
                        //GetRadGridDatatable();
                        int SendToBankCounter = 0;
                        foreach (DataRow row in SelectedOwners.Rows)
                        {
                            if (SendToBankStatus[SendToBankCounter])
                            {
                                Array.Resize(ref owners, owners.Length + 1);
                                owners[owners.Length - 1] = Convert.ToInt32(row["OwnerCode"]);
                            }
                            SendToBankCounter++;
                        }
                        if (BusManagment.Reports.JDailyPerformanceRportOnBus.SetReportDocumentCode(db, dates, owners, Code) < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            JAUTDocument doc = new JAUTDocument(db, Code);
                            doc.IsClosed = true;
                            doc.Update(db, true);
                            #region Insert Details

                            string InsertDocumentDetailQuery = "";
                            int DetailInsertCounter = 0;
                            foreach (DataRow row in SelectedOwners.Rows)
                            {
                                if (SendToBankStatus[DetailInsertCounter])
                                {
                                    InsertDocumentDetailQuery += @" Insert Into AUTDocumentDetail(Code,DocumentCode,OwnerPCode,Amount,SentToBank,CardCount,BusCode)
                                                                    Values((Select IsNULL(max(Code),0)+1 From AUTDocumentDetail)," + Code + @"," + row["OwnerCode"].ToString() +
                                                                    @",substring('" + row["SumPrice"].ToString() + "',1," + (row["SumPrice"].ToString().Length - 1) + ")" +
                                                                    @",0," + row["Count"].ToString() + @"," + row["BusCode"].ToString() + @") ";
                                    //Convert.ToDecimal(Convert.ToInt64(row["SumPrice"].ToString()) / 10).ToString()

                                    //JAUTDocumentDetail detail = new JAUTDocumentDetail();
                                    //detail.DocumentCode = Code;
                                    //detail.CardCount = Convert.ToInt32(row["Count"]);
                                    //detail.Amount = Convert.ToDecimal(Convert.ToInt32(row["SumPrice"]) / 10);
                                    //detail.OwnerPCode = Convert.ToInt32(row["OwnerCode"]);
                                    //detail.BusCode = Convert.ToInt32(row["BusCode"]);
                                    ////detail.SentToBank = SendToBankStatus[DetailInsertCounter];
                                    //if (detail.Insert(db) == 0)
                                    //    //if (detail.Insert(db) == 0)
                                    //    throw new Exception();
                                }
                                DetailInsertCounter++;
                            }

                            db.setQuery(InsertDocumentDetailQuery);
                            if (db.Query_Execute() <= 0)
                                throw new Exception();

                            db.Commit();

                            try
                            {
                                ClassLibrary.JDataBase dbAccProc = new ClassLibrary.JDataBase();
                                dbAccProc.setQuery("EXEC SP_FinDailyDocumentToFinDocument");
                                dbAccProc.Query_Execute();
                            }
                            catch { }

                            #endregion Insert Details
                            //txtDocumentDiscription.Text = "";
                            //((WebControllers.MainControls.Date.JDateControl)txtCloseDocumentDate).SetDate(DateTime.Now);
                            WebClassLibrary.JWebManager.RunClientScript("alert('بستن تراکنشها با موفقیت انجام شد. از قسمت حسابداری->پرداختها برای ارسال اسناد به بانک اقدام فرمائید');", "ConfirmDialog");
                            WebClassLibrary.JWebManager.CloseAndRefresh();
                        }
                        #endregion Details
                    }
                    catch (Exception ex)
                    {
                        db.Rollback("SaveDocumentWeb");
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ثبت با مشکل مواجه شده است');", "ConfirmDialog");
                    }
                    finally
                    {
                        db.Dispose();
                        WebClassLibrary.JWebManager.CloseAndRefresh();
                    }

                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('هیچ تراکنشی وجود ندارد ، لطفا دکمه ی مشاهده ی خروجی را بزنید');", "ConfirmDialog");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا تاریخ بسته شدن را انتخاب کنید');", "ConfirmDialog");
            }
        }

        protected void RadGridTransactionDetail_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string target = Request["__EVENTTARGET"] as string;
                if (target != null && target != String.Empty)
                {
                    var targetControl = this.Page.FindControl(target);
                    if (targetControl.ID != "ckhAllDateSelect")
                    {
                        GetRadTransactionGridDataSource(false);
                    }
                }
                else
                {
                    GetRadTransactionGridDataSource(false);
                }
            }
        }

    }
}