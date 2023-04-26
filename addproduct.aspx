<%@ Page Language="C#" MasterPageFile="~/AURA Swift.Master"
    AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="AURA_Swift.addproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form runat="server">
        <div class="bigimage">
           <img src="images/GM.jpg" class="Grocery">
        </div>
  
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
                    <asp:Button ID="hlProduct" PostBackUrl="sellerprofile.aspx" runat="server" Text="My Profile" />
                    <br />

                    <asp:Button ID="hlChangePassword" PostBackUrl="~/changePassword.aspx" Text="Change Pasword" runat="server" />
                </div>


                <div class="userNav">
                    <div class="navContent adminNavTitle">
                        <div class="navTitle">
                            Manage Products
                        </div>
                        <asp:Button ID="hlAddProduct" NavigateUrl="~/addProduct.aspx" runat="server" Text="Add New Product" /><br />
                        <asp:Button ID="hlListProducts" NavigateUrl="~/listProduct.aspx" runat="server" Text="List Products" /><br />


                    </div>

                </div>
            </div>

        </div>
        
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAdd">
                <div class="userForm adminForm">
                    <div class="formTitle">
                        ADD NEW PRODUCT
                    </div>
                    <div class="formContent">
                        <asp:TextBox ID="txtName" placeholder="Product Name" runat="server"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="txtDescription" runat="server" placeholder="Product Description"
                            TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="txtPrice" placeholder="Price" runat="server"></asp:TextBox>
                        <br />
                        
                         <asp:TextBox ID="txtUnit" placeholder="Available Units" runat="server"></asp:TextBox><br />
                         <asp:TextBox ID="txtWeight" placeholder="Unit Weight" runat="server"></asp:TextBox><br />
                         <asp:TextBox ID="txtAvailableColors" placeholder="Available Color" runat="server"></asp:TextBox><br />
                        <asp:DropDownList ID="ddlCategory" runat="server">

                            <asp:ListItem>GROCERY</asp:ListItem>
                    <asp:ListItem>FRUITS</asp:ListItem> 
                            <asp:ListItem>VEGETABLE</asp:ListItem>
                    <asp:ListItem>JUNK FOOD </asp:ListItem> 
                            <asp:ListItem>MEAT</asp:ListItem>

                            
                        </asp:DropDownList>
                        <br />
                        <asp:FileUpload ID="flImageUpload" runat="server" />
                        <br />
                        <asp:Label ID="lblStatus" Visible="False" Text="Product Add Successfully <br />" runat="server" ForeColor="Green"></asp:Label>
                        <br />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        <br />
                        <hr />

                    </div>
                </div>
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />   

    </form>

</asp:Content>