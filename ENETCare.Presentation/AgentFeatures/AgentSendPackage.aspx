<%@ Page Title="" Language="C#" MasterPageFile="~/AgentFeatures/AgentFeatures.master" AutoEventWireup="true" 
    CodeBehind="AgentSendPackage.aspx.cs" Inherits="ENETCare.Presentation.AgentFeatures.AgentSendPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Send Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <div class="form-horizontal col-sm-10 col-sm-offset-1" runat="server">

                <div class="form-group col-xs-12">
                    <asp:Label ID="AgentSendPackageDestination" runat="server" Text="Destination: "></asp:Label>

                    <asp:DropDownList ID="AgentSendingDropDownList" runat="server" OnSelectedIndexChanged="AgentSendingDropDownList_SelectedIndexChanged">
                        <asp:ListItem>Please Select</asp:ListItem>
                    </asp:DropDownList>
                    Barcode:
                        <asp:TextBox ID="AgentSendPackageTypebarcode" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="AgentSendPackageTypeTextBox" runat="server" Text="Package Type: " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentSendPackageTypeTextBox" CssClass="form-control" runat="server" ReadOnly="true" TextMode="SingleLine"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="AgentSendPackageExpirationDateTextBox" runat="server" Text="Expiration Date: " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentSendPackageExpirationDateTextBox" CssClass="form-control" runat="server" ReadOnly="true" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="AgentSendPackagePriceTextBox" runat="server" Text="Price (AUD): " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentSendPackagePriceTextBox" CssClass="form-control" runat="server" ReadOnly="true" TextMode="Number"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="AgentSendPackageDateTextBox" runat="server" Text="Send Date: " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentSendPackageDateTextBox" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentHome.aspx">Cancel</a>
                <asp:Button ID="AgentSendPackageTypeButton" runat="server" OnClick="AgentSendPackageTypeButton_Click"
                    Text="Agent Send" CssClass="btn btn-success btn-float-right" />

            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
