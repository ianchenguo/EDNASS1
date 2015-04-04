<%@ Page Title="" Language="C#" MasterPageFile="~/DoctorFeatures/DoctorFeatures.master" AutoEventWireup="true" 
    CodeBehind="DoctorReceivePackage.aspx.cs" Inherits="ENETCare.Presentation.Doctor.DoctorReceivePackage" %>

<asp:Content ID="DocReceive" ContentPlaceHolderID="SpecificDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Receive Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">

            <div class="form-horizontal col-sm-10 col-sm-offset-1">

                <div class="form-group">
                    <label for="ned-package-receive-form-from" class="col-xs-3">From</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-from" type="text"
                            placeholder="From" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-type" class="col-xs-3">Package Type</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-type" type="text"
                            placeholder="Package Type" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-expire-date" class="col-xs-3">Expiration Date</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-expire-date" type="date" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-value" class="col-xs-3">Value (AUD)</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-value" type="text"
                            placeholder="Value in AUD" disabled />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-receive-form-barcode" class="col-xs-3">Package Barcode</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-receive-form-barcode" type="text"
                            placeholder="Package Barcode" />
                    </div>
                </div>
                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="DoctorHome.aspx">Cancel</a>
                <button class="btn btn-success btn-float-right" type="submit">Submit</button>

            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>