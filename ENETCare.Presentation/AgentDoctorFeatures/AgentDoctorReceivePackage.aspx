<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true"
    CodeBehind="AgentDoctorReceivePackage.aspx.cs" Inherits="ENETCare.Presentation.AgentDoctorFeatures.AgentDoctorReceivePackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Receive Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <div class="form-horizontal col-sm-10 col-sm-offset-1" runat="server">

                <div runat="server" id="AgentDoctorReceivePackageAlertWindowDiv" visible="false" class="alert alert-success" data-dismiss="alert">
                    <asp:Label ID="AgentDoctorReceivePackageAlertWindowContentLabel" runat="server" />
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="AgentDoctorReceivePackagesBarcode" runat="server" Text="Barcode:&nbsp" CssClass="col-xs-3"></asp:Label>
                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentDoctorReceivePackagesBarcode" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AgentDoctorReceivePackagesBarcode"
                            CssClass="text-danger" Display="Dynamic"
                            ErrorMessage="The Barcode field is required."
                            ValidationGroup="AgentDoctorReceivePackageValidateGroup" />

                        <asp:RegularExpressionValidator
                            runat="server"
                            ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d"
                            ControlToValidate="AgentDoctorReceivePackagesBarcode"
                            CssClass="text-danger"
                            ErrorMessage="The Barcode is invalid."
                            ValidationGroup="AgentDoctorReceivePackageValidateGroup" />
                    </div>

                </div>
                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentDoctorHome.aspx">Cancel</a>
                <%--<asp:Button ID="" runat="server" OnClick="AgentDoctorReceiveButton_Click" Text="Receive" class="btn btn-success btn-float-right" />--%>
                <asp:Button ID="AgentDoctorReceivePackageButton" runat="server" Text="Receive"
                    CssClass="btn btn-success btn-float-right" OnClick="AgentDoctorReceivePackageButton_Click" ValidationGroup="AgentDoctorReceivePackageValidateGroup" />

            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
