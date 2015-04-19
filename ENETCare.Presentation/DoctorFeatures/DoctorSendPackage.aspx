<%@ Page Title="" Language="C#" MasterPageFile="~/DoctorFeatures/DoctorFeatures.master" AutoEventWireup="true" 
    CodeBehind="DoctorSendPackage.aspx.cs" Inherits="ENETCare.Presentation.DoctorFeatures.DoctorSendPackage" %>

<asp:Content ID="DocSend" ContentPlaceHolderID="SpecificDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Send Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <div class="form-horizontal col-sm-10 col-sm-offset-1">

                <div class="form-group col-xs-12">
                        <asp:Label AssociatedControlID="DoctorPackageSendingDestination"
                            runat="server" Text="Destination Distribution Centre:&nbsp"></asp:Label>

                        <asp:DropDownList ID="DoctorPackageSendingDestination" runat="server" OnSelectedIndexChanged="DoctorPackageSendingDestinationLabel_SelectedIndexChanged">
                            <asp:ListItem>Please select</asp:ListItem>
                        </asp:DropDownList>&nbsp
                        
                    <asp:Label AssociatedControlID="DoctorSendBarcodeTextBox" runat="server" Text="Barcode:&nbsp"></asp:Label>
                        <asp:TextBox ID="DoctorSendBarcodeTextBox" runat="server"></asp:TextBox>
                </div>

               <%-- <div class="form-group">
                    <label for="ned-package-send-form-type" class="col-xs-3">Package Type</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-send-form-type" type="text"
                            placeholder="Package Type" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-send-form-expire-date" class="col-xs-3">Expiration Date</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-send-form-expire-date" type="date" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-send-form-value" class="col-xs-3">Value (AUD)</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-send-form-value" type="text"
                            placeholder="Value in AUD" disabled />
                    </div>
                </div>--%>

                <div class="form-group">
                    <asp:Label ID="DoctorSendDateLabel" Text="&nbsp;&nbsp;&nbsp;&nbsp;Send Date" runat="server" Font-Bold="true" />

                    <div class="col-xs-9">
                        <asp:TextBox ID="DoctorSendPackageDateTextBox" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="DoctorHome.aspx">Cancel</a>
                <asp:Button ID="DoctorSendButton" runat="server" OnClick="DoctorSendButton_Click" Text="Doctor Send" CssClass="btn btn-success btn-float-right" />

            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>