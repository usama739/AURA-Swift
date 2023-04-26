<%@ Page Language="C#" MasterPageFile="~/AURA Swift.Master" 
   AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="AURA_Swift.Activation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bigimage">
        <img src="images/GM.jpg" class="Grocery">
    </div>
    <form runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div class="userForm">
            <div class="formTitle">
                Activate Account
            </div>
            <div class="formContent">
                <asp:Label ID="Label1" Visible="true" Text="Check Email for Code <br />" ForeColor="Red" runat="server"></asp:Label>

                <asp:TextBox ID="txtCode" placeholder="Activation Code" runat="server" Width="418px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode"
                    Display="Dynamic" ErrorMessage="Activation Code is required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <asp:Button ID="Button1" runat="server" Text="Submit" />                  

                <asp:Label ID="lblError" Visible="False" Text="Incorrect Code <br />" ForeColor="Red" runat="server"></asp:Label>
            </div>
        </div>
    </asp:Panel>
    </form>     
    <br />

</asp:Content>