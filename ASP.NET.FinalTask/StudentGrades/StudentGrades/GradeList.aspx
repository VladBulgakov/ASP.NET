<%@ Page Title="" Language="C#" MasterPageFile="~/MainForm.Master" AutoEventWireup="true" CodeBehind="GradeList.aspx.cs" Inherits="StudentGrades.GradeList" %>

<asp:Content ID="ContentGradeList" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="GridViewGrades" runat="server"
        AutoGenerateColumns="False" ShowFooter="True" ShowHeaderWhenEmpty="True"
        DataKeyNames="StudentGradeId"
        OnRowCommand="GridViewGrades_RowCommand"
        OnRowEditing="GridViewGrades_RowEditing"
        OnRowCancelingEdit="GridViewGrades_RowCancelingEdit"
        OnRowUpdating="GridViewGrades_RowUpdating"
        OnRowDeleting="GridViewGrades_RowDeleting"
        OnSorting="GridViewGrades_Sorting"
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
            <asp:TemplateField HeaderText="Дата" SortExpression="GradeDate">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("GradeDate")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxGradeDate" Text='<%# Eval("GradeDate")%>' style="width:95%" runat="server"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxGradeDateFooter" style="width:95%" runat="server"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Имя ученика" SortExpression="StudentFullName">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("StudentFullName")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownListName" runat="server" DataTextField="StudentFullName" DataValueField="StudentId" style="width:95%">
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownListNameFooter" runat="server" DataTextField="StudentFullName" DataValueField="StudentId" style="width:95%">
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Название курса" SortExpression="CourseName">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("CourseName")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownListCourseName" runat="server" DataTextField="CourseName" DataValueField="CourseId" style="width:95%">
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownListCourseNameFooter" runat="server" DataTextField="CourseName" DataValueField="CourseId" style="width:95%">
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Оценка" SortExpression="Grade">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Grade")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownListGrade" runat="server" style="width:95%">
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownListGradeFooter" runat="server" style="width:95%">
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Комментарий" SortExpression="Comment">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Comment")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxComment" Text='<%# Eval("Comment")%>' style="width:95%" runat="server"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxCommentFooter" style="width:95%" runat="server"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton runat="server" ImageUrl="~/Images/edit.png" CommandName="Edit" ToolTip="Редактировать" Width="20px" Height="20px"/>
                    <asp:ImageButton runat="server" ImageUrl="~/Images/delete.png" CommandName="Delete" ToolTip="Удалить" Width="20px" Height="20px"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton runat="server" ImageUrl="~/Images/save.png" CommandName="Update" ToolTip="Сохранить изменения" Width="20px" Height="20px"/>
                    <asp:ImageButton runat="server" ImageUrl="~/Images/cancel.png" CommandName="Cancel" ToolTip="Отмена изменений" Width="20px" Height="20px"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton runat="server" ImageUrl="~/Images/addnew.png" CommandName="AddNew" ToolTip="Добавить" Width="20px" Height="20px"/>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="ContentGradeStatus" ContentPlaceHolderID="ContentPlaceHolderStatus" runat="server">
    <asp:Label ID="LabelGradeStatus" runat="server"></asp:Label>
</asp:Content>