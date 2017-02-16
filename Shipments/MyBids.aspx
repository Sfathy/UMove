<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="MyBids.aspx.cs" Inherits="UMoveNew.Shipments.MyBids" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="counters">
        <div class="container">
            <div class="row">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Aqua" Width="100%" EnableTheming="True" AutoGenerateColumns="False" KeyFieldName="ID" CssClass="dxtiIndexPanelItem_Aqua" Cursor="pointer" EnableCallBacks="False" OnStartRowEditing="ASPxGridView1_StartRowEditing" meta:resourcekey="ASPxGridView1Resource1">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ID" Width="100%" VisibleIndex="0" Visible="false" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" Width="100%" Caption="Trip Name" VisibleIndex="1" ReadOnly="true" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Price" Width="100%" Caption="Price" VisibleIndex="2" UnboundType="Decimal" meta:resourcekey="GridViewDataTextColumnResource3">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RegularExpression ValidationExpression="[0-9]*\.?[0-9]*" ErrorText="Not valid" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TruckType" Width="100%" Caption="Truck Type" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="PickupDate" Width="100%" Caption="Pickup Date" VisibleIndex="4" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="DeliveryDate" Width="100%" Caption="Delivery Date" VisibleIndex="5" meta:resourcekey="GridViewDataDateColumnResource2"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="BidExpiration" Width="100%" Caption="Bid Expiration" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource3"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataCheckColumn FieldName="Accepted" Width="100%" Caption="Accepted" VisibleIndex="7" ReadOnly="true" meta:resourcekey="GridViewDataCheckColumnResource1">
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewCommandColumn ShowEditButton="True" ButtonType="Image" Caption="Edit" VisibleIndex="8" meta:resourcekey="GridViewCommandColumnResource1"></dx:GridViewCommandColumn>
                    </Columns>
                    <SettingsCommandButton>
                        <EditButton ButtonType="Image">
                            <Image IconID="edit_edit_16x16">
                            </Image>
                        </EditButton>
                          <UpdateButton>
                                <Image IconID="actions_apply_16x16">
                                </Image>
                            </UpdateButton>
                            <CancelButton>
                                <Image IconID="edit_delete_16x16">
                                </Image>
                            </CancelButton>
                    </SettingsCommandButton>
                    <Styles>
                        <Header Font-Bold="True" Font-Names="Berlin Sans FB Demi" Font-Overline="False" Font-Size="Larger" HorizontalAlign="Center">
                        </Header>
                        <Cell Font-Bold="True" Font-Names="Agency FB" Font-Size="Larger" HorizontalAlign="Center">
                        </Cell>
                    </Styles>
                    <BackgroundImage HorizontalPosition="center" VerticalPosition="center" />
                         <Settings HorizontalScrollBarMode="Auto"/>
                </dx:ASPxGridView>

                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT Trip.Name, Bid.Price, Bid.TruckType, Bid.PickupDate, Bid.DeliveryDate, Bid.BidExpiration, Bid.Accepted FROM Bid INNER JOIN Trip ON Bid.TripID = Trip.ID"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
