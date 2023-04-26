<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/AURA Swift.Master"
    CodeBehind="buyerPage.aspx.cs" Inherits="AURA_Swift.buyerPage" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
        <div class="bigimage">
             <img src="images/GM.jpg" class="Grocery">
        </div>
        <br>
        <div class="userNav">
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                <div class="navContent adminNavTitle">
                    <div class="navTitle">
                        ADMIN
                    </div>
                    <asp:HyperLink ID="hlAdmin" runat="server">Admin Panel</asp:HyperLink><br />
                </div>
            </asp:Panel>
            <div class="sideForm">
                <div class="navContent">
                    <div class="navTitle">
                        ACCOUNT
                    </div>
                    <asp:Button ID="hlProduct" PostBackUrl="buyerprofile.aspx" runat="server" Text="Update Profile" />
                    <br />

                    <asp:Button ID="hlChangePassword" PostBackUrl="changePassword.aspx" Text="Change Pasword" runat="server" />
                    <br />

                    <asp:Button ID="logout" Text="Log Out" runat="server" Height="27px" OnClick="logout_Click" Width="127px" />
                </div>
                <div class="navContent">
                    <div class="navTitle">
                        ORDERS
                    </div>
                    <asp:Button ID="hlMyOrders" runat="server" Text="My Orders" OnClick="order_page" /><br />
                </div>
            </div>
        </div>


        <asp:Panel ID="Panel1" runat="server">
            <div class="userForm">
                <div class="formTitle">
                    YOUR PROFILE
                </div>
                <div class="userinfo-display">
                    <asp:TextBox ID="fullnamedisplay" Text="Name" runat="server" Enabled="false" ReadOnly="true" Width="70%"></asp:TextBox>
                    <asp:TextBox ID="usernamedisplay" Text="Userame" runat="server" Enabled="false" ReadOnly="true" Width="70%"></asp:TextBox>
             
                </div>
               </div>
            
        </asp:Panel>
    </form>


</asp:Content>