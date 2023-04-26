<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AURA Swift.Master" 
    CodeBehind="signupAs.aspx.cs" Inherits="AURA_Swift.signupAs" %>

  <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bigimage">
      <img src="images/GM.jpg" class="Grocery">
    </div>
        
        <br />
      <form runat="server">
          <asp:Panel ID="Panel2" runat="server">
              <div class="userForm">
                  <div class="formTitle">
                      SIGNUP AS
                  </div>
                  <div class="formContent">


                      <asp:Label ID="Label1" runat="server" ForeColor="Red"
                          Visible="true"></asp:Label>
                      <br />
                      <div class="login_buttons">
                          <asp:Button ID="btnSignupBuyer" runat="server" Text="Buyer" PostBackUrl="buyerSignup.aspx" ValidationGroup="signup" />
                          <asp:Button ID="btnSignupSeller" runat="server" Text="Seller" PostBackUrl="supplierSignup.aspx"
                              ValidationGroup="signup" />
                      </div>
                  </div>
              </div>
          </asp:Panel>


          <br />
        <br />
            <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
         
   </form>

</asp:Content>

