<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Admin.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="UMoveNew.Administrator.Questions" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="counters">
        <div class="container">
            <div class="row">
    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server" Theme="PlasticBlue" Width="100%" KeyFieldName="QuestionID" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" EnableTheming="True" EnableCallBacks="False" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" meta:resourcekey="ASPxGridView1Resource1">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="QuestionID" Caption="ID" VisibleIndex="0" Visible="false"  meta:resourcekey="GridViewDataTextColumnResource1"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="Name" Caption="Trip Name" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource2" ></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Question" Caption="Question" VisibleIndex="1" meta:resourcekey="GridViewDataTextColumnResource3" ></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="QuestionUser" Caption="By" VisibleIndex="3" meta:resourcekey="GridViewDataTextColumnResource4" ></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Answer" Caption="Answer" VisibleIndex="4" meta:resourcekey="GridViewDataTextColumnResource5"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AnswerUser" Visible="false" VisibleIndex="6" meta:resourcekey="GridViewDataTextColumnResource6"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="QuestionTime" Caption="Question Time" VisibleIndex="2" meta:resourcekey="GridViewDataDateColumnResource1"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="AnswerTime" Caption="Answer Time" VisibleIndex="5" meta:resourcekey="GridViewDataDateColumnResource2"></dx:GridViewDataDateColumn>
              <dx:GridViewDataComboBoxColumn FieldName="QuestionPuplished" SortIndex="0" SortOrder="Ascending" UnboundType="String" VisibleIndex="6" Caption="Status"  meta:resourcekey="GridViewDataComboBoxColumnResource1">
                       <PropertiesComboBox DataSourceID="SqlDataSource1" DropDownStyle="DropDown" TextField="Name" ValueField="ID">
                       </PropertiesComboBox>
                       </dx:GridViewDataComboBoxColumn>
            <dx:GridViewCommandColumn ButtonType="Image" Caption="Accept" VisibleIndex="7" meta:resourcekey="GridViewCommandColumnResource1" ShowClearFilterButton="True">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="btnAccept" meta:resourcekey="GridViewCommandColumnCustomButtonResource1">
                        <Image IconID="actions_apply_16x16">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                      <dx:GridViewCommandColumnCustomButton ID="btnIgnore">
                            <Image IconID="actions_close_16x16">
                            </Image>
                        </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
        </Columns>

        <Settings ShowFilterRow="True" />

    </dx:ASPxGridView>
    <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT dbo.TripQuestions.QuestionID,dbo.TripQuestions.Question, dbo.Users.Name AS QuestionUser, dbo.TripQuestions.Answer, Users_1.Name AS AnswerUser, dbo.TripQuestions.QuestionTime, dbo.TripQuestions.AnswerTime,dbo.TripQuestions.QuestionPuplished, dbo.TripQuestions.AnswerPuplished, dbo.Trip.Name FROM dbo.TripQuestions INNER JOIN dbo.Trip ON dbo.TripQuestions.TripID = dbo.Trip.ID LEFT OUTER JOIN dbo.Users AS Users_1 ON dbo.TripQuestions.AnswerUserID = Users_1.ID LEFT OUTER JOIN dbo.Users ON dbo.TripQuestions.QuestionUserID = dbo.Users.ID Where QuestionPuplished<>1 order by QuestionPuplished"></asp:SqlDataSource>
           <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [Name] FROM [ItemStatus]"></asp:SqlDataSource>         
                        </div>
            </div>
          </div>
</asp:Content>
