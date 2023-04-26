<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/AURA Swift.Master" 
    CodeBehind="sellerpage.aspx.cs" Inherits="AURA_Swift.sellerpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bigimage">
        <img src="images/GM.jpg" class="Grocery" />
    </div>


    <form runat="server">
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
                    <asp:Button ID="hlProfile" PostBackUrl="sellerprofile.aspx" runat="server" Text="Update Profile" />
                    <br />
                    <asp:Button ID="hlChangePassword" PostBackUrl="~/changePassword.aspx" Text="Change Pasword" runat="server" />
                    <br />
                    <asp:Button ID="logout" Text="Log Out" runat="server" Height="27px" Width="127px" OnClick="logout_Click" />

                </div>

                
             <div class="userNav">
                 <div class="navContent adminNavTitle">
                     <div class="navTitle">
                         Manage Products
                     </div>
                     <asp:Button ID="hlAddProduct" PostBackUrl="addProduct.aspx" runat="server" Text="Add New Product" /><br />

                     <asp:Button ID="hlListProducts" runat="server" Text="List Products" OnClick="hlListProducts_Click" /><br />
                     <asp:Button ID="seller_orders" runat="server" Text="Orders" Onclick="order_page" /><br />
                 </div>
             </div>
            </div>
        </div>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <div class="userForm">
                <div class="formTitle">
                    YOUR PROFILE
                </div>
                <div class="userinfo-display">
                    <asp:TextBox ID="fullnamedisplay" Text="Name" runat="server" Enabled="false" ReadOnly="true" Width="70%"></asp:TextBox>
                    <asp:TextBox ID="usernamedisplay" Text="Userame" runat="server" Enabled="false" ReadOnly="true" Width="70%"></asp:TextBox>
                    <p class="statistics">STATISTICS</p>
                    <div class="stats">
                        Total Orders:
                        <asp:TextBox ID="totalorders" Text="Total Orders" runat="server" Enabled="false" ReadOnly="true"></asp:TextBox>
                        Total Revenue:
                        <asp:TextBox ID="totalrevenue" Text="Total Revenue" runat="server" Enabled="false" ReadOnly="true"></asp:TextBox>

                    </div>
                </div>
            </div>
        </asp:Panel>
    </form>
</asp:Content>