<%@ Page Title="" Language="C#" MasterPageFile="~/MainForm.Master" AutoEventWireup="true" CodeBehind="BestWorstStudents.aspx.cs" Inherits="StudentGrades.BestWorstStudents" %>

<asp:Content ID="ContentBestWorst" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <h1>Лучшие ученики</h1>
    <asp:GridView ID="GridViewBestList" runat="server"
        AutoGenerateColumns="False" ShowFooter="false" ShowHeaderWhenEmpty="True"
        DataKeyNames="StudentId"
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowSorting="false">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="Blue" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
        <Columns>
            <asp:TemplateField HeaderText="ФИО ученика" SortExpression="StudentFullName">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("StudentFullName")%>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Средний балл по предметам" SortExpression="StudentAverageGrade">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("StudentAverageGrade")%>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h1>Худшие ученики</h1>
    <asp:GridView ID="GridViewWorstList" runat="server"
        AutoGenerateColumns="False" ShowFooter="false" ShowHeaderWhenEmpty="True"
        DataKeyNames="StudentId"
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowSorting="false">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="Blue" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
        <Columns>
            <asp:TemplateField HeaderText="ФИО ученика" SortExpression="StudentFullName">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("StudentFullName")%>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Средний балл по предметам" SortExpression="StudentAverageGrade">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("StudentAverageGrade")%>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="ContentBestWorstStatus" ContentPlaceHolderID="ContentPlaceHolderStatus" runat="server">
    <asp:Label ID="LabelBestWorstStatus" runat="server"></asp:Label>
</asp:Content>