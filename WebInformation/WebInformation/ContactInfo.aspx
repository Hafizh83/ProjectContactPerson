<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactInfo.aspx.cs" Inherits="WebInformation.Views.Home.Default" %>

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
  font-size: 18px; 
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
  <a href="#default" class="logo">Contact Info</a>

</div>

<div runat="server" style="padding-left:70px">
          
            <br />
            <br />
            <asp:Label ID="LblNama" runat="server" Text="Nama" Width="220px"></asp:Label>
            <asp:TextBox ID="TbNama" runat="server"  Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblPhone" runat="server" Text="Phone no" Width="220px"></asp:Label>
            <asp:TextBox ID="TbPhone" runat="server"  Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblEmail" runat="server" Text="Email" Width="220px"></asp:Label>
            <asp:TextBox ID="TbEmail" runat="server"  Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblCompany" runat="server" Text="Company" Width="220px"></asp:Label>
            <asp:TextBox ID="TbCompany" runat="server"  Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblCountry" runat="server" Text="Country" Width="220px"></asp:Label>
            <asp:TextBox ID="TbCountry" runat="server"  Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblZip" runat="server" Text="Zip Code" Width="220px"></asp:Label>
            <asp:TextBox ID="TbZip" runat="server"  Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblState" runat="server" Text="State" Width="220px"></asp:Label>
            <asp:TextBox ID="TbState" runat="server"  Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LblCity" runat="server" Text="City" Width="220px"></asp:Label>
            <asp:TextBox ID="TbCity" runat="server"  Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LbUpload" runat="server" Text="Upload Foto" Width="220px"></asp:Label>
            <asp:FileUpload id="FileUploadControl" runat="server" />
            <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
            <br /><br />
            <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
         
         
            <br />
            <br />
           
            <br />
           <%-- <asp:Button ID="Button1" runat="server" Text="Button" />
            <asp:Button ID="Button2" runat="server" Text="Button" />--%>
            <div class="popup">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel"  OnClick="btnCancel_Click" />
            </div>
            <br />
           
           
</div>

</form>

</body>
</html>