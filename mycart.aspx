<%@ Page Language="C#"  MasterPageFile="~/AURA Swift.Master" 
    AutoEventWireup="true" CodeBehind="mycart.aspx.cs" Inherits="AURA_Swift.cart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="searchresults">
            <asp:DataList ID="cart_products" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <%--OnItemDataBound="FashionProducts_ItemDataBound"--%>
                <ItemTemplate>
                    <table>
                        <tr>
                            <div class="product" id="product-1">
                                <img class="product_image" src="<%#Eval("picture") %>" />
                                <div class="product_details">
                                    <div class="pname"><%#Eval("ProductName") %></div>
                                    <div class="p_description"><%#Eval("ProductDescription") %></div>
                                    <div class="p_price">Price: Rs.<%#Eval("UnitPrice") %></div>
                                    <div class="p_Unit">Units: <%#Eval("Quantity") %></div>
                                    <div class="p_Unit">Max Units Available : <%#Eval("AvailableUnit") %></div>
                                    <div class="cartbutton_div">
                                        <asp:Button class="cart_buttons" ID="UpdateUnits" Text="Update Units  " runat="server" OnClick="updateUnits_Click" CommandArgument='<%#Eval("ProductID") + ","+Eval("Quantity")+ ","+Eval("AvailableUnit") %>' />

                                        <asp:Button class="cart_buttons" ID="Remove" Text="Remove from Cart  " runat="server" OnClick="removeProduct_Click" CommandArgument='<%#Eval("ProductID")%>' />
                                        <asp:Button class="cart_buttons" ID="viewprod" Text="View Product" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="total">
            Total: Rs.
           <asp:TextBox class="total_textbox" ID="txttotal" Text="Total Price" runat="server" Enabled="false" ReadOnly="true" Width="70%"></asp:TextBox>
        </div>
        <div>
            <asp:Button class="checkoutbutton" Text="Proceed to checkout" runat="server" OnClick="checkout_Click" />
        </div>
    </form>
</asp:Content>
