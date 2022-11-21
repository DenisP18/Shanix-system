using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo.Database_handler;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Demo.Entity_Objects;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Collections;

namespace Demo
{
    public partial class Sales : System.Web.UI.Page
    {
        databaseHandler dh = new databaseHandler();
        DataTable dt = new DataTable();

        DataTable tb = new DataTable();
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            multiviewSales.ActiveViewIndex = 0;
            gridView2.Visible = true;
            if (!this.IsPostBack)
            {

                this.createtable();
            }
            else if (!IsPostBack)
            {

            }
        }
        public void Search_Pdt()
        {
            if (!string.IsNullOrEmpty(ProductNameTxt.Text))
            {

                try
                {
                    string pdt_name = ProductNameTxt.Text.Trim().ToString();
                    object[] pdt_res = { pdt_name };
                    dt = dh.retrieveData(FindProcedure.Searches, pdt_res);
                    if (dt.Rows.Count == 0)
                    {
                        string err = "Product can not be found";
                        ShowErrorMessage(err);

                    }
                    else if (dt.Rows.Count == 1)

                    {
                        DataRow dr = dt.Rows[0];
                        DataColumn dc = new DataColumn();
                        int Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                        if (Quantity >= 1)
                        {
                            multiviewSales.SetActiveView(View1);
                            multiviewSales.ActiveViewIndex = 0;
                            string productName = dr["ProductName"].ToString();
                            pdtNameTxt.Text = productName;
                            pdtNameTxt.Visible = true;
                            pdtNameTxt.Enabled = false;
                            ConfirmTxt.Visible = true;
                            CancelTxt.Visible = true;
                            selling_PriceTxt.Visible = true;
                            up_l.Visible = true;
                            selling_PriceTxt.Visible = true;
                            pdname_L.Visible = true;
                            Qty_L.Visible = true;
                            QuantityTxt.Visible = true;
                        }
                        else
                        {
                            string Nopdt_left = "Item is out of stock";
                            ShowErrorMessage(Nopdt_left);


                        }
                    }
                }
                catch (Exception pascal)
                {
                    ShowErrorMessage(pascal.ToString());
                }

            }
            else
            {
                string pdt_name_err = "Please enter Product Name";
                ShowErrorMessage(pdt_name_err);
            }
        }

        protected void search_Txt_Click(object sender, EventArgs e)
        {
            Search_Pdt();
        }

        public void SaleItem()
        {
            string pdx_name = pdtNameTxt.Text.Trim().ToString();
            int qty = Convert.ToInt32(QuantityTxt.Text.Trim().ToString());
            int selling_Price = Convert.ToInt32(selling_PriceTxt.Text.Trim().ToString());
            object[] Qty_Requested = { pdx_name };
            dt = dh.retrieveData(FindProcedure.Qty_left, Qty_Requested);
            if (dt.Rows.Count == 1)

            {
                try
                {
                    int result;

                    DataRow dr = dt.Rows[0];
                    int av_qty = Convert.ToInt32(dr["quantity"].ToString());
                    if (av_qty >= qty)
                    {

                        DataTable dt_1 = new DataTable();
                        dt_1 = dh.retrieveData(FindProcedure.PdtID_finder, Qty_Requested);
                        DataRow dr1 = dt_1.Rows[0];
                        int productID = Convert.ToInt32(dr1["ProductID"].ToString());
                        int TotalPrice = qty * selling_Price;
                        DateTime sellingDate = DateTime.Now;
                        object[] saleDetails = { productID, pdx_name, qty, selling_Price, TotalPrice, sellingDate };
                        result = Convert.ToInt32(dh.ExecuteDataSet(FindProcedure.ConfirmSales, saleDetails));

                        if (result == 2)
                        {
                            tb = (DataTable)ViewState["table1"];
                            dr = tb.NewRow();
                            dr["Prod_Name"] = pdx_name;
                            dr["Quantity"] = qty;
                            dr["UnitPrice"] = "R" + selling_Price;
                            dr["TotalPrice"] = TotalPrice;
                            tb.Rows.Add(dr);
                            gridView2.DataSource = tb;
                            gridView2.DataBind();
                            gridView2.Visible = true;

                        }

                    }
                }
                catch (Exception pascal)
                {
                    string err_2 = pascal.ToString();
                    ShowErrorMessage(err_2);
                }


            }

        }

        protected void ConfirmTxt_Click(object sender, EventArgs e)
        {


            SaleItem();
            Total_lbl.Visible = true;
            total_txt.Visible = true;
            total_txt.Text = "0";
            Amount_Paid.Visible = true;
            Amount_Paid_txt.Visible = true;
            bal_lb.Visible = true;
            Bal_txt.Visible = true;
            for (int i = 0; i < gridView2.Rows.Count; i++)
            {
                total_txt.Text = Convert.ToString(double.Parse(total_txt.Text) + double.Parse(gridView2.Rows[i].Cells[3].Text.ToString()));
            }
            total_txt.Enabled = false;
            Bal_txt.Enabled = false;
            // clear fields
        

            pdtNameTxt.Text = "";
            QuantityTxt.Text = "";
            selling_PriceTxt.Text = "";

        }

        protected void ShowErrorMessage(string message)
        {
            ErrorTxt.Style.Add("class", "login-error");
            ErrorTxt.Text = message;
        }

        public void createtable()
        {

            tb.Columns.Add("Prod_Name", typeof(string));
            tb.Columns.Add("Quantity", typeof(string));
            tb.Columns.Add("UnitPrice", typeof(string));
            tb.Columns.Add("TotalPrice", typeof(string));
            gridView2.DataSource = tb;
            gridView2.DataBind();
            ViewState["table1"] = tb;
        }

        protected void Amount_Paid_txt_TextChanged(object sender, EventArgs e)

        {


            if (!string.IsNullOrEmpty(Amount_Paid_txt.Text))
            {
                try {
                    int cash = Convert.ToInt32(Amount_Paid_txt.Text.Trim().ToString());
                    int total_Pd = Convert.ToInt32(total_txt.Text.Trim().ToString());
                    if (cash >= total_Pd)
                    {
                        ErrorTxt.Visible = false;
                        int Balance = cash - total_Pd;
                        Bal_txt.Text = Convert.ToString(Balance);
                       
                    }

                    else
                    {
                        string cash_value1 = "Insufficient funds";
                        ShowErrorMessage(cash_value1);
                    }
                }
                catch(Exception ex)
                {
                    ShowErrorMessage(ex.ToString());
                }
                
            }

        }

        protected void CancelTxt_Click(object sender, EventArgs e)
        {
            ProductNameTxt.Text = "";
            pdtNameTxt.Text = "";
            QuantityTxt.Text = "";
            selling_PriceTxt.Text = "";
        }
    }
}
