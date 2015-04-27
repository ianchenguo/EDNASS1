<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true" CodeBehind="AgentDoctorDiscardPackage.aspx.cs" Inherits="ENETCare.Presentation.AgentDoctorFeatures.AgentDoctoDiscardPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Discard Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">

            <div class="form-horizontal col-sm-10 col-sm-offset-1" runat="server">

                <div runat="server" id="AgentDoctorDiscardPackageAlertWindowDiv" visible="false" class="alert alert-success" data-dismiss="alert">
                    <asp:Label ID="AgentDoctorDiscardPackageAlertWindowContentLabel" runat="server" />
                </div>

                <div class="form-group col-xs-12">
                    <asp:Label AssociatedControlID="AgentDoctorDiscardPackagesBarcode" runat="server" Text="Barcode:&nbsp"></asp:Label>
                    <asp:TextBox ID="AgentDoctorDiscardPackagesBarcode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="AgentDoctorDiscardPackagesBarcode"
                        CssClass="text-danger" Display="Dynamic"
                        ErrorMessage="<div>The Barcode field is required.</div>"
                        ValidationGroup="AgentDoctorDiscardPackageValidateGroup" />

                    <asp:RegularExpressionValidator
                        runat="server"
                        ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d"
                        ControlToValidate="AgentDoctorDiscardPackagesBarcode"
                        CssClass="text-danger"
                        ErrorMessage="<div>The Barcode is invalid.</div>"
                        ValidationGroup="AgentDoctorDiscardPackageValidateGroup" />
                </div>
                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentDoctorHome.aspx">Cancel</a>
                <%--<asp:Button ID="" runat="server" OnClick="AgentDoctorDiscardButton_Click" Text="Discard" class="btn btn-success btn-float-right" />--%>
                <asp:Button ID="AgentDoctorDiscardPackageButton" runat="server" Text="Discard"
                    CssClass="btn btn-success btn-float-right" OnClick="AgentDoctorDiscardPackageButton_Click" ValidationGroup="AgentDoctorDiscardPackageValidateGroup" />

            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
