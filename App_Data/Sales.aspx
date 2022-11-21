<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="Demo.Sales" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
    <div class="jumbotron">
    <asp:MultiView ID="multiviewSales" runat="server">
         
         <asp:View ID="View1" runat="server">
             <form runat="server">
                 <center>
             <div class="mt-5 login-div nunito-font">
			<asp:Label ID="ErrorTxt" runat="server" Font-Bold="true" ForeColor="Red" Text="" CssClass="error" ></asp:Label>
				</div></center>

                 <center>
             <p>   
             <asp:label runat="server" >Product Name</asp:label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="ProductNameTxt" runat="server"  placeholder="" CssClass="nunito-font" type="Text"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                 <asp:Button ID="search_Txt" runat="server" Text="Search" OnClick="search_Txt_Click" CssClass="submit ml-4" BorderStyle="None" ForeColor="#0099FF"/>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ProductNameTxt"
                     ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Product Name can not be a number"/>
              </p>
   
                    
                <asp:label runat="server" ID="pdname_L"  Visible="false">Product Name</asp:label>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 <asp:TextBox ID="pdtNameTxt" Visible="false" runat="server" placeholder="" CssClass="nunito-font"></asp:TextBox>
                 
                   <asp:Label runat="server" ID="Qty_L" Visible="false">Quantity</asp:Label>
                         &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="QuantityTxt" runat="server" placeholder="" CssClass="nunito-font" type="number" min="1" Visible="false"></asp:TextBox>
                
                 <asp:Label runat="server" ID="up_l" Visible="false">Unit Price</asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="selling_PriceTxt" Visible="false" runat="server" placeholder="" CssClass="nunito-font" type="number" min="1"></asp:TextBox>
                         
                <br/>
                <br/>
                     <center>
                         <p>
                             <asp:Button ID="ConfirmTxt" runat="server" CssClass="submit ml-4" onclick="ConfirmTxt_Click" Text="Confirm" Visible="false" BorderStyle="None" ForeColor="#0099FF" />
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="CancelTxt" runat="server" CssClass="submit ml-2" size="50" Text="Cancel" Visible="false" onclick="CancelTxt_Click" BorderStyle="None" ForeColor="Red" />
                         </p>
                     </center>
                     <div class="row">
                         <strong>
                         <asp:Label ID="Total_lbl" runat="server" Visible="false">Total:</asp:Label>
                         </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="total_txt" runat="server" CssClass="nunito-font" placeholder="" Visible="false"></asp:TextBox>
                       
                         <strong>
                         <asp:Label ID="Amount_Paid" runat="server" Visible="false">Cash:</asp:Label>
                         </strong>&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="Amount_Paid_txt" runat="server" CssClass="nunito-font" placeholder="" Visible="false" OnTextChanged="Amount_Paid_txt_TextChanged"></asp:TextBox>
                        
                         <strong>
                         <asp:Label ID="bal_lb" runat="server" Visible="false">Balance:</asp:Label>
                         </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="Bal_txt" runat="server" CssClass="nunito-font" placeholder="" Visible="false"></asp:TextBox>
                         <br/>
                         <br/>
                         <div class="col-lg-9">
                             <asp:GridView ID="gridView2" runat="server" AutoGenerateColumns="true" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0" CellPadding="0" CssClass="nunito-font" HorizontalAlign="Center" Visible="false" Width="424px">
                                 <FooterStyle BackColor="White" ForeColor="#006400" />
                                 <HeaderStyle CssClass="main-color-bg nunito-font" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                                 <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                 <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                                 <SelectedRowStyle BackColor="#006400" Font-Bold="True" ForeColor="White" />
                                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                 <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                 <SortedDescendingCellStyle BackColor="#006400" />
                                 <SortedDescendingHeaderStyle BackColor="#00547E" />
                                 <Columns>
                                 </Columns>
                             </asp:GridView>
                         </div>
                     </div>
                     <br/>
                     <br/>

                </form></asp:View> 
 
        <!-- Receipt session-->
        
     </asp:MultiView>
        </div>

</asp:Content>