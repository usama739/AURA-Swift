<%@ Page Language="C#" MasterPageFile="~/AURA Swift.Master" AutoEventWireup="true" CodeBehind="supplierSignup.aspx.cs" Inherits="AURA_Swift.supplierSignup" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bigimage">
        <img src="images/GM.jpg" class="Grocery">
    </div>
        
        <br />

       <form runat="server">
       
  <asp:Panel ID="Panel2" runat="server" DefaultButton="btnSignupSeller" >

        <div class="userForm">
            <div class="formTitle">
                SIGNUP 
            </div>
            <div class="formContent">
                <asp:TextBox ID="txtFName" placeholder="First Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFName"
                    ErrorMessage="Please provide your First name." ForeColor="Red" Display="Dynamic" 
                    ValidationGroup="signup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtFName" Display="Dynamic" ErrorMessage="use only alphabets and length must be less than 20." 
                    ForeColor="Red" 
                    ValidationExpression="[a-zA-Z]{1,20}" 
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
                <br />

                <asp:TextBox ID="txtLName" placeholder="Last Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtLName"
                    ErrorMessage="Please provide your Last name." ForeColor="Red" Display="Dynamic" 
                    ValidationGroup="signup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtLName" Display="Dynamic" ErrorMessage="use only alphabets length must be less than 20." 
                    ForeColor="Red" 
                    ValidationExpression="[a-zA-Z]{1,20}" 
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
                <br />
               
               
                <asp:TextBox ID="txtUserName" placeholder="User Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"
                    ErrorMessage="Create a username." ForeColor="Red" Display="Dynamic" 
                    ValidationGroup="signup"></asp:RequiredFieldValidator>
                  <asp:Label ID="Label3" runat="server" ForeColor="Red" text="Username Already Exits"
                    Visible="False"></asp:Label> 
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                    ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="username must start from alphabet and length must be less than 20."
                    ForeColor="Red" 
                   ValidationExpression="^[a-zA-Z]{1,}[a-zA-Z0-9'@&#.\s]{2,19}$"
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
              <br />
                
               
               
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
             
               
               
                <asp:TextBox ID="txtAgainPassword" placeholder="Repeat Password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    BorderColor="Red" ControlToValidate="txtAgainPassword" Display="Dynamic" 
                    ErrorMessage="Enter password again." ForeColor="Red" 
                    ValidationGroup="signup"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPassword" ControlToValidate="txtAgainPassword" 
                    Display="Dynamic" ErrorMessage="Password don't match." ForeColor="Red" 
                    ValidationGroup="signup"></asp:CompareValidator>
               
                
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem> 
                </asp:DropDownList>
                <br />
               
                
                <asp:TextBox ID="txtEmail" placeholder="Email" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Please enter your Email address." ForeColor="Red" 
                    Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Invalid Email." 
                    ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
                <asp:Label ID="Label2" runat="server" ForeColor="Red" text="Email Already Exits"
                    Visible="False"></asp:Label> 
                <br />
               
                
                <asp:TextBox ID="txtContact" placeholder="XXXXXXXXXXX" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtContact"
                    ErrorMessage="Please fill your contact number." ForeColor="Red" 
                    Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
              
                   <br />
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtContact" Display="Dynamic" ErrorMessage="Invalid Phone." 
                    ForeColor="Red" 
                    ValidationExpression="\d{11}" 
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
                 
                
                <asp:TextBox ID="txtCompanyname" placeholder="Company Name" runat="server"></asp:TextBox>
                 <br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCompanyname"
                    ErrorMessage="Please enter your Company Name." ForeColor="Red" 
                    Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                    ControlToValidate="txtCompanyname" Display="Dynamic" ErrorMessage="Length must be less than 50." 
                    ForeColor="Red" 
                    ValidationExpression="^[a-zA-Z0-9'@&#.\s]{1,50}$" 
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
                
                
                <asp:TextBox ID="txtCity" placeholder="city" runat="server"></asp:TextBox>
                 <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                    ErrorMessage="Please enter your city." ForeColor="Red" 
                    Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                    ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="use only alphabets length less than 20." 
                    ForeColor="Red" 
                    ValidationExpression="[a-zA-Z]{1,20}" 
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
               
                
              
                <asp:TextBox ID="txtCountry" placeholder="country" runat="server"></asp:TextBox>
                 <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCountry"
                    ErrorMessage="Please enter your country." ForeColor="Red" 
                    Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCountry"
                    ErrorMessage="Please enter your city." ForeColor="Red" 
                    Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                    ControlToValidate="txtCountry" Display="Dynamic" ErrorMessage="use only alphabets and length less than 20." 
                    ForeColor="Red" 
                    ValidationExpression="[a-zA-Z]{1,20}" 
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
               
                
               
                <asp:TextBox ID="txtPostalcode" placeholder="Postal Code" runat="server"></asp:TextBox>
                 <br />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPostalcode"
                    ErrorMessage="Please provide your Postal Code." ForeColor="Red" 
                    Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
                    ControlToValidate="txtPostalcode" Display="Dynamic" ErrorMessage="use only digit length must be equal to 16." 
                    ForeColor="Red" 
                    ValidationExpression="\d{1,16}" 
                    ValidationGroup="signup"></asp:RegularExpressionValidator>
                
               
                <asp:TextBox ID="txtAddress" placeholder="Shop Address" Rows="5" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAddress"
                    ErrorMessage="Please provide your shipping address." ForeColor="Red" 
                    Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
                <br />
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" 
                    ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Length must be less than 100." 
                    ForeColor="Red" 
                    ValidationExpression="^[a-zA-Z0-9'@&#.\s]{1,100}$" 
                    ValidationGroup="signup"></asp:RegularExpressionValidator>

                
                 <div class="rememberme">
                    <asp:CheckBox ID="CheckBox1" runat="server" /><p>Remember me</p>
                </div>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" 
                    Visible="False"></asp:Label> <br />
                <div class="forgot_button">
                    <asp:Button ID="btnSignupSeller" runat="server" Text="Submit" 
                     ValidationGroup="signup" OnClick="btnSignupSeller_Click" />
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