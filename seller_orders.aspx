<%@ Page Title="" Language="C#"MasterPageFile="~/AURA Swift.Master"  AutoEventWireup="true" 
    CodeBehind="seller_orders.aspx.cs" Inherits="AURA_Swift.seller_orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="searchresults">
            <asp:DataList ID="seller_orders_datalist" runat="server" OnItemDataBound="seller_orders_datalist_ItemDataBound" RepeatColumns="2" RepeatDirection="Horizontal">

                <ItemTemplate>
                    <table>
                        <tr>
                            <div class="order">
                                <div class="orderdetails">Order# <%#Eval("orderID") %></div>
                                <div class="orderdetails">Product: <%#Eval("ProductID") %> </div>
                                <div class="orderdetails">Total: Rs.<%#Eval("total_price") %></div>
                                <div class="orderdetails">Status: <%#Eval("Statement") %></div>
                                <div class="orderdetails">Customer: <%#Eval("CustomerID") %></div>
                                
                                <div class="Editstatus">
                                   Edit Status: <asp:DropDownList ID="editstatus" OnSelectedIndexChanged="editstatus_SelectedIndexChanged" DataMember=' <%#Eval("orderID") %>' AutoPostBack="true" runat="server">
                                        <asp:ListItem Text="Pending" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Left Warehouse" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Delivered" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    
                                </div>
                            </div>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</asp:Content>
