<%@ Page Title="" Language="C#" MasterPageFile="~/AgentFeatures/AgentFeatures.master" AutoEventWireup="true" CodeBehind="AuditPackage.aspx.cs" Inherits="ENETCare.Presentation.AgentFeatures.AuditPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentFeatureMainContent" runat="server">

    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Audit Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">

            <div class="form-inline col-sm-10 col-sm-offset-1" runat="server">

                <div class="row">
                    <div class="form-group">
                        <asp:Label AssociatedControlID="AuditPackageBarcode"
                            runat="server"
                            Text="Barcode:&nbsp"></asp:Label>
                        <asp:TextBox
                            ID="AuditPackageBarcode"
                            runat="server"></asp:TextBox>
                    </div>
                    <!--form-group-end-->

                    <asp:Button ID="AuditPackageButton"
                        runat="server"
                        Text="Scan"
                        CssClass="btn btn btn-default"
                        OnClick="AuditPackageButton_Click" />
                </div>

                <div class="row">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="AuditPackageBarcode"
                        CssClass="text-danger" Display="Dynamic"
                        ErrorMessage="The barcode field is required." />

                    <asp:RegularExpressionValidator
                        runat="server"
                        ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d"
                        ControlToValidate="AuditPackageBarcode"
                        CssClass="text-danger"
                        ErrorMessage="The barcode format is invalid. (should be 18 digits)" />

                </div>

                <br />
                <br />

                <%--<div class="form-group">
                    <label for="ned-package-receive-form-from" class="col-xs-3">From</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-from" type="text"
                            placeholder="Package Type" readonly />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-type" class="col-xs-3">Package Type</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-type" type="text"
                            placeholder="Package Type" readonly />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-expire-date" class="col-xs-3">Expiration Date</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-expire-date" type="date" readonly />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-value" class="col-xs-3">Value (AUD)</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-value" type="text"
                            placeholder="Value in AUD" readonly />
                    </div>
                </div>--%>
                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentHome.aspx">Cancel</a>
                <%--<asp:Button ID="" runat="server" OnClick="AgentReceiveButton_Click" Text="Receive" class="btn btn-success btn-float-right" />--%>
                <%--<asp:Button ID="AgentReceivePackageButton" runat="server" Text="Agent Receive"
                    CssClass="btn btn-success btn-float-right" OnClick="AgentReceivePackageButton_Click" />--%>
            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
