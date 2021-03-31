<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactInfoList.aspx.cs" Inherits="WebInformation.ContactInfoList" %>
<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1">
<style>
* {box-sizing: border-box;}

body { 
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

.header {
  overflow: hidden;
  background-color: #000000;
  padding: 20px 10px;
}

.modalPopup
           {
               background-color:blue;
               border-width: 3px;
               border-style: solid;
               border-color: black;
               padding-top: 10px;
               padding-left: 10px;
               width: 300px;
               height: 140px;
            }

.popup
{
margin: 20px;
 Margin-left: 30px;
    Margin-right: 30px;

}


#commentBox {
            width: 100%;
        }

.header a {
  float: left;
  color: white;
  text-align: center;
  padding: 12px;
  text-decoration: none;
  font-size: 8px; 
  line-height: 25px;
  border-radius: 4px;
}

.header a.logo {
  font-size: 25px;
  font-weight: bold;
}

.header a:hover {
  background-color: #ddd;
  color: black;
}

.header a.active {
  background-color: dodgerblue;
  color: white;
  
}

.header-right {
  float: right;
}


@media screen and (max-width: 768px) {
  .header a {
    float: none;
    display: block;
    text-align: left;
  }
  
  .header-right {
    float: none;
  }
}
</style>
</head>
<body>
<form id="form1" runat="server">

<div runat="server" class="header">
  <a href="#default" class="logo"> List Contact Person</a>
</div>
<div runat="server" style="padding-left:70px">
          
    <br />
    <asp:Button ID="Button1" runat="server" Text="Add Contact" OnClick="AddContact_Click" />
    <br />
    <br />

    

    <asp:GridView ID="GridViewContactList" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
        
        <Columns>
            <asp:BoundField  DataField="Nama" HeaderText="Nama"/>
            <asp:BoundField  DataField="Phone" HeaderText="Phone"/>
            <asp:BoundField  DataField="Email" HeaderText="Email"/>
            <asp:BoundField  DataField="Company" HeaderText="Company"/>
            <asp:BoundField  DataField="Country" HeaderText="Country"/>
            <asp:BoundField  DataField="Zip_code" HeaderText="Zip_code"/>
            <asp:BoundField  DataField="State" HeaderText="State"/>
            <asp:BoundField  DataField="City" HeaderText="City"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID ="LinkBtn" Text="Edit" CommandArgument= '<%#Eval("Nama")%>' OnClick="LinkBtn_Click">

                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    

    <br />
          
               
        
          
          

           
           
           
</div>

</form>

</body>
</html>
