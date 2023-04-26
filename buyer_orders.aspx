<%@ Page Language="C#"  MasterPageFile="~/AURA Swift.Master"
    AutoEventWireup="true" CodeBehind="buyer_orders.aspx.cs" Inherits="AURA_Swift.buyer_orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="searchresults">
            <asp:DataList ID="buyer_orders_datalist" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">

                <ItemTemplate>
                    <table>
                        <tr>
                            <div class="order">
                                <div class="orderdetails">Order# <%#Eval("orderID") %></div>
                                <div class="orderdetails">Total: Rs.<%#Eval("total_price") %></div>
                                <div class="orderdetails">Status: <%#Eval("Statement") %></div> 
                            </div>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</asp:Content>