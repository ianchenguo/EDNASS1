<%@ Page Title="" Language="C#" MasterPageFile="~/DoctorFeatures/DoctorFeatures.master" AutoEventWireup="true" 
    CodeBehind="DoctorRegisterPackage.aspx.cs" Inherits="ENETCare.GUI.Doctor.DoctorRegisterPackage" %>

<asp:Content ID="DocRigs" ContentPlaceHolderID="SpecificDoctorFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Register Medication Package</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <form class="form-horizontal col-sm-10 col-sm-offset-1" action="">
                <div class="form-group">
                    <label for="ned-package-register-form-type" class="col-xs-3">Package Type</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-register-form-type" type="text"
                            placeholder="Package Type" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-register-form-expire-date" class="col-xs-3">Expiration Date</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-register-form-expire-date" type="date" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="ned-package-register-form-value" class="col-xs-3">Value (AUD)</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-register-form-value" type="text"
                            placeholder="Value in AUD" />
                    </div>
                </div>
                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="DoctorHome.aspx">Cancel</a>
                <button class="btn btn-success btn-float-right" type="submit">Submit</button>

            </form>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->
</asp:Content>