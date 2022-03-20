<%@ Page Title="" Language="C#" MasterPageFile="~/MainForm.Master" AutoEventWireup="true" CodeBehind="GradeSummary.aspx.cs" Inherits="StudentGrades.GradeSummary" %>

<asp:Content ID="ContentInfoList" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <h1>Сводка оценок по предмету</h1>
    <asp:DropDownList ID="DropDownListCourseName" runat="server" DataTextField="CourseName" DataValueField="CourseId" style="width:400px" AutoPostBack="True">
    </asp:DropDownList>
    <asp:GridView ID="GridViewGradesSummary" runat="server"
        AutoGenerateColumns="False" ShowFooter="false" ShowHeaderWhenEmpty="True"
        DataKeyNames="StudentId"
        OnSorting="GridViewGradesSummary_Sorting"
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowSorting="true">
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
            <asp:TemplateField HeaderText="Имя ученика" SortExpression="StudentFullName">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("StudentFullName")%>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Сумма баллов по предмету" SortExpression="StudentGradeSumm">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("StudentGradeSumm")%>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Средний балл по предмету" SortExpression="StudentAverageGrade">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("StudentAverageGrade")%>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="ContentInfoStatus" ContentPlaceHolderID="ContentPlaceHolderStatus" runat="server">
    <asp:Label ID="LabelGradeSummaryStatus" runat="server"></asp:Label>
</asp:Content>