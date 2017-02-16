<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="MyCars.aspx.cs" Inherits="UMoveNew.Shipments.MyCars" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="counters">
        <div class="container">
              <div class="row">
            <dx:ASPxButton ID="btnAddCar" runat="server" Text="Add   Car" Theme="iOS" OnClick="btnAddCar_Click" meta:resourcekey="btnAddCarResource1"></dx:ASPxButton>
                  </div>
          <br />
              <div class="row">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Aqua" AutoGenerateColumns="False" Width="100%"  EnableTheming="True" KeyFieldName="ID" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" meta:resourcekey="ASPxGridView1Resource1">
                    <Columns>
                         <dx:GridViewDataTextColumn FieldName="ID" Caption="" Width="100%" VisibleIndex="0" Visible="false" meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CarType" Caption="Car Type" Width="100%" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CarModel" Caption="Car Model" Width="100%" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CarYear" Caption="Car Year" Width="100%" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CarCondition" Caption="Car Condition" Width="100%" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NumOFSeats" Caption="Number OF Seats" Width="100%" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="MaxWidth" Caption="Max Width" VisibleIndex="5" Width="100%" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="hight" Caption="hight" VisibleIndex="6" Width="100%" meta:resourcekey="GridViewDataTextColumnResource8"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="Active" Caption="Active" VisibleIndex="7" Width="100%" meta:resourcekey="GridViewDataCheckColumnResource1"></dx:GridViewDataCheckColumn>

                        <dx:GridViewCommandColumn ButtonType="Image" Caption="Inactive" Width="100%" VisibleIndex="8" meta:resourcekey="GridViewCommandColumnResource1">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="BtnActive" Text="Inactive" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                                    <Image IconID="actions_cancel_16x16">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>

                    </Columns>
                      <Styles>
                        <Header Font-Bold="True" Font-Names="Berlin Sans FB Demi" Font-Overline="False" Font-Size="Larger" HorizontalAlign="Center">
                        </Header>
                        <Cell Font-Bold="True" Font-Names="Agency FB" Font-Size="Larger" HorizontalAlign="Center">
                        </Cell>
                    </Styles>
                         <Settings HorizontalScrollBarMode="Auto"/>
                </dx:ASPxGridView>
              
            </div>
            </div>
          </div>
</asp:Content>
