<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="RSVP.Summary" MasterPageFile="~/Site.Master" %>

<asp:Content ID="SummaryContent" ContentPlaceHolderID="ContentPlaceHolderMainRight" runat="server">
    <div>
        <h2>Приглашения</h2>
        <h3>Выступающие с докладом: </h3>
        <table>
            <thead>
                <tr>
                    <th>Имя</th>
                    <th>Email</th>
                    <th>Телефон</th>
                </tr>
            </thead>
            <tbody>
               <%= GetShowHtml()%>
            </tbody>
        </table>
        <h3>Участники без доклада: </h3>
        <table>
            <thead>
                <tr>
                    <th>Имя</th>
                    <th>Email</th>
                    <th>Телефон</th>
                </tr>
                <tb>
                    <%= GetNoShowHtml()%>
                </tb>
            </thead>
        </table>
    </div>
</asp:Content>