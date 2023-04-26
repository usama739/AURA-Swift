<%@ Page Language="C#"  MasterPageFile="~/AURA Swift.Master" 
    AutoEventWireup="true" CodeBehind="UpdateUnits.aspx.cs" Inherits="AURA_Swift.UpdateUnits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="bigimage">
             <img src="images/GM.jpg" class="Grocery">
        </div>
 <br /> 
    
      
        
        <asp:Panel ID="Panel1" runat="server">
            <div class="userForm">
                <div class="formTitle">
Update Units
                </div>
                <div class="formContent">
                    <asp:TextBox ID="txtMaxUits" Text="Max Units" runat="server" Enabled="false" ReadOnly="true" Width="70%"></asp:TextBox>
                    
                    <asp:TextBox ID="txtUits" placeholder="Enter Units" runat="server" Width="418px"></asp:TextBox>
                   
                    <div class="login_buttons">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="submit_click" />
                         </div>
                    <%--<br />--%>
                    
                    <asp:Label ID="lblError" Visible="False" Text="Enter less units than max Units available <br />" ForeColor="Red" runat="server"></asp:Label>


                   </div>
            </div>
        </asp:Panel>




    </form>

    <br />
</asp:Content>
