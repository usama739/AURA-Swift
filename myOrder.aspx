<%@ Page Language="C#"  MasterPageFile="~/AURA Swift.Master" 
    AutoEventWireup="true" CodeBehind="myOrder.aspx.cs" Inherits="AURA_Swift.myOrder" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="searchresults">
            <asp:DataList ID="supplier_products" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <%--OnItemDataBound="FashionProducts_ItemDataBound"--%>
                <ItemTemplate>
                    <table>

                        <tr>

                            <div class="product" id="product-1">
                                <img class="product_image"   src="<%#Eval("Picture") %>"/>
                                <div class="product_details">
                                 <div class="pname"><%#Eval("ProductName") %></div>
                                    <div class="p_description"><%#Eval("ProductDescription") %></div>
                                    <div class="p_price">Price: Rs.<%#Eval("UnitPrice") %></div>
                                    <div class="p_Unit">Units: <%#Eval("Quantity") %></div>
                                    

                                         
                                </div>
                            </div>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
        
    </form>

</asp:Content>
