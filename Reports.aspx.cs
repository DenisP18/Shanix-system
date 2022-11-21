using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using Demo.Database_handler;
using Demo.Entity_Objects;


namespace Demo
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Report_list.SelectedItem.Text== "Available Stock Rpt" ) 
            {
                gridView.Visible = false;
                Stock_Rpt.Visible = false;
                gridAvStock.Visible = true;
            }
           else if (IsPostBack && Report_list.SelectedItem.Text == "Periodic Txn Rpt" &&!(Report_list.SelectedItem.Text == "Available Stock Rpt") &&!(Report_list.SelectedItem.Text == "Stocked items")) 
            {
                gridAvStock.Visible = false;
                Stock_Rpt.Visible = false;
                gridView.Visible = true;
            }
            else if (IsPostBack && Report_list.SelectedItem.Text == "Stocked items" &&!(Report_list.SelectedItem.Text == "Available Stock Rpt")&&!(Report_list.SelectedItem.Text == "Periodic Txn Rpt"))
            {
                Stock_Rpt.Visible = true;
                gridAvStock.Visible = false;
                gridView.Visible = false;
                
            }
        }

        databaseHandler dh = new databaseHandler();
        public DataTable GeneralReport(DateTime startDate, DateTime EndDate)
        {

            DataTable dt = new DataTable();
            object[] obj = { startDate, EndDate };
            dt = dh.retrieveData(FindProcedure.GeneralReportGenerator, obj);

            if (dt.Rows.Count >= 1)
            {
                
                try
                {
                    DataColumn dc = new DataColumn();
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("SellingDate");
                    dt2.Columns.Add("ProductName");
                    dt2.Columns.Add("Quantity");
                    dt2.Columns.Add("SellingPrice");
                    dt2.Columns.Add("TotalPrice");
                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime SellingDate = Convert.ToDateTime(dr["SellingDate"].ToString());
                        string ProductName = dr["ProductName"].ToString();
                        int Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                        Double unitPrice = Convert.ToDouble(dr["SellingPrice"].ToString());
                        Double TotalPrice = Convert.ToDouble(dr["TotalPrice"].ToString());
                        dt2.Rows.Add(SellingDate, ProductName, Quantity, unitPrice, TotalPrice);

                    }

                    int TotalQty = dt.AsEnumerable().Sum(row => row.Field<int>("Quantity"));
                    decimal TotalUnitPrices = dt.AsEnumerable().Sum(row => row.Field<decimal>("SellingPrice"));
                    decimal TotalPrice1 = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalPrice"));
                    dt2.Rows.Add("TOTAL:", "", TotalQty, TotalUnitPrices, TotalPrice1);
                    gridView.DataSource = dt2;
                    gridView.DataBind();
                    gridView.UseAccessibleHeader = true;
                    gridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    DownloadTxt.Visible = true;
                   
                }

                catch (Exception pascal)
                {
                    string rpt_err = pascal.ToString();
                    ShowErrorMessage(rpt_err);

                }

            }

            else
            {
                string rpt_err2 = "No Results Found";
                ShowErrorMessage(rpt_err2);
                gridView.Visible = false;
                DownloadTxt.Visible = false;
            }
            return dt;
        }

        protected void search_Txt_Click(object sender, EventArgs e)
        {
            if (Report_list.SelectedItem.Text == "Select Report")
            {
                string rpt_err = "Select a valid Report";
                ShowErrorMessage(rpt_err);

            }
          else if (Report_list.SelectedItem.Text == "Periodic Txn Rpt")
            {
               
                DateTime startDate = Convert.ToDateTime(StartDateTxt.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(EndDateTxt.Text.ToString());

                GeneralReport(startDate, EndDate);
                gridView.Visible = true;

            }
            else if (Report_list.SelectedItem.Text == "Stocked items")
            {

                DateTime startDate1 = Convert.ToDateTime(StartDateTxt.Text.ToString());
                DateTime EndDate1 = Convert.ToDateTime(EndDateTxt.Text.ToString());
                Stocks_Rpt(startDate1, EndDate1);
                Stock_Rpt.Visible = true;
            }
          else if (Report_list.SelectedItem.Text == "Available Stock Rpt")
            {
            
                try
                {
                    object[] obj = { };
                    DataTable dt3= dh.retrieveData(FindProcedure.AvailableStock, obj);
                    if (dt3.Rows.Count > 0)
                    {
                        try 
                        {
                            DataColumn dc = new DataColumn();
                            DataTable dt = new DataTable();
                            dt.Columns.Add("ProductName");
                            dt.Columns.Add("Quantity");
                            dt.Columns.Add("Category");
                            dt.Columns.Add("Date Last Stocked");
                            foreach (DataRow dr in dt3.Rows)
                            {
                              
                                string ProductName = dr["ProductName"].ToString();
                                int Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                                string Category = dr["Category"].ToString();
                                DateTime updatedDate = Convert.ToDateTime(dr["Date_Last_Updated"].ToString());
                                dt.Rows.Add( ProductName, Quantity, Category, updatedDate);
                            }

                            gridAvStock.DataSource = dt;
                            gridAvStock.DataBind();
                            gridAvStock.UseAccessibleHeader = true;
                            gridAvStock.HeaderRow.TableSection = TableRowSection.TableHeader;
                            DownloadTxt.Visible = true;
                           
                        }
                        catch ( Exception ex) 
                        {
                            string Av_stock_err = ex.ToString();
                            ShowErrorMessage(Av_stock_err);
                        }

                    }
                    else 
                    {
                        string no_data = "no records found";
                        ShowErrorMessage(no_data);
                    }
                }
                catch ( Exception ex)
            
                {
                    string Av_stock_err = ex.ToString();
                    ShowErrorMessage(Av_stock_err);
                }

            }


        }

        public void Stocks_Rpt(DateTime startDate, DateTime endDate)
        {
            object[] param = { startDate,endDate};
           
            if (!string.IsNullOrEmpty(StartDateTxt.Text)) 
            {
                if (!string.IsNullOrEmpty(EndDateTxt.Text))
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        dt = dh.retrieveData(FindProcedure.stocked_items, param);
                        if (dt.Rows.Count > 0)
                        {
                            DataColumn dc = new DataColumn();
                            DataTable dt4 = new DataTable();
                            dt4.Columns.Add("Stock_Date");
                            dt4.Columns.Add("ProductName");
                            dt4.Columns.Add("Quantity");
                            dt4.Columns.Add("Category");
                            dt4.Columns.Add("UnitPrice");
                            dt4.Columns.Add("TotalPrice");
                           

                            foreach (DataRow dr in dt.Rows)
                            {
                                DateTime Stock_Date = Convert.ToDateTime(dr["EntryDate"].ToString());
                                string ProductName = dr["ProductName"].ToString();
                                int Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                                decimal unitPrice = Convert.ToDecimal(dr["UnitPrice"].ToString());
                                string Category = dr["Category"].ToString();
                                decimal TotalPrice = Convert.ToDecimal(dr["TotalPrice"].ToString());

                                dt4.Rows.Add(Stock_Date, ProductName, Quantity, Category, unitPrice, TotalPrice);
                            }
                            int TotalQty = dt.AsEnumerable().Sum(row => row.Field<int>("Quantity"));
                            decimal TotalUnitPrices = dt.AsEnumerable().Sum(row => row.Field<decimal>("UnitPrice"));
                            decimal TotalPrice1 = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalPrice"));
                            dt4.Rows.Add("TOTAL:", "",TotalQty, "", TotalUnitPrices, TotalPrice1);

                            Stock_Rpt.DataSource = dt4;
                            Stock_Rpt.DataBind();
                            Stock_Rpt.UseAccessibleHeader = true;
                            Stock_Rpt.HeaderRow.TableSection = TableRowSection.TableHeader;
                            Stock_Rpt.Visible = true;
                            DownloadTxt.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex.ToString());
                    }


                }
            }
           
        }
        private void ExportGridToExcel()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Charset = "";
            string FileName = "Periodic" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gridView.GridLines = GridLines.Both;
            gridView.HeaderStyle.Font.Bold = true;
            gridView.RenderControl(htmltextwrtter);
            gridView.AllowPaging = false;
            HttpContext.Current.Response.Charset = "";
            EnableViewState = false;
            HttpContext.Current.Response.Write(strwritter.ToString());
            HttpContext.Current.Response.End();

        }

        private void AvailableStocks_Rpts()
        {

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Charset = "";
            string FileName = "Available Stocks Report" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gridAvStock.GridLines = GridLines.Both;
            gridAvStock.HeaderStyle.Font.Bold = true;
            gridAvStock.RenderControl(htmltextwrtter);
            gridAvStock.AllowPaging = false;
            HttpContext.Current.Response.Charset = "";
            EnableViewState = false;
            HttpContext.Current.Response.Write(strwritter.ToString());
            HttpContext.Current.Response.End();

        }

        private void Stocked_Rpts()
        {

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Charset = "";
            string FileName = "Stocked Items" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Stock_Rpt.GridLines = GridLines.Both;
            Stock_Rpt.HeaderStyle.Font.Bold = true;
            Stock_Rpt.RenderControl(htmltextwrtter);
            Stock_Rpt.AllowPaging = false;
            HttpContext.Current.Response.Charset = "";
            EnableViewState = false;
            HttpContext.Current.Response.Write(strwritter.ToString());
            HttpContext.Current.Response.End();

        }

        protected void DownloadTxt_Click(object sender, EventArgs e)
        {
            if (Report_list.SelectedItem.Text == "Periodic Txn Rpt") 
            {
                ExportGridToExcel();
            }
            if (Report_list.SelectedItem.Text == "Available Stock Rpt") 
            {
                AvailableStocks_Rpts();
            }
            if (Report_list.SelectedItem.Text == "Stocked items")
            {
                Stocked_Rpts();
            }
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        

        protected void ShowErrorMessage(string message)
        {
            ErrorTxt.Style.Add("class", "login-error");
            ErrorTxt.Text = message;
        }

        protected void Report_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Report_list.SelectedItem.Text.ToString() == "Periodic Txn Rpt")
            {
                StartDateTxt.Visible = true;
                EndDateTxt.Visible = true;

            }

        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}