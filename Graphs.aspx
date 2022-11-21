<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Graphs.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Demo.Grapphs" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <div class="jumbotron">
       
        <form runat="server" >
            <center>
             <div class="mt-5 login-div nunito-font" style="background-color: #FFFFFF">
			<asp:Label ID="ErrorTxt" runat="server" Font-Bold="true" ForeColor="Red" Text="" CssClass="error" ></asp:Label>
				</div></center>
            <center>
             <asp:label runat="server"   >Start Date</asp:label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="StartDateTxt" runat="server"    Type="Date" placeholder="" CssClass="nunito-font"></asp:TextBox>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <asp:label runat="server"  >End Date</asp:label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="EndDateTxt"  Type="Date" runat="server" placeholder="" CssClass="nunito-font" ></asp:TextBox>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
               
              <asp:Button ID="search_Txt" runat="server" Text="Display" onClick="search_Txt_Click" CssClass="submit ml-4" BorderStyle="None" ForeColor="#0099FF"/></center>
            </form></div>
 <asp:MultiView ID="multiviewSales" runat="server" Visible="false">
      <asp:View ID="View1" runat="server">
              <h2 aria-atomic="True" style="font-family: Verdana, Geneva, Tahoma, sans-serif; text-align: center; background-color: #3399FF; font-size: x-large; color: #FFFFFF;">Graphical view of sold items</h2>
              <div style="background-color: #FFFFFF">
                 

                    <asp:Chart ID="Chart1" runat="server" Height="383px" Width="875px">
                        <series>
                            <asp:Series Name="Series1">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>

                </div>
         </asp:View> </asp:MultiView >
</asp:Content>
