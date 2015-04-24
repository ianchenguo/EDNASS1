<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true" 
    CodeBehind="AgentDoctorSendPackage.aspx.cs" Inherits="ENETCare.Presentation.AgentDoctorFeatures.AgentDoctorSendPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentDoctorFeatureMainContent" runat="server">
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
                    <asp:Label ID="AgentDoctorSendPackageDestination" runat="server" Text="Destination: "></asp:Label>

                    <asp:DropDownList ID="AgentDoctorSendingDropDownList" runat="server">
                        <asp:ListItem>Please Select</asp:ListItem>
                    </asp:DropDownList>
                    Barcode:
                        <asp:TextBox ID="AgentDoctorSendPackageTypebarcode" runat="server"></asp:TextBox>
                </div>

                <%--<div class="form-group">
                    <asp:Label AssociatedControlID="AgentDoctorSendPackageTypeTextBox" runat="server" Text="Package Type: " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentDoctorSendPackageTypeTextBox" CssClass="form-control" runat="server" ReadOnly="true" TextMode="SingleLine"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="AgentDoctorSendPackageExpirationDateTextBox" runat="server" Text="Expiration Date: " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentDoctorSendPackageExpirationDateTextBox" CssClass="form-control" runat="server" ReadOnly="true" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="AgentDoctorSendPackagePriceTextBox" runat="server" Text="Price (AUD): " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentDoctorSendPackagePriceTextBox" CssClass="form-control" runat="server" ReadOnly="true" TextMode="Number"></asp:TextBox>
                    </div>
                </div>--%>

                <div class="form-group">
                    <asp:Label AssociatedControlID="AgentDoctorSendPackageDateTextBox" runat="server" Text="Send Date: " CssClass="col-xs-3"></asp:Label>

                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentDoctorSendPackageDateTextBox" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentDoctorHome.aspx">Cancel</a>
                <asp:Button ID="AgentDoctorSendPackageTypeButton" runat="server" OnClick="AgentDoctorSendPackageTypeButton_Click"
                    Text="AgentDoctor Send" CssClass="btn btn-success btn-float-right" />
            </div>
            <%--<div>
                <asp:GridView ID="SmpGV" runat="server"></asp:GridView>
            </div>--%>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
