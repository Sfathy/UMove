﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="MySharedTripBids.aspx.cs" Inherits="UMoveNew.SharedShipment.MySharedTripBids" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.css" rel="stylesheet" />

    <link href="<%$ Resources:form.css %>" rel="stylesheet" type="text/css" runat="server" />
    <script type="text/javascript">
        function OnEmailClick(visibleIndex) {
            //alert('hi');
            popup.Show();
            cpPopup.PerformCallback(visibleIndex);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <br />
                <div class="col-md-10"></div>

                <br />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="form-style-10">
                <div class="section"><span>1</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" CssClass="asplab" ID="Label10" Text="Trip Information" meta:resourcekey="Label10Resource1"></asp:Label>
                <div class="inner-wrap">
                    <label>
                        <asp:Label ID="Label1" runat="server" Text="Shipment Title: " meta:resourcekey="Label1Resource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblTitle" meta:resourcekey="lblTitleResource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Shipment ID:" meta:resourcekey="Label2Resource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblID" meta:resourcekey="lblIDResource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="Customer:" meta:resourcekey="Label3Resource1"></asp:Label>
                        <asp:Label runat="server" ID="lblCustomer" meta:resourcekey="lblCustomerResource1"></asp:Label>
                    </label>
                    <hr />
                    <label>
                        <asp:Label ID="Label4" runat="server" Text="PicUp Date:" meta:resourcekey="Label4Resource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblPicUpDate" meta:resourcekey="lblPicUpDateResource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="Delivery Date :" meta:resourcekey="Label5Resource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblDeliveryDate" meta:resourcekey="lblDeliveryDateResource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                    </label>
                    <hr />
                    <label>
                        <asp:Label ID="Label6" runat="server" Text=" Budget:" meta:resourcekey="Label6Resource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblBudget" meta:resourcekey="lblBudgetResource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label7" runat="server" Text=" Low Bid:" meta:resourcekey="Label7Resource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lbllowbid" meta:resourcekey="lbllowbidResource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label8" runat="server" Text="  # of Bids:" meta:resourcekey="Label8Resource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblnumbid" meta:resourcekey="lblnumbidResource1"></asp:Label>
                    </label>
                    <hr />
                    <label>
                        <asp:Label ID="Label9" runat="server" Text="Origin :" meta:resourcekey="Label9Resource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblOrigin" meta:resourcekey="lblOriginResource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label17" runat="server" Text=" Destination:" meta:resourcekey="Label17Resource1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" ID="lblDestination" meta:resourcekey="lblDestinationResource1"></asp:Label>
                    </label>
                </div>


                <div class="section">
                    <span>2</span>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="Label12" CssClass="asplab" Text="Questions for this Shipment" meta:resourcekey="Label12Resource1"></asp:Label>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
                <div class="inner-wrap">
                    <dx:ASPxGridView ID="ASPxGridView3" runat="server" Theme="PlasticBlue" Width="100%" KeyFieldName="QuestionID" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" EnableTheming="True" OnCustomButtonInitialize="ASPxGridView3_CustomButtonInitialize" meta:resourcekey="ASPxGridView3Resource1" OnRowUpdating="ASPxGridView3_RowUpdating">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="QuestionID" Width="100%" Caption="ID" VisibleIndex="0" Visible="false" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Question" Width="100%" Caption="Question" ReadOnly="true" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource5">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="QuestionUser" Width="100%" Caption="by" ReadOnly="true" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource6">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Answer" Caption="Answer" Width="100%" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="AnswerUser" VisibleIndex="6" Width="100%" ReadOnly="true" Visible="false" meta:resourcekey="GridViewDataTextColumnResource8">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="QuestionTime" Caption="Question Time" Width="100%" VisibleIndex="2" meta:resourcekey="GridViewDataDateColumnResource1">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="AnswerTime" ReadOnly="true" Caption="Answer Time" Width="100%" VisibleIndex="5" meta:resourcekey="GridViewDataDateColumnResource2">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewCommandColumn ButtonType="Button" Name="Answer" Caption="Answer" VisibleIndex="7" Width="100%" meta:resourcekey="GridViewCommandColumnResource1" ShowEditButton="True">
                                <EditButton Text="<%$ Resources:GridViewDataTextColumnResource7.Caption %>"></EditButton>
                            </dx:GridViewCommandColumn>
                        </Columns>
                        <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" />
                    </dx:ASPxGridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT     dbo.SharedTripQuestions.Question, dbo.Users.Name AS QuestionUser, dbo.SharedTripQuestions.Answer, Users_1.Name AS AnswerUser, dbo.SharedTripQuestions.QuestionTime, dbo.SharedTripQuestions.AnswerTime, dbo.SharedTripQuestions.QuestionID FROM dbo.SharedTripQuestions LEFT OUTER JOIN dbo.Users AS Users_1 ON dbo.SharedTripQuestions.AnswerUserID = Users_1.ID LEFT OUTER JOIN dbo.Users ON dbo.SharedTripQuestions.QuestionUserID = dbo.Users.ID WHERE     (dbo.SharedTripQuestions.TripID = @ID) AND (dbo.SharedTripQuestions.QuestionPuplished = 1)">
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="id" Name="ID"></asp:QueryStringParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="section"><span>4</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" CssClass="asplab" ID="Label13" Text="Bids" meta:resourcekey="Label13Resource1"></asp:Label>
                <div class="inner-wrap">
                    <div class="panel-body">
                        <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" DataSourceID="SqlDataSource3" Theme="PlasticBlue" Width="100%" OnCustomButtonCallback="ASPxGridView2_CustomButtonCallback" OnCustomButtonInitialize="ASPxGridView2_CustomButtonInitialize" meta:resourcekey="ASPxGridView2Resource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" Width="100%" VisibleIndex="0" Visible="false" meta:resourcekey="GridViewDataTextColumnResource9"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Price" Caption="Price" Width="100%" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource10"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" Width="100%" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource11"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="BidExpiration" Width="100%" Caption="Bid Expiration" VisibleIndex="3" meta:resourcekey="GridViewDataDateColumnResource3"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Note" Caption="Note" Width="100%" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource12"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="Accepted" Caption="Accepted" Width="100%" VisibleIndex="5" meta:resourcekey="GridViewDataCheckColumnResource1">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewCommandColumn ButtonType="Button" Caption="Accept" Width="100%" VisibleIndex="6" meta:resourcekey="GridViewCommandColumnResource2">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="BtnAccept" Text="Accept" meta:resourcekey="GridViewCommandColumnCustomButtonResource2">
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="btnCancel" Text="Cancel" meta:resourcekey="GridViewCommandColumnCustomButtonResource3">
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT     dbo.SharedTripsBid.Price, dbo.Users.Name, dbo.SharedTripsBid.BidExpiration, dbo.SharedTripsBid.Note, dbo.SharedTripsBid.Accepted, dbo.SharedTripsBid.ID FROM dbo.SharedTripsBid INNER JOIN dbo.Users ON dbo.SharedTripsBid.UserID = dbo.Users.ID WHERE     (dbo.SharedTripsBid.SharedTripID = @ID) AND (dbo.SharedTripsBid.Puplished = 1)">
                            <SelectParameters>
                                <asp:QueryStringParameter QueryStringField="id" Name="ID"></asp:QueryStringParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>