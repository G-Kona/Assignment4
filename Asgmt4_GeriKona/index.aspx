<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Asgmt4_GeriKona.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Vendors</title>
    <link rel="stylesheet" href="Style/style.css" />
</head>
<body>
    <header>
        <div class="wrapper">
            <h1>VENDORS TABLE</h1>
        </div>
    </header>
    <main>
        <div class="wrapper">
            <form id="form1" runat="server">
                <!-- STATUS REPORT -->
                <aside id="statusBlock" runat="server">
                    <asp:Label ID="lbl_status" runat="server">- Status -</asp:Label>
                    <asp:Label ID="lbl_details" runat="server"></asp:Label>
                </aside>
                <!-- TEXT FIELDS -->
                <div id="center">
                    <div id="lbls">
                        <asp:Label ID="lbl_id" CssClass="lblForm" runat="server">Vendor ID: </asp:Label>
                        <asp:Label ID="lbl_name" CssClass="lblForm" runat="server">Name: </asp:Label>
                        <asp:Label ID="lbl_adrs1" CssClass="lblForm" runat="server">Address 1: </asp:Label>
                        <asp:Label ID="lbl_adrs2" CssClass="lblForm" runat="server">Address 2: </asp:Label>
                        <asp:Label ID="lbl_city" CssClass="lblForm" runat="server">City: </asp:Label>
                        <asp:Label ID="lbl_state" CssClass="lblForm" runat="server">State: </asp:Label>
                        <asp:Label ID="lbl_zip" CssClass="lblForm" runat="server">Zip Code: </asp:Label>
                    </div>

                    <div id="txts">
                        <asp:TextBox ID="txt_id" CssClass="txtForm" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txt_name" CssClass="txtForm" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txt_adrs1" CssClass="txtForm" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txt_adrs2" CssClass="txtForm" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txt_city" CssClass="txtForm" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txt_state" CssClass="txtForm" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txt_zip" CssClass="txtForm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <!-- BUTTONS -->
                <div id="buttons">
                    <asp:Button ID="btn_add_vendor" CssClass="btn" runat="server" Text="Add New!" OnClick="btn_add_vendor_Click" />
                    <asp:Button ID="btn_update_vendor" CssClass="btn" runat="server" Text="Update!" OnClick="btn_update_vendor_Click" />
                    <asp:Button ID="btn_delete_vendor" CssClass="btn" runat="server" Text="Delete!" OnClick="btn_delete_vendor_Click" />
                    <asp:Button ID="btn_clear" CssClass="btn" runat="server" Text="Clear!" OnClick="btn_clear_Click" />
                </div>
            </form>
            <!-- TABLE - SHOW RECORDS -->
            <h2>Vendors Table Data</h2>
            <asp:Table ID="tbl_vendors" runat="server" GridLines="Both">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Address 1</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Address 2</asp:TableHeaderCell>
                    <asp:TableHeaderCell>City</asp:TableHeaderCell>
                    <asp:TableHeaderCell>State</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Zip Code</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow></asp:TableRow>
            </asp:Table>
        </div>
    </main>
    <footer>
        <div class="wrapper">
            <div id="copyR">
                &copy; Copyright Geri Kona, 2017. All rights reserved.
            </div>
        </div>
    </footer>
</body>
</html>
