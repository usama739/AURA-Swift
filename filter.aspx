<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/AURA Swift.Master"
    CodeBehind="filter.aspx.cs"    Inherits="AURA_Swift.filter" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bigimage">
        <img src="images/GM.jpg" class="Grocery" />
    </div>
        
        <br />
       <form runat="server">
         <asp:Panel ID="Panel1" runat="server">
        <div class="userForm">
            <div class="formTitle">
                FILTER
            </div>
            <div class="formContent">
              
                <br />
                <asp:TextBox ID="txtkeyword" placeholder="Keyword" runat="server"></asp:TextBox>
                <br />
                <asp:DropDownList ID="ddlCatogryType"   runat="server" >
                     <asp:ListItem Enabled="true" Text="Type" Value="-1"></asp:ListItem>
                                    <asp:ListItem >Grocery</asp:ListItem>
                                     <asp:ListItem >Fruits</asp:ListItem>
                                    <asp:ListItem >Vegetables</asp:ListItem>
                                     <asp:ListItem >Junk Food</asp:ListItem>
                                    <asp:ListItem >Meat</asp:ListItem>
                                   
                                </asp:DropDownList>
           
                 <asp:DropDownList ID="ddlCity"  runat="server">
                                     <asp:ListItem Enabled="true" Text="City" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="All City" ></asp:ListItem>
                                     <asp:ListItem Text="Lahore" ></asp:ListItem>
                                    <asp:ListItem Text="Karachi" ></asp:ListItem>
                                     <asp:ListItem Text="Islamabad" ></asp:ListItem>
                                    <asp:ListItem Text="KHUSHAB" ></asp:ListItem>
                                </asp:DropDownList>




<asp:TextBox ID="txtSprice" placeholder="Starting Price" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtEprice" placeholder="Ending Price" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1"   runat="server" Text="Search" OnClick="filter_Click"/>
                <hr />
                 <br /> <br /> <br />
                
            </div>
        </div>
    </asp:Panel>
        <br />
        <br />
         <br /> <br /> <br /><br /> <br /> <br />
           
   </form>          
</asp:Content>