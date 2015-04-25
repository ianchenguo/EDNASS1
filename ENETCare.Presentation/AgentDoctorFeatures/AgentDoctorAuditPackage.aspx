<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true" CodeBehind="AgentDoctorAuditPackage.aspx.cs" Inherits="ENETCare.Presentation.AgentDoctorFeatures.AgentDoctorAuditPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentDoctorFeatureMainContent" runat="server">

    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Audit Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <div class="form-horizontal col-sm-10 col-sm-offset-1">

                <div runat="server" id="AlertWindow" visible="false" class="alert alert-success" data-dismiss="alert">
                    <asp:Label ID="AlertWindowContent" runat="server" />
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="PackageType" CssClass="col-md-3 control-label">Package Type</asp:Label>
                    <div class="col-md-9">

                        <asp:DropDownList ID="PackageType"
                            CssClass="form-control"
                            runat="server"
                            DataSourceID="PackageTypeSource"
                            DataTextField="Name"
                            DataValueField="ID"
                            OnPreRender="PackageType_PreRender">
                        </asp:DropDownList>

                        <asp:ObjectDataSource runat="server"
                            ID="PackageTypeSource"
                            SelectMethod="GetMedicationTypeList"
                            TypeName="ENETCare.Business.MedicationTypeBLL"></asp:ObjectDataSource>

                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PackageType" Enabled="false"
                            CssClass="text-danger" ErrorMessage="The Distribution Centre field is required."
                            ValidationGroup="AuditPackage" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Barcode" CssClass="col-md-3 control-label">Barcode</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="Barcode" CssClass="form-control" TextMode="SingleLine" 
                            OnPreRender="Barcode_PreRender"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Barcode"
                            CssClass="text-danger" Display="Dynamic"
                            ErrorMessage="The Barcode field is required."
                            ValidationGroup="AuditPackage" />

                        <asp:RegularExpressionValidator
                            runat="server"
                            ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d"
                            ControlToValidate="Barcode"
                            CssClass="text-danger"
                            ErrorMessage="The Barcode is invalid."
                            ValidationGroup="AuditPackage" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:Button runat="server"
                            Text="Scan"
                            ValidationGroup="AuditPackage"
                            ID="ScanPackageButton"
                            OnClick="ScanPackageButton_Click"
                            Enabled='<%# Session["hasActiveAuditTask"] != null%>'
                            CssClass="btn btn-default" />

                        <span runat="server" class="text-center">Scanned 
                        <asp:Literal
                            ID="ScannedPackageTotal"
                            runat="server">
                        </asp:Literal>
                            Packages
                        </span>
                    </div>
                </div>
            </div>

            <%--            <asp:LinkButton Text="Cancel"
                ID="LinkButton1"
                runat="server"
                CssClass="btn btn-danger btn-float-right btn-margin-left"
                OnClick="CancelButton_Click"
                PostBackUrl="~/AgentDoctorFeatures/AgentDoctorHome.aspx" />--%>

            <asp:LinkButton Text="Cancel"
                ID="CancelButton"
                runat="server"
                CssClass="btn btn-danger btn-float-right btn-margin-left"
                OnClick="CancelButton_Click"
                OnPreRender="CancelButton_PreRender"/>

            <asp:LinkButton Text="Commit Audit"
                ID="CommitAuditButton"
                runat="server"
                Visible='<%# Session["hasActiveAuditTask"] != null%>'
                CssClass="btn btn-success btn-float-right"
                OnClick="CommitAuditButton_Click" />

            <asp:LinkButton Text="New Audit"
                ID="StartAuditButton"
                runat="server"
                Visible='<%# Session["hasActiveAuditTask"] == null%>'
                CssClass="btn btn-success btn-float-right"
                OnClick="StartAuditButton_Click" />
        </div>
        <!--panel-body-end-->

    </div>
    <!--panel-end-->
</asp:Content>
