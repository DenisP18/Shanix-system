using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo.Database_handler;
using Demo.Entity_Objects;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Demo
{
    public partial class _Default : Page
    {

        databaseHandler dh = new databaseHandler();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void authenticateUser()
        {
            if (!string.IsNullOrEmpty(UsernameTxt.Text))
            {
                if (!string.IsNullOrEmpty(PasswordTxt.Text))
                {

                    try
                    {
                        String username = UsernameTxt.Text.Trim().ToString();
                        String password = PasswordTxt.Text.Trim().ToString();
                        object[] userDetails = { username, password };
                        dt= dh.retrieveData(FindProcedure.loginUser, userDetails);
                        if (dt.Rows.Count == 1)
                        {
                            foreach (DataRow dr in dt.Rows) 
                            {
                                string usertype = dr["userRole"].ToString();
                                Session["username"] = username;
                                Session["userRole"] = usertype;
                            }
                            if (Session["userRole"].Equals("admin"))
                            {
                                Response.Redirect("Stocks.aspx");
                            }
                            else if (Session["userRole"].Equals("user"))
                            {
                                Response.Redirect("Sales.aspx");
                            }


                        }
                        else
                        {
                            string error = "Invalid login credentials, please try again!";
                            ShowErrorMessage(error);
                            UsernameTxt.Text = " ";
                            PasswordTxt.Text = " ";
                        }



                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex.ToString());
                    }

                }
                else 
                {
                    string error = "Please Enter Password";
                    ShowErrorMessage(error);
                    UsernameTxt.Text = " ";
                    PasswordTxt.Text = " ";
                }
            }
            else
            {
                string error = "Please Enter Username";
                ShowErrorMessage(error);
                UsernameTxt.Text = " ";
                PasswordTxt.Text = " ";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            authenticateUser();
        }

        protected void ShowErrorMessage(string message)
        {
            ErrorTxt.Style.Add("class", "login-error");
            ErrorTxt.Text = message;
        }


    }
}