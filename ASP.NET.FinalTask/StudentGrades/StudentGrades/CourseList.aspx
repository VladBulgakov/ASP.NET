<%@ Page Title="" Language="C#" MasterPageFile="~/MainForm.Master" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="StudentGrades.CourseList" UnobtrusiveValidationMode="None"%>

<asp:Content ID="ContentCourseList" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="GridViewCourses" runat="server"
        AutoGenerateColumns="False" ShowFooter="True" ShowHeaderWhenEmpty="True"
        DataKeyNames="CourseId"
        OnRowCommand="GridViewCourses_RowCommand"
        OnRowEditing="GridViewCourses_RowEditing"
        OnRowCancelingEdit="GridViewCourses_RowCancelingEdit"
        OnRowUpdating="GridViewCourses_RowUpdating"
        OnRowDeleting="GridViewCourses_RowDeleting"
        OnSorting="GridViewCourses_Sorting"
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
            <asp:TemplateField HeaderText="Название курса" SortExpression="CourseName">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("CourseName")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCourseName" Text='<%# Eval("CourseName")%>' style="width:95%" runat="server"/>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCourseName" ErrorMessage="Заполните поле названия курса!" ForeColor="Red">
                    Пожалуйста, заполните поле названия курса
                    </asp:RequiredFieldValidator>--%>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxCourseNameFooter" style="width:95%" runat="server"/>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCourseNameFooter" ErrorMessage="Заполните поле названия курса!" ForeColor="Red">
                    Пожалуйста, заполните поле названия курса
                    </asp:RequiredFieldValidator>--%>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Описание курса" SortExpression="CourseDescription" FooterStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("CourseDescription")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCourseDescription" Text='<%# Eval("CourseDescription")%>' style="width:95%" runat="server"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxCourseDescriptionFooter" style="width:95%" runat="server"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Длительность курса, ч" SortExpression="CourseTime" FooterStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("CourseTime")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCourseTime" Text='<%# Eval("CourseTime")%>' style="width:95%" runat="server"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxCourseTimeFooter" style="width:95%" runat="server"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField FooterStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
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

<asp:Content ID="ContentCourseStatus" ContentPlaceHolderID="ContentPlaceHolderStatus" runat="server">
    <asp:Label ID="LabelCourseStatus" runat="server"></asp:Label>
</asp:Content>