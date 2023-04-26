<%@ Page Language="C#" MasterPageFile="~/AURA Swift.Master" 
    AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="AURA_Swift.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bigimage">
           <img src="images/GM.jpg" class="Grocery">
    </div>
        
        <br />
       <form runat="server">
         <asp:Panel ID="Panel1" runat="server" DefaultButton="btnPay">
                    <div class="userForm">
                        <div class="formTitle">
                            CHECKOUT
                        </div>
                        <div class="formContent">
                            <asp:RadioButton ID="rdoDebitCard" Text="Debit Card" GroupName="card" runat="server"
                                 AutoPostBack="True" />
                            <asp:RadioButton ID="rdoCredit" Text="Credit Card" GroupName="card" runat="server"
                                AutoPostBack="True"  />
                            <asp:TextBox ID="txtCardNumber" placeholder="Your card Number" runat="server"></asp:TextBox>
                             <br />
                            <asp:TextBox ID="txtCVV" placeholder="CVV Code" runat="server"></asp:TextBox>
                            <br />

                            <asp:TextBox ID="txtAmount" placeholder="Amount to pay" ReadOnly="true" Enabled="true" runat="server"></asp:TextBox>
                            <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Green"></asp:Label>
                            <asp:Button ID="btnPay" runat="server" Text="Pay"  OnClick="pay_Click"/>
                        </div>
                    </div>
                </asp:Panel>
        <br />
        <br />
         <br /> <br /> <br /><br /> <br /> <br />
   </form>     
         

   
</asp:content>
