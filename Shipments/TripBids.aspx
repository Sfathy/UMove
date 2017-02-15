<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="TripBids.aspx.cs" Inherits="UMoveNew.Shipments.TripBids" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.css" rel="stylesheet" />

       <link href="<%$ Resources:form.css %>" rel="stylesheet"  runat="server" />
   <script type="text/javascript">
       function ShowLoginWindow() {
           ASPxPopupControl1.Show();
       }
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <br />
                <div class="col-md-10"></div>
                <a href="#PlaceBid" id="button_requestQuote" class="btn btn-info">  <asp:Label runat="server" ID="Label18" Text="Place Bid" meta:resourcekey="Label18Resource1"></asp:Label> </a>
                <br />
            </div>

        </div>
        <br />
        <div class="row">
            <div class="form-style-10">
                <div class="section"><span>1</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" CssClass="asplab" ID="Label20" Text="Trip Information" meta:resourcekey="Label20Resource1"></asp:Label>
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
                <div class="section"><span>2</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label19" CssClass="asplab" runat="server" Text="Trip Items" meta:resourcekey="Label19Resource1"></asp:Label>
                <div class="inner-wrap">
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="PlasticBlue" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EnableTheming="True" KeyFieldName="ID" Width="100%" meta:resourcekey="ASPxGridView1Resource1">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" ReadOnly="True" VisibleIndex="0" Visible="false" meta:resourcekey="GridViewDataTextColumnResource1">
                                <EditFormSettings Visible="False"></EditFormSettings>
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataTextColumn FieldName="TripID" Caption="Trip  ID" VisibleIndex="1" Visible="false" meta:resourcekey="GridViewDataTextColumnResource2"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ItemDesc" Caption="Description" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource3"></dx:GridViewDataTextColumn>

                            <dx:GridViewDataImageColumn FieldName="ImageURL" Caption="Image" VisibleIndex="2" meta:resourcekey="GridViewDataImageColumnResource1"></dx:GridViewDataImageColumn>
                        </Columns>
                             <Settings HorizontalScrollBarMode="Auto"/>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT * FROM [TripItems] WHERE ([TripID] = @TripID)">
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="id" Name="TripID" Type="Int32"></asp:QueryStringParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>

                <div class="section">
                    <span>3</span> </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" CssClass="asplab" ID="Label21" Text="Questions for this Shipment" meta:resourcekey="Label21Resource1"></asp:Label>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
                    <asp:Button runat="server" ID="btnAskQuestion" class="btn btn-info" Text="Ask Question" OnClientClick="ShowLoginWindow();" meta:resourcekey="btnAskQuestionResource1" />
                

                <div class="inner-wrap">


                    <dx:ASPxGridView ID="ASPxGridView3" ClientInstanceName="ASPxGridView3" runat="server" Theme="PlasticBlue" Width="100%" KeyFieldName="QuestionID" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" EnableTheming="True" meta:resourcekey="ASPxGridView3Resource1" EnableCallBacks="False" >
                        <Columns>
                              <dx:GridViewDataTextColumn FieldName="QuestionID" Caption="ID" VisibleIndex="1" Visible="false" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Question" Caption="Question" VisibleIndex="2" meta:resourcekey="GridViewDataTextColumnResource4"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="QuestionUser" Caption="By" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Answer" Caption="Answer" VisibleIndex="5" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="AnswerUser" Visible="false" VisibleIndex="7" meta:resourcekey="GridViewDataTextColumnResource7"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="QuestionTime" Caption="Question Time" VisibleIndex="3" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="AnswerTime" Caption="Answer Time" VisibleIndex="6" meta:resourcekey="GridViewDataDateColumnResource2"></dx:GridViewDataDateColumn>
                        </Columns>
                             <Settings HorizontalScrollBarMode="Auto"/>
                           <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" />
                    </dx:ASPxGridView>
                       <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
         ContentUrl="Question.aspx" Width="300px" Height="400px"
       
        HeaderText="Ask Question" ClientInstanceName="ASPxPopupControl1" >
    </dx:ASPxPopupControl>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT     dbo.TripQuestions.Question, dbo.Users.Name AS QuestionUser, dbo.TripQuestions.Answer, Users_1.Name AS AnswerUser, dbo.TripQuestions.QuestionTime, dbo.TripQuestions.AnswerTime FROM dbo.TripQuestions LEFT OUTER JOIN dbo.Users AS Users_1 ON dbo.TripQuestions.AnswerUserID = Users_1.ID LEFT OUTER JOIN dbo.Users ON dbo.TripQuestions.QuestionUserID = dbo.Users.ID Where TripID=@ID and QuestionPuplished=1">
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="id" Name="ID"></asp:QueryStringParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="section"><span>4</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" CssClass="asplab" ID="Label22" Text="Bids" meta:resourcekey="Label22Resource1"></asp:Label>

                <div class="inner-wrap">
                    <div class="panel-body">
                        <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Theme="PlasticBlue" Width="100%" meta:resourcekey="ASPxGridView2Resource1">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="Price" Caption="Price" VisibleIndex="0" meta:resourcekey="GridViewDataTextColumnResource8"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource9"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="BidExpiration" Caption="Bid Expiration" VisibleIndex="2" meta:resourcekey="GridViewDataDateColumnResource3"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="Note" Caption="Note" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource10"></dx:GridViewDataTextColumn>
                            </Columns>
                                 <Settings HorizontalScrollBarMode="Auto"/>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT Bid.Price, Users.Name, Bid.BidExpiration, Bid.Note FROM Bid INNER JOIN Users ON Bid.UserID = Users.ID WHERE (Bid.TripID = @ID) and Puplished=1">
                            <SelectParameters>
                                <asp:QueryStringParameter QueryStringField="id" Name="ID"></asp:QueryStringParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>

                <div class="section"><span>4</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" CssClass="asplab" ID="Label23" Text=" Place Bid" meta:resourcekey="Label23Resource1"></asp:Label>
                <div id="PlaceBid">
                    <div class="inner-wrap">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <asp:Label ID="Label10" runat="server" Text="Price" meta:resourcekey="Label10Resource1"></asp:Label>
                                </div>

                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPrice" runat="server" Width="100%" placeholder="Price" TextMode="Number" meta:resourcekey="txtPriceResource1"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label11" runat="server" Text="Truck Type" meta:resourcekey="Label11Resource1"></asp:Label>
                                    </div>
                                    <div class="col-md-8">

                                        <dx:ASPxComboBox ID="ddlTruckType" runat="server" Width="100%" ValueType="System.Int32" DataSourceID="SqlDataSource2" ValueField="ID" TextField="TruckType" meta:resourcekey="ddlTruckTypeResource1"></dx:ASPxComboBox>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [TruckType] FROM [TruckType]"></asp:SqlDataSource>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <asp:Label ID="Label12" runat="server" Text="Pickup Date" meta:resourcekey="Label12Resource1"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPickupDate" Width="100%" runat="server" TextMode="DateTime" meta:resourcekey="txtPickupDateResource1"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPickupDate" BehaviorID="CalendarExtender1" />
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label13" runat="server" Text="Deliver Date" meta:resourcekey="Label13Resource1"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtDeliverDate" Width="100%" runat="server" TextMode="DateTime" meta:resourcekey="txtDeliverDateResource1"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDeliverDate" BehaviorID="CalendarExtender2" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <asp:Label ID="Label14" runat="server" Text="Bid Expiration" meta:resourcekey="Label14Resource1"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:RadioButtonList ID="rblBidExpiration" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblBidExpiration_SelectedIndexChanged" meta:resourcekey="rblBidExpirationResource1">
                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource1">Standard: 24 hours after auction has ended</asp:ListItem>
                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource2">Custom: Before auction ends</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <asp:Label ID="lblExpiration" runat="server" Text="will expire on" Visible="False" meta:resourcekey="lblExpirationResource1"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBidExpiration" Width="100%" runat="server" TextMode="DateTime" Visible="False" meta:resourcekey="txtBidExpirationResource1"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtBidExpiration" BehaviorID="CalendarExtender3" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label15" runat="server" Text="Note" meta:resourcekey="Label15Resource1"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtnote" TextMode="MultiLine" Width="100%" runat="server" meta:resourcekey="txtnoteResource1"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label16" runat="server" Text="Term Condition" meta:resourcekey="Label16Resource1"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTermCondition" TextMode="MultiLine" Width="100%" runat="server" meta:resourcekey="txtTermConditionResource1"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4"></div>
                                <asp:Button ID="btnSave" runat="server" class="btn btn-info" Text="Place Bid" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
