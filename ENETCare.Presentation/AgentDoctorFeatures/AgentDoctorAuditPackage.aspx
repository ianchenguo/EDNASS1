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

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="PackageType" CssClass="col-md-3 control-label">Package Type</asp:Label>
                    <div class="col-md-9">

                        <asp:DropDownList ID="PackageType"
                            CssClass="form-control"
                            runat="server"
                            DataSourceID="PackageTypeSource"
                            DataTextField="Name"
                            DataValueField="ID"
                            OnSelectedIndexChanged="PackageType_SelectedIndexChanged" 
                            AutoPostBack="True">
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
                        <asp:TextBox runat="server" ID="Barcode" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Barcode"
                            CssClass="text-danger" Display="Dynamic"
                            ErrorMessage="The Barcode field is required."
                            ValidationGroup="AuditPackage" />

                        <asp:RegularExpressionValidator
                            runat="server"
                            ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d"
                            ControlToValidate="Barcode"
                            CssClass="text-danger"
                            ErrorMessage="The Barcode address is invalid."
                            ValidationGroup="AuditPackage" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:Button runat="server"
                            Text="Scan"
                            ValidationGroup="AuditPackage"
                            ID="AuditPackageButton"
                            OnClick="AuditPackageButton_Click"
                            CssClass="btn btn-default" />

                        <span runat="server" class="text-center">
                            Scanned 
                        <asp:Literal
                            ID="ScannedPackageTotal"
                            runat="server">
                        </asp:Literal>
                            Packages
                        </span>
                    </div>
                </div>
            </div>



            <asp:LinkButton Text="Cancel"
                runat="server"
                CssClass="btn btn-danger btn-float-right btn-margin-left"
                PostBackUrl="~/AgentDoctorFeatures/AgentDoctorHome.aspx" />

            <asp:LinkButton Text="Commit Audition"
                ID="CommitAuditionButton"
                runat="server"
                CssClass="btn btn-success btn-float-right"
                OnClick="CommitAuditionButton_Click" />
        </div>
        <!--panel-body-end-->

    </div>
    <!--panel-end-->
</asp:Content>
