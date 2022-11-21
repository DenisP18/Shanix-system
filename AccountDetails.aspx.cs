using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo.Database_handler;
using Demo.Entity_Objects;
using System.Data;

namespace Demo
{
    public partial class AccountDetails : System.Web.UI.Page
    {

        databaseHandler dh = new databaseHandler();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            create_Account();

        }
         public void create_Account()
        {
            if (!String.IsNullOrEmpty(SurnameTxt.Text))
            {
                if (!String.IsNullOrEmpty(FirstNameTxt.Text))
                {
                    if (!String.IsNullOrEmpty(UsernameTxt.Text))
                    {
                        if (!String.IsNullOrEmpty(Tel_NoTxt.Text))
                        {
                            if (!String.IsNullOrEmpty(PasswordTxt.Text))
                            {
                                if (!String.IsNullOrEmpty(ConfirmPasswordTxt.Text))
                                {
                                    try
                                    {
                                        string surname = SurnameTxt.Text.Trim().ToString();
                                        string firstname = FirstNameTxt.Text.Trim().ToString();
                                        string username = UsernameTxt.Text.Trim().ToString();
                                        string password = PasswordTxt.Text.Trim().ToString();
                                        string telephone = Tel_NoTxt.Text.Trim().ToString();
                                        string confirmed_pwd = ConfirmPasswordTxt.Text.Trim().ToString();
                                        DateTime creation_Date = DateTime.Now;
                                        if (password==confirmed_pwd) 
                                        {
                                            try
                                            {
                                                object[] parms = { username, password };

                                                dt = dh.retrieveData(FindProcedure.Find_existingUser, parms);
                                                if (dt.Rows.Count > 1)
                                                {
                                                    string ext_user = "Account already Existing";
                                                    ShowErrorMessage(ext_user);
                                                    clr_fields();
                                                }
                                                else
                                                {
                                                    object[] userDetails = { surname, firstname, telephone, username, password, creation_Date };
                                                    int result = Convert.ToInt32(dh.ExecuteDataSet(FindProcedure.create_acc, userDetails));
                                                    if (result == 1)
                                                    {
                                                        string Successful_Account = "Account successfully Created";
                                                        ShowErrorMessage(Successful_Account);
                                                    }
                                                    clr_fields();
                                                }

                                            }
                                            catch (Exception ex )
                                            {
                                                string s = ex.ToString();
                                                ShowErrorMessage(s);

                                            }
                                        }
                                        else
                                        {
                                            string unmatched_pwds = "Passwords did not match";
                                            ShowErrorMessage(unmatched_pwds);
                                            clr_fields();

                                        }

                                    }
                                    catch ( Exception ex)
                                    {
                                        ShowErrorMessage(ex.ToString());
                                    }
                                   

                                }
                                else
                                {
                                    string pwd2_err = "Please Enter Password Again";
                                    ShowErrorMessage(pwd2_err);
                                }

                            }
                            else if(PasswordTxt.Text.Length<4)
                            {

                                string sht_pwd = "Password should be atleast 4 Characters";
                                ShowErrorMessage(sht_pwd);
                                clr_fields();
                            }
                            else
                            {
                                string pwd_err = "Please Enter password";
                                ShowErrorMessage(pwd_err);
                                clr_fields();
                            }
                        }
                        else
                         {
                            string tel_err = "Please Enter Telephone Number";
                            ShowErrorMessage(tel_err);
                            clr_fields();
                        }
                    }
                    else
                    {
                        string sname_err = "Please Enter username";
                        ShowErrorMessage(sname_err);
                        clr_fields();
                    }
                }
                else
                 {
                    string fname_err = "Please Enter firstname";
                    ShowErrorMessage(fname_err);
                    clr_fields();
                }
            }
            else
            {
                string sname_err = "Please Enter surname";
                ShowErrorMessage(sname_err);
                clr_fields();
            }
        }

        protected void ShowErrorMessage(string message)
        {
            ErrorTxt.Style.Add("class", "login-error");
            ErrorTxt.Text = message;
        }

        public void clr_fields()
        {
            SurnameTxt.Text = " ";
            FirstNameTxt.Text = " ";
            Tel_NoTxt.Text = " ";
            UsernameTxt.Text = " ";
            PasswordTxt.Text = " ";
            ConfirmPasswordTxt.Text= " ";
        }
    }
}