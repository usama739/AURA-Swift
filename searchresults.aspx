
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AURA Swift.Master" 
    CodeBehind="searchresults.aspx.cs" Inherits="AURA_Swift.searchresults" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form runat="server">
        <div class="searchresults">
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>


            <asp:DataList ID="furniture_products" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <%--OnItemDataBound="FashionProducts_ItemDataBound"--%>
                <ItemTemplate>
                    <table>

                        <tr>




                            <div class="product" id="product-1">
                                <img class="product_image" src="<%#Eval("Picture") %>" />
                                <div class="product_details">
                                    <div class="pname"><%#Eval("ProductName") %></div>
                                    <div class="p_description"><%#Eval("ProductDescription") %></div>
                                    <div class="p_price">Price: Rs.<%#Eval("UnitPrice") %></div>
                                </div>
                                <asp:Button class="ViewProduct" Text="View Product" runat="server" CommandArgument='<%#Eval("ProductID") %>' OnClick="view_product" />
                                <div class="stars">
                                    <ajaxToolkit:Rating ID="ProductRating" runat="server" AutoPostBack="true"
                                        StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                                        FilledStarCssClass="FilledStar" MaxRating="5" CurrentRating='<%#Eval("Rating") %>' ReadOnly="true">
                                    </ajaxToolkit:Rating>
                                </div>
                            </div>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>

    </form>

</asp:Content>
