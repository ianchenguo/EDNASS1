﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AgentDoctorFeatures/AgentDoctorFeatures.master" AutoEventWireup="true" 
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

                <div class="form-group col-xs-12">
                    <asp:Label AssociatedControlID="AgentDoctorReceivePackagesBarcode" runat="server" Text="Barcode:&nbsp"></asp:Label>
                    <asp:TextBox ID="AgentDoctorReceivePackagesBarcode" runat="server"></asp:TextBox>
                </div>

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
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentDoctorHome.aspx">Cancel</a>
                <%--<asp:Button ID="" runat="server" OnClick="AgentDoctorReceiveButton_Click" Text="Receive" class="btn btn-success btn-float-right" />--%>
                <asp:Button ID="AgentDoctorReceivePackageButton" runat="server" Text="AgentDoctor Receive" 
                    CssClass="btn btn-success btn-float-right" OnClick="AgentDoctorReceivePackageButton_Click"/>

            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>