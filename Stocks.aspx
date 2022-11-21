<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Stocks.aspx.cs" Inherits="Demo.Stocks" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

      <div class="jumbotron">
        <center><h2 style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; font-style: normal; font-weight: bold; font-variant: normal; text-transform: uppercase; color: #0000FF">ADD PRODUCTS</h2></center>
        <form runat="server" >
            <center>
             <div class="mt-5 login-div nunito-font">
			<asp:Label ID="ErrorTxt" runat="server" Font-Bold="true" ForeColor="Red" Text="" CssClass="error" ></asp:Label>
				</div></center>
            <p> <asp:label runat="server" >Product ID</asp:label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="ProductIdTxt" runat="server" placeholder="" CssClass="nunito-font"></asp:TextBox>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:label runat="server" >Product Name</asp:label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="ProductNameTxt" runat="server" placeholder="" CssClass="nunito-font"></asp:TextBox>
         </p>
            <br/>
             <p> <asp:label runat="server" >Quantity</asp:label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="QuantityText" runat="server" placeholder="" CssClass="nunito-font"></asp:TextBox>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:label runat="server" >Unit Price</asp:label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="unitpriceTxt" runat="server" placeholder="" CssClass="nunito-font"></asp:TextBox>
       &nbsp;</p>

            <br/>
             <p> <asp:label runat="server" >Entry Date</asp:label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="EntryDateTxt"  runat="server" placeholder="" Type ="date" CssClass="nunito-font"></asp:TextBox>
   &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:label runat="server">Catergory</asp:label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                 <asp:DropDownList runat="server" ID="Catergory_list" AutoPosback="true" OnSelectedIndexChanged="Catergory_list_SelectedIndexChanged" >
                      <asp:ListItem>Select Category</asp:ListItem>
                     <asp:ListItem>Crafts</asp:ListItem>
                        <asp:ListItem>Man Power</asp:ListItem>
                           <asp:ListItem>Miracle_Water</asp:ListItem>
                             <asp:ListItem>Oils</asp:ListItem>
                              <asp:ListItem>Creams</asp:ListItem>
                   </asp:DropDownList>
      &nbsp&nbsp&nbsp&nbsp&nbsp</p>
             
            <br/>
            <p class="remember_me">
            <center>
                 <asp:Button ID="SaveTxt" runat="server" Text="SAVE"  OnClick="SaveItems_btn" CssClass="submit ml-4" BorderStyle="None" ForeColor="#0099FF" style="margin-left: 0"/>
                &nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp&nbsp<asp:Button ID="CancelTxt" runat="server" Text="CANCEL" onclick="CancelTxt_Click" CssClass="submit ml-4" BorderStyle="None" ForeColor="Red"/> 
                                   </center>&nbsp;</p>
         
          
        </form></div>
   

    </asp:Content>

