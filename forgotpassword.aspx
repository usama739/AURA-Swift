<%@ Page Language="C#" MasterPageFile="~/AURA Swift.Master" 
    AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="AURA_Swift.forgotpassword" %>

  <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bigimage">
        <img src="images/GM.jpg" class="Grocery">
    </div>
        
        <br />
       <form runat="server">
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnPasswordRecover">
                <div class="userForm">
                    <div class="formTitle">
                        Recover Password
           
                    </div>

                    <div class="formContent">
                        <div class="forgot_textboxes">
                        <asp:TextBox ID="txtEmail" placeholder="Email ID you signed up with." runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Please enter your Email address." ForeColor="Red" 
                    Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtEmail" ErrorMessage="Invalid Email ID" ForeColor="Red"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        
                        <asp:TextBox ID="txtUserName" placeholder="Username." runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"
                    ErrorMessage="Enter a username." ForeColor="Red" Display="Dynamic" 
                    ValidationGroup="signup"></asp:RequiredFieldValidator>
                          </div>
                            
                           <asp:TextBox ID="txtPassword" placeholder="Password" Visible="false" runat="server" TextMode="Password" Width="397px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic" 
                    ValidationGroup="signup">Enter a password</asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password must be 8-16 characters long </br> with at least one numeric character."
                    ForeColor="Red" 
                    ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,16})$"
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
               
               
               
                <asp:TextBox ID="txtAgainPassword" placeholder="Repeat Password" visible="false" runat="server" TextMode="Password" Width="398px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    BorderColor="Red" ControlToValidate="txtAgainPassword" Display="Dynamic" 
                    ErrorMessage="Enter password again." ForeColor="Red" 
                    ValidationGroup="signup"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPassword" ControlToValidate="txtAgainPassword" 
                    Display="Dynamic" ErrorMessage="Password don't match." ForeColor="Red" 
                    ValidationGroup="signup"></asp:CompareValidator>
                          <br />
                            <asp:Label ID="lblError" runat="server" ForeColor="Green"
                        Visible="False"></asp:Label>
                        <br />
                        <div class="forgot_button">
                            <asp:Button ID="btnPasswordRecover" runat="server" Visible="true" Text="Submit" OnClick="btnPasswordRecover_Click" Width="182px" />
                            <asp:Button ID="btnChangePass" runat="server" Visible="false" Text="Update" OnClick="btnChangePass_Click" Width="178px" />
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
        </div>
    </form>

</asp:Content>