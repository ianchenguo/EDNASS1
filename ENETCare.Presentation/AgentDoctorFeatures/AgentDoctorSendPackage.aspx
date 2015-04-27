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

                <div runat="server" id="AgentDoctorSendPackageAlertWindowDiv" visible="false" class="alert alert-success" data-dismiss="alert">
                    <asp:Label ID="AgentDoctorSendPackageAlertWindowContentLabel" runat="server" />
                </div>

                <div class="form-group">

                    <asp:Label AssociatedControlID="AgentDoctorSendingDropDownList" runat="server" CssClass="col-xs-3">Destination: </asp:Label>
                    <div class="col-xs-9">
                        <asp:DropDownList ID="AgentDoctorSendingDropDownList" runat="server" CssClass="form-control">
                            <asp:ListItem>Please Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="AgentDoctorSendPackageTypebarcode" runat="server" CssClass="col-xs-3">Barcode: </asp:Label>
                    <div class="col-xs-9">
                        <asp:TextBox ID="AgentDoctorSendPackageTypebarcode" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AgentDoctorSendPackageTypebarcode"
                            CssClass="text-danger" Display="Dynamic"
                            ErrorMessage="<div>The Barcode field is required.</div>"
                            ValidationGroup="AgentDoctorSendPackageValidatePack" />

                        <asp:RegularExpressionValidator
                            runat="server"
                            ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d"
                            ControlToValidate="AgentDoctorSendPackageTypebarcode"
                            CssClass="text-danger"
                            ErrorMessage="<div>The Barcode is invalid.</div>"
                            ValidationGroup="AgentDoctorSendPackageValidatePack" />
                    </div>
                </div>

                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentDoctorHome.aspx">Cancel</a>
                <asp:Button ID="AgentDoctorSendPackageTypeButton" runat="server" OnClick="AgentDoctorSendPackageTypeButton_Click"
                    Text="Send" CssClass="btn btn-success btn-float-right" ValidationGroup="AgentDoctorSendPackageValidatePack" />
            </div>
            <%--<div>
                <asp:GridView ID="SmpGV" runat="server"></asp:GridView>
            </div>--%>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
