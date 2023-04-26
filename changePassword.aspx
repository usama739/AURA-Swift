<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/AURA Swift.Master" 
    CodeBehind="changePassword.aspx.cs" Inherits="AURA_Swift.changePassword" %>

  <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bigimage">
           <img src="images/GM.jpg" class="Grocery">
    </div>
        
        <br />
      <form runat="server">
         <asp:Panel ID="Panel1" runat="server" DefaultButton="btnChange">
        <div class="userForm">
            <div class="formTitle">
                CHANGE PASSWORD
            </div>
            <div class="formContent">
                <asp:TextBox ID="txtPassword" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic" 
                    ValidationGroup="signup">Enter a password</asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password must be 8-16 characters long </br> with at least one numeric character."
                    ForeColor="Red" 
                    ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,16})$"
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
                <br />
             
               
               
                <asp:TextBox ID="txtAgainPassword" placeholder="Repeat Password" runat="server" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    BorderColor="Red" ControlToValidate="txtAgainPassword" Display="Dynamic" 
                    ErrorMessage="Enter password again." ForeColor="Red" 
                    ValidationGroup="signup"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPassword" ControlToValidate="txtAgainPassword" 
                    Display="Dynamic" ErrorMessage="Password don't match." ForeColor="Red" 
                    ValidationGroup="signup"></asp:CompareValidator>
                <asp:Button ID="btnChange" runat="server" Text="Submit" OnClick="btnChange_Click"  />
                <br />
                <asp:Label ID="lblError" Visible="False" ForeColor="Green" runat="server"></asp:Label></div>
        </div>
    </asp:Panel>
         <br /> <br /> <br /><br /> <br /> <br />                  
   </form>
</asp:Content>