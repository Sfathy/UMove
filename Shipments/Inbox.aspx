<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="UMoveNew.Shipments.Inbox" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <br />
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Aqua" Width="100%" AutoGenerateColumns="False" EnableTheming="True" EnableCallBacks="False" KeyFieldName="ID" OnRowDeleted="ASPxGridView1_RowDeleted" meta:resourcekey="ASPxGridView1Resource1">
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" Width="100%" VisibleIndex="6" ButtonType="Image" Caption="Delete" meta:resourcekey="GridViewCommandColumnResource1"></dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Message" VisibleIndex="0" Width="100%" Caption="Message" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ToUser" VisibleIndex="1" Width="100%" Visible="false" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Sender" VisibleIndex="2" Width="100%" Caption="From" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="MessageDate" VisibleIndex="3" Width="100%" Caption="Date" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="trip_name" VisibleIndex="4" Width="100%" Caption="Trip Name" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Message_AR" VisibleIndex="5" Width="100%" Caption="Message" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsCommandButton>

                        <DeleteButton ButtonType="Image">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </DeleteButton>
                    </SettingsCommandButton>
                     <Styles>
                        <Header Font-Bold="True" Font-Names="Berlin Sans FB Demi" Font-Overline="False" Font-Size="Larger" HorizontalAlign="Center">
                        </Header>
                        <Cell Font-Bold="True" Font-Names="Agency FB" Font-Size="Larger" HorizontalAlign="Center">
                        </Cell>
                    </Styles>
                         <Settings HorizontalScrollBarMode="Auto"/>
                </dx:ASPxGridView>
                <br />
            </div>
        </div>
    </div>

</asp:Content>
