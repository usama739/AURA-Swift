<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/AURA Swift.Master" 
    CodeBehind="sellerprofile.aspx.cs" Inherits="AURA_Swift.sellerprofile" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bigimage">
          <img src="images/GM.jpg" class="Grocery">
    </div>
        
       
       <form runat="server">
           <div class="userNav">
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <div class="navContent adminNavTitle">
                <div class="navTitle">
                    ADMIN
                </div>
                <asp:HyperLink ID="hlAdmin"  runat="server">Admin Panel</asp:HyperLink><br />
            </div>
        </asp:Panel>
             <div class="sideForm">
        <div class="navContent">
            <div class="navTitle">
                ACCOUNT
            </div>
              <asp:Button ID="hlProfile" PostBackUrl="sellerpage.aspx" runat="server" Text="My Profile" />
             <br />
           
           <asp:Button ID="hlChangePassword" PostBackUrl="~/changePassword.aspx" Text="Change Pasword" runat="server"/>
      <br />
            <asp:Button ID="logout"  Text="Log Out" runat="server" Height="27px"  Width="127px" OnClick="logout_Click"/>
      
            </div>
      
             
             <div class="userNav">
        <div class="navContent adminNavTitle">
            <div class="navTitle">
                Manage Products
            </div>
           <asp:Button ID="hlAddProduct" PostBackUrl="addproduct.aspx" runat="server" Text="Add New Product"/><br />
            <asp:Button ID="hlListProducts" OnClick="hlListProducts_Click" runat="server" Text="List Products"/><br />
            <asp:Button ID="seller_orders" runat="server" Text="Orders" Onclick="order_page" /><br />
           
       
   </div>
    
          </div>
       </div>
         
         </div>
            <br />
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSave">
        <div class="userForm">
            <div class="formTitle">
                PROFILE DETAILS
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

                
                
                <asp:Label ID="lblError" runat="server" ForeColor="Green" 
                    Visible="False"></asp:Label> <br />
                <asp:Button ID="btnSave" runat="server" Text="Update" 
                     ValidationGroup="validate"  />
            </div>
        </div>
            
    </asp:Panel>
         <br /> <br /> <br /><br /> <br /> <br />
<<<<<<< HEAD
          
=======
    
               
>>>>>>> 457d7ebb9c268fd00dc3090caef5204d10de82eb
   </form>   
       
    
</asp:Content>
