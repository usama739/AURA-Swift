<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AURA Swift.Master" 
    CodeBehind="signin.aspx.cs" Inherits="AURA_Swift.signin" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <form runat="server">
        <div class="bigimage">
            <img src="images/GM.jpg" class="bedroomimg" />
        </div>
 <br />       
        
        <asp:Panel ID="Panel1" runat="server">
            <div class="userForm">
                <div class="formTitle">
                    LOGIN
                </div>
                <div class="formContent">
                    <asp:TextBox ID="txtUserName" placeholder="User Name" runat="server" Width="418px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                        Display="Dynamic" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" Width="417px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="Password field can't be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <div class="login_buttons">
                        <asp:Button ID="btnLoginBuyer" runat="server" Text="Buyer" OnClick="SigninBuyer" />
                        <asp:Button ID="btnLoginSeller" runat="server" Text="Seller" Visible="true" OnClick="btnLoginSeller_Click" />
                    </div>
                    <%--<br />--%>
                    <div class="rememberme" style="height: 51px; width: 129px">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember me" />
                        <%--<br />--%>
                    </div>
                    <asp:Label ID="lblError" Visible="False" Text="incorrect username or password <br />" ForeColor="Red" runat="server"></asp:Label>


                    <asp:HyperLink ID="HyperLink1" NavigateUrl="signupAs.aspx" runat="server">New Member? Sign up </asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="hlForgotPassword" runat="server" NavigateUrl="forgotPassword.aspx">Forgot Password</asp:HyperLink>
                </div>
            </div>
        </asp:Panel>
    </form>
    <br />
</asp:Content>
