<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Demo.AccountDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <center><h4><strong>CREATE ACCOUNT</strong></h4></center>
        <form runat="server" >
            <center>
             <div class="mt-5 login-div nunito-font">
			<asp:Label ID="ErrorTxt" runat="server" Font-Bold="true" ForeColor="Red" Text="" CssClass="error" ></asp:Label>
				</div></center>
  <center> 
      <asp:label runat="server">Surname:</asp:label> &nbsp&nbsp&nbsp&nbsp  
      <asp:TextBox ID="SurnameTxt" runat="server" CssClass="nunito-font"></asp:TextBox> &nbsp&nbsp&nbsp&nbsp 
      <asp:label runat="server">FirstName:</asp:label> &nbsp&nbsp&nbsp&nbsp  
      <asp:TextBox ID="FirstNameTxt" runat="server"  CssClass="nunito-font"></asp:TextBox><br />
      <br />
      <asp:label runat="server">Telephone:</asp:label>&nbsp&nbsp; &nbsp<asp:TextBox ID="Tel_NoTxt" runat="server" CssClass="nunito-font"></asp:TextBox>
      &nbsp&nbsp&nbsp&nbsp&nbsp;
      <asp:label runat="server">Username:</asp:label>&nbsp&nbsp&nbsp&nbsp; &nbsp 
	  <asp:TextBox ID="UsernameTxt" runat="server" CssClass="nunito-font"></asp:TextBox><br />
      <br />
<asp:label runat="server"> Password</asp:label>
	  :&nbsp;&nbsp;&nbsp;
	  <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password"  CssClass="password nunito-font" Width="153px"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:label runat="server"> Confirm Password</asp:label>
	  &nbsp;:&nbsp;&nbsp;&nbsp;
	  <asp:TextBox ID="ConfirmPasswordTxt" runat="server" TextMode="Password" CssClass="password nunito-font" style="margin-left: 6" Width="150px"></asp:TextBox>
</center>
            <br />
            <center> 
	<p class="remember_me">
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" CssClass="submit ml-4" BorderStyle="None" ForeColor="#0099FF"/> &nbsp&nbsp&nbsp&nbsp   <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="submit ml-4" BorderStyle="None" ForeColor="Red"/> 
	</p>
            </center>
	 
	  <p>
		
	  </p>

  </form>

       
    </div>
</asp:Content>