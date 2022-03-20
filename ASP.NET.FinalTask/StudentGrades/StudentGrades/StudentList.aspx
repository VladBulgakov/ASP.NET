<%@ Page Title="" Language="C#" MasterPageFile="~/MainForm.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="StudentGrades.StudentList" UnobtrusiveValidationMode="None"%>

<asp:Content ID="ContentStudentList" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="GridViewStudents" runat="server"
        AutoGenerateColumns="False" ShowFooter="True" ShowHeaderWhenEmpty="True"
        DataKeyNames="StudentId"
        OnRowCommand="GridViewStudents_RowCommand"
        OnRowEditing="GridViewStudents_RowEditing"
        OnRowCancelingEdit="GridViewStudents_RowCancelingEdit"
        OnRowUpdating="GridViewStudents_RowUpdating"
        OnRowDeleting="GridViewStudents_RowDeleting"
        OnSorting="GridViewStudents_Sorting"
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
            <asp:TemplateField HeaderText="Фамилия" SortExpression="LastName" FooterStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("LastName")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxLastName" Text='<%# Eval("LastName")%>' style="width:95%" runat="server"/>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxLastName" ErrorMessage="Заполните поле фамилии!" ForeColor="Red">
                    Пожалуйста, заполните поле фамилии
                    </asp:RequiredFieldValidator>--%>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxLastNameFooter" style="width:95%" runat="server"/>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxLastNameFooter" ErrorMessage="Заполните поле фамилии!" ForeColor="Red">
                    Пожалуйста, заполните поле фамилии
                    </asp:RequiredFieldValidator>--%>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Имя" SortExpression="FirstName" FooterStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("FirstName")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxFirstName" Text='<%# Eval("FirstName")%>' style="width:95%" runat="server"/>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxFirstName" ErrorMessage="Заполните поле имени!" ForeColor="Red">
                    Пожалуйста, заполните поле имени
                    </asp:RequiredFieldValidator>--%>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxFirstNameFooter" style="width:95%" runat="server"/>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxFirstNameFooter" ErrorMessage="Заполните поле имени!" ForeColor="Red">
                    Пожалуйста, заполните поле имени
                    </asp:RequiredFieldValidator>--%>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Отчество" SortExpression="Patronymic" FooterStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Patronymic")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxPatronymic" Text='<%# Eval("Patronymic")%>' style="width:95%" runat="server"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxPatronymicFooter" style="width:95%" runat="server"/>
                    <%--<div>&nbsp</div>--%>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Дата рождения" SortExpression="BirthDate" FooterStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("BirthDate")%>' runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxBirthDate" Text='<%# Eval("BirthDate")%>' style="width:95%" runat="server"/>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxBirthDate" ErrorMessage="Заполните поле даты рождения!" ForeColor="Red">
                    Пожалуйста, заполните поле даты рождения
                    </asp:RequiredFieldValidator>--%>
                    <%--<asp:RangeValidator ID="StudentBirthDateValidator" runat="server" ControlToValidate="TextBoxBirthDate" Type="Date" ForeColor="Red" OnInit="StudentBirthDateValidator_Init">
                    Дата рождения должна быть позднее 01.01.1980
                    </asp:RangeValidator>--%>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxBirthDateFooter" style="width:95%" runat="server"/>
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxBirthDateFooter" ErrorMessage="Заполните поле даты рождения!" ForeColor="Red">
                    Пожалуйста, заполните поле даты рождения
                    </asp:RequiredFieldValidator>--%>
                    <%--<asp:RangeValidator ID="StudentBirthDateValidatorFooter" runat="server" ControlToValidate="TextBoxBirthDateFooter" Type="Date" ForeColor="Red" OnInit="StudentBirthDateValidator_Init">
                    Дата рождения должна быть позднее 01.01.1980
                    </asp:RangeValidator>--%>
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

<asp:Content ID="ContentStudentStatus" ContentPlaceHolderID="ContentPlaceHolderStatus" runat="server">
    <asp:Label ID="LabelStudentStatus" runat="server"></asp:Label>
</asp:Content>