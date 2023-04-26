<%@ Page Language="C#"  MasterPageFile="~/AURA Swift.Master"   AutoEventWireup="true" 
    CodeBehind="product.aspx.cs" Inherits="AURA_Swift.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form runat="server">
        <div class="product_datalist">
             <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <asp:DataList ID="display_product" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <%--OnItemDataBound="FashionProducts_ItemDataBound"--%>
                <ItemTemplate>
                    <table>
                     <tr>
                            <ajaxToolkit:Rating ID="ProductRating" runat="server" AutoPostBack="true" 
             StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
            FilledStarCssClass="FilledStar" MaxRating="5" CurrentRating="0" onclick="Rating_product" >
                                 </ajaxToolkit:Rating>
                            <div class="product_display" id="product-1">
                                <img class="view_product_image" src="<%#Eval("Picture") %>" />
                                <div class="view_product_details">
                                    <div class="view_pname"><%#Eval("ProductName") %></div>
                                    <div class="view_p_description"><%#Eval("ProductDescription") %></div>
                                   <div class="view_p_price">Price: Rs.<%#Eval("UnitPrice") %></div>
                                        <div class="addtocartbutton">
                                        <asp:Button class="addtocart" Text="Add to cart" CommandArgument='<%#Eval("ProductID") %>' runat="server" OnClick="Addcart_Click" />
                                    </div>


                                </div>
                            </div>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <asp:Label ID="lblError" Visible="False" Text="Units not Available <br />" ForeColor="Red" runat="server"></asp:Label>
        </div>

    </form>
</asp:Content>
