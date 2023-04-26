<%@ Page Language="C#"  MasterPageFile="~/AURA Swift.Master" 
    AutoEventWireup="true" CodeBehind="listproducts.aspx.cs" Inherits="AURA_Swift.listproducts" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="searchresults">
            <asp:DataList ID="supplier_products" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">

                <ItemTemplate>
                    <table>

                        <tr>

                            <div class="product" id="product-1">
                                <img class="product_image" src="<%#Eval("Picture") %>" />
                                <div class="product_details">
                                    <div class="pname"><%#Eval("ProductName") %></div>
                                    
                                    <div class="p_price">Price: Rs.<%#Eval("UnitPrice") %></div>

                                </div>
                                <div class="buttons">
                                    <asp:Button class="EditProduct" Text="Edit Product" runat="server" CommandArgument='<%# Eval("ProductID") %>' OnClick="EditProduct_Click"/>
                                    <asp:Button class="deleteProduct" Text="Delete Product" runat="server" CommandArgument='<%# Eval("ProductID") %>' OnClick="DeleteProduct_Click" />
                                    <asp:Button class="see_my_Product" Text="View Product" runat="server" />
                                </div>

                            </div>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</asp:Content>