using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary;
using Demo.Database_handler;
using Demo.Entity_Objects;
namespace Demo
{
    public partial class Stocks : System.Web.UI.Page
    {

        databaseHandler dh = new databaseHandler();

        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void AddProducts()

        {
            if (!string.IsNullOrEmpty(ProductIdTxt.Text))
            {
                if (!string.IsNullOrEmpty(ProductNameTxt.Text))
                {
                    if (!string.IsNullOrEmpty(QuantityText.Text))
                    {
                        if (!string.IsNullOrEmpty(unitpriceTxt.Text))
                        {
                            if (Catergory_list.SelectedItem.Text.ToString() != "Select Category")
                            {
                                DateTime EntryDate = Convert.ToDateTime(EntryDateTxt.Text.Trim());
                                if (EntryDate == DateTime.Today)
                                {

                                    try

                                    {

                                        string product_ID = ProductIdTxt.Text.Trim().ToString();
                                        string productName = ProductNameTxt.Text.Trim().ToString();
                                        int quantity = Convert.ToInt32(QuantityText.Text.Trim());
                                        int unitprice = Convert.ToInt32(unitpriceTxt.Text.Trim().ToString());
                                        string category = Catergory_list.SelectedItem.Text.ToString();
                                        int TotalPrice = quantity * unitprice;
                                        object[] add_products = { product_ID, productName, quantity, unitprice, EntryDate, category, TotalPrice };
                                        int result = Convert.ToInt32(dh.ExecuteDataSet(FindProcedure.enterItem, add_products));

                                        if (result > 1)
                                        {
                                            ErrorTxt.ForeColor = System.Drawing.Color.Green;
                                            string success = "Item saved Sucessfully";

                                            ProductIdTxt.Text = " ";
                                            ProductNameTxt.Text = " ";
                                            QuantityText.Text = " ";
                                            EntryDateTxt.Text = " ";
                                            unitpriceTxt.Text = " ";
                                            Catergory_list.SelectedValue = "Select Category";
                                            ShowErrorMessage(success);
                                        }

                                    }
                                    catch (Exception pascal)
                                    {

                                        ShowErrorMessage(pascal.ToString());

                                        ProductIdTxt.Text = " ";
                                        ProductNameTxt.Text = " ";
                                        QuantityText.Text = " ";
                                        EntryDateTxt.Text = " ";
                                        unitpriceTxt.Text = " ";

                                    }

                                }
                                else
                                {
                                    string message = " Please select Today Date";
                                    ShowErrorMessage(message);

                                    ProductIdTxt.Text = " ";
                                    ProductNameTxt.Text = " ";
                                    QuantityText.Text = " ";
                                    EntryDateTxt.Text = " ";
                                    unitpriceTxt.Text = " ";

                                }
                            }
                            else
                            {
                                string message = " Please select a valid Category";
                                ShowErrorMessage(message);

                                ProductIdTxt.Text = " ";
                                ProductNameTxt.Text = " ";
                                QuantityText.Text = " ";
                                EntryDateTxt.Text = " ";
                                unitpriceTxt.Text = " ";

                            }
                        }
                            
                        else
                        {
                            string message = " Please Enter UnitPrice";
                            ShowErrorMessage(message);

                            ProductIdTxt.Text = " ";
                            ProductNameTxt.Text = " ";
                            QuantityText.Text = " ";
                            EntryDateTxt.Text = " ";
                            unitpriceTxt.Text = " ";

                        }

                    }
                    else
                    {
                        string Quantity_Error = " Enter Quantity";
                        ShowErrorMessage(Quantity_Error);

                        ProductIdTxt.Text = " ";
                        ProductNameTxt.Text = " ";
                        QuantityText.Text = " ";
                        EntryDateTxt.Text = " ";
                        unitpriceTxt.Text = " ";

                    }
                }
                else
                {
                    string Product_Name_Error = " Enter Product Name";
                    ShowErrorMessage(Product_Name_Error);

                    ProductIdTxt.Text = " ";
                    ProductNameTxt.Text = " ";
                    QuantityText.Text = " ";
                    EntryDateTxt.Text = " ";
                    unitpriceTxt.Text = " ";

                }

            }
            else
            {

                string Product_ID_Error = " Enter ProductID";
                ShowErrorMessage(Product_ID_Error);

                ProductIdTxt.Text = " ";
                ProductNameTxt.Text = " ";
                QuantityText.Text = " ";
                EntryDateTxt.Text = " ";
                unitpriceTxt.Text = " ";

            }

        }

        protected void SaveItems_btn(object sender, EventArgs e)
        {
            AddProducts();
        }
        protected void ShowErrorMessage(string message)
        {
            ErrorTxt.Style.Add("class", "login-error");
            ErrorTxt.Text = message;
        }
        protected void CancelTxt_Click(object sender, EventArgs e)
        {
            ProductIdTxt.Text= " ";
            ProductNameTxt.Text = " ";
            QuantityText.Text = " ";
            EntryDateTxt.Text = " ";
            unitpriceTxt.Text = " ";
            
            ErrorTxt.Visible = false;

        }

        protected void Catergory_list_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
    }
