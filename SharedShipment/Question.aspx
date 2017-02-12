<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="UMoveNew.SharedShipment.Question" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-md-12">
                    <br />
                    <br />
                </div>

            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-2">
                        <asp:Label ID="Label1" runat="server" Text="Question" meta:resourcekey="Label1Resource1"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtQuestion" TextMode="MultiLine" runat="server" meta:resourcekey="txtQuestionResource1"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-6">
                        <asp:Button runat="server" ID="btnAskQuestion" class="btn btn-info" Text="Ask Question" OnClick="btnAskQuestion_Click" meta:resourcekey="btnAskQuestionResource1" />

                    </div>
                </div>
            </div>
            <br />
            <br />
        </div>

    </form>
</body>
</html>
