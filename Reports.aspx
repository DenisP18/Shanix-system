<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Reports.aspx.cs" Inherits="Demo.Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       
        <form runat="server" >
            <center>
             <div class="mt-5 login-div nunito-font">
			<asp:Label ID="ErrorTxt" runat="server" Font-Bold="true" ForeColor="Red" Text="" CssClass="error" ></asp:Label>
				</div></center>
         
                 <center>
             <div class="mt-5 login-div nunito-font">
			<asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="Red" Text="" CssClass="error" ></asp:Label>
				</div></center>

                 <center>
             <p>  <center> 
                  <asp:label runat="server">Reports:</asp:label> &nbsp&nbsp&nbsp
                 <asp:DropDownList runat="server" ID="Report_list" AutoPosback="true" OnSelectedIndexChanged="Report_list_SelectedIndexChanged"  >
                      <asp:ListItem>Select Report</asp:ListItem>
                     <asp:ListItem>Periodic Txn Rpt</asp:ListItem>
                        <asp:ListItem>Available Stock Rpt</asp:ListItem>
                           <asp:ListItem>Stocked items</asp:ListItem>
                            
                   </asp:DropDownList>
              <asp:label runat="server"   >Start Date</asp:label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="StartDateTxt" runat="server"    Type="Date" placeholder="" CssClass="nunito-font"></asp:TextBox>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <asp:label runat="server"  >End Date</asp:label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="EndDateTxt"  Type="Date" runat="server" placeholder="" CssClass="nunito-font" ></asp:TextBox>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
               
                   <asp:Button ID="search_Txt" runat="server" Text="Search" onclick="search_Txt_Click" CssClass="submit ml-4" BorderStyle="None" ForeColor="#0099FF"/>
                 
            </center></p>
                  <asp:Button ID="DownloadTxt" onclick="DownloadTxt_Click"  runat ="server" Text="Downlaod" CssClass="submit ml-4" Visible="false" BorderStyle="None"/>
                             <center>
                         <div class="row">
                                    <div class="col-lg-9">
                                                 <asp:GridView ID="gridView" runat="server"  CssClass="nunito-font" BackColor="White" Width="600px"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="2"
                                                        HorizontalAlign="Center" AutoGenerateColumns="false" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                                                        <FooterStyle BackColor="White" ForeColor="#006400" />
                                                        <HeaderStyle CssClass="main-color-bg nunito-font" Font-Bold="True" ForeColor="Black"
                                                            HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#006400" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#006400" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                        <AlternatingRowStyle BackColor="#66CCFF" />
                                                     <Columns>
                                                          <asp:BoundField DataField="SellingDate"  DataFormatString="{0:N0}" HeaderText="Selling Date" />
                                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                            <asp:BoundField DataField="SellingPrice" HeaderText="Unit Price" />
                                                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                                                        </Columns>
                                                    </asp:GridView></div>
                                                    </div></center>

               <center>
                         <div class="row" id ="">
                                    <div class="col-lg-9" style="left: -7px; top: 19px">
                                                 <asp:GridView ID="gridAvStock" runat="server"  CssClass="nunito-font" BackColor="White" Width="600px"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="2"
                                                        HorizontalAlign="Center" AutoGenerateColumns="false">
                                                        <FooterStyle BackColor="White" ForeColor="#006400" />
                                                        <HeaderStyle CssClass="main-color-bg nunito-font" Font-Bold="True" ForeColor="Black"
                                                            HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" BackColor="White" />
                                                        <SelectedRowStyle BackColor="#006400" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#006400" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                            <AlternatingRowStyle BackColor="#66CCFF" />
                                                     <Columns>
                                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                            <asp:BoundField DataField="Category" HeaderText="Category" />
                                                         <asp:BoundField DataField="Date Last Stocked"   HeaderText="Date Last Stocked" />
                                                        </Columns>
                                                    </asp:GridView></div>
                                                    </div></center>


                                                    <center>
                         <div class="row">
                                    <div class="col-lg-9" style="left: 4px; top: 48px">
                                                 <asp:GridView ID="Stock_Rpt" runat="server"  CssClass="nunito-font" BackColor="White" Width="600px"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="2"
                                                        HorizontalAlign="Center" AutoGenerateColumns="false">
                                                        <FooterStyle BackColor="White" ForeColor="#006400" />
                                                        <HeaderStyle CssClass="main-color-bg nunito-font" Font-Bold="True" ForeColor="Black"
                                                            HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#006400" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#006400" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                          <AlternatingRowStyle BackColor="#66CCFF" />
                                                     <Columns>
                                                          <asp:BoundField DataField="Stock_Date" HeaderText="Date of Stock" />
                                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                            <asp:BoundField DataField="Category" HeaderText="Category" />
                                                            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                                                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />

                                                     
                                                        </Columns>
                                                    </asp:GridView></div>
                                                    </div></center>
         </form>
            <br />

	  <p>
		
	  </p>
    </div>
       

</asp:Content>
