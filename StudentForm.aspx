<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="StudentDatabase.StudentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 67px; width: 790px">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableHeaderCell>Student Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Start Date</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Program</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Transfer Credits</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox ID="tbStudentName" runat="server"></asp:TextBox>
                    </asp:TableCell>

                    <asp:TableCell>
                        <asp:TextBox ID="tbStartDate" runat="server"></asp:TextBox>
                    </asp:TableCell>

                    <asp:TableCell>
                        <asp:TextBox ID="tbProgram" runat="server"></asp:TextBox>
                    </asp:TableCell>

                    <asp:TableCell>
                        <asp:TextBox ID="tbTransferCredits" runat="server"></asp:TextBox>
                    </asp:TableCell>

                    <asp:TableCell>
                        <asp:Button ID="btnAdd" runat="server" OnClick="Button1_Click" Text="Add" />
                    </asp:TableCell>

                    <asp:TableCell>
                        
                    </asp:TableCell>

                </asp:TableRow>
            </asp:Table>
            <asp:Label ID="lblConfirmation" runat="server" Text=" "></asp:Label>
        </div><br /><br />
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" PageSize="20">
                <Columns>
                    <asp:BoundField ItemStyle-Width="150px" DataField="StudentName" HeaderText="Student Name" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="StartDate" HeaderText="Start Date" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="Program" HeaderText="Program" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="TransferCredits" HeaderText="Transfer Credits" />
                </Columns>
            </asp:GridView><br />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /><br /><br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:TextBox ID="tbUpdate" runat="server" placeholder="Enter Name to Update" ></asp:TextBox>
        </div>

    </form>
</body>
</html>
