<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="RSVP.Reg" MasterPageFile="~/Site.Master" UnobtrusiveValidationMode="None"%>

<asp:Content ID="RegContent" ContentPlaceHolderID="ContentPlaceHolderMainRight" runat="server"> 
    <div>
        <h1>Приглашаем на семинар!</h1> 
        <p></p>
    </div>
    <asp:ValidationSummary ID="ValidationSummaryReg" runat="server" ShowModelStateErrors="true" />
    <div> 
        <label>Ваше имя:</label>
        <asp:TextBox ID="name" runat="server"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="name" ErrorMessage="Заполните поле имени" ForeColor="Red">Не оставляйте поле пустым</asp:RequiredFieldValidator>
    </div>
    <div> 
        <label>Ваш email:</label>
        <asp:TextBox ID="email" runat="server"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMail" runat="server" ErrorMessage="Введите e-mail" ForeColor="Red" ControlToValidate="email">Не оставляйте поле пустым</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorMail" runat="server" ErrorMessage="Введите e-mail правильно" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email"></asp:RegularExpressionValidator>
    </div> 
    <div> 
        <label>Ваш телефон:</label>
        <asp:TextBox ID="phone" runat="server"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" runat="server" ControlToValidate="phone" ErrorMessage="Введите номер телефона" ForeColor="Red">Не оставляйте поле пустым</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhoneNumber" runat="server" ErrorMessage="Введите номер телефона правильно. Например +71234567890" Display="Dynamic" ForeColor="Red" ValidationExpression="[+][7]\d\d\d\d\d\d\d\d\d\d" ControlToValidate="phone"></asp:RegularExpressionValidator>
    </div> 
    <div> 
        <label>Вы будете делать доклад?</label> 
        <asp:CheckBox ID="CheckBoxYN" runat="server" /> 
    </div>
    <div>
        <button type="submit">Отправить ответ на приглашение RSVP</button>
    </div>
</asp:Content>