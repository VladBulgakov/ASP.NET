<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SummaryDB.aspx.cs" Inherits="RSVP.SummaryDB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMainRight" runat="server">
    <h2>Список выступающих</h2>
    <asp:GridView ID="GridViewGuests" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSourceGuests">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Имя" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Email" HeaderText="Адрес e-mail" ReadOnly="True" SortExpression="Email" />
            <asp:BoundField DataField="Phone" HeaderText="Номер телефона" ReadOnly="True" SortExpression="Phone" />
            <asp:CheckBoxField DataField="WillAttend" HeaderText="Подготовил выступление" ReadOnly="True" SortExpression="WillAttend" />
            <asp:BoundField DataField="Rdata" HeaderText="Дата регистрации" ReadOnly="True" SortExpression="Rdata" />
        </Columns>
</asp:GridView>
    <asp:LinqDataSource ID="LinqDataSourceGuests" runat="server" ContextTypeName="RSVP.RsvpContext" EntityTypeName="" Select="new (Name, Email, Phone, WillAttend, Rdata, Reports)" TableName="GuestResponses"></asp:LinqDataSource>
</asp:Content>