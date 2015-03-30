<%@ Page Title="" Language="C#" MasterPageFile="~/AgentFeatures/AgentFeatures.master" AutoEventWireup="true" CodeBehind="AgentSendPackage.aspx.cs" Inherits="ENETCare.Presentation.AgentFeatures.AgentSendPackage"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificAgentFeatureMainContent" runat="server">
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

                <div class="form-group">
                    <label for="ned-package-send-form-dest" class="col-xs-3">Destination</label>

                    <div class="col-xs-9">
                        <select class="form-control" id="ned-package-send-form-dest">
                            <option>UTS Centre</option>
                            <option>Dummy Centre 1</option>
                            <option>Dummy Centre 2</option>
                            <option>Dummy Centre 3</option>
                            <option>Dummy Centre 4</option>
                        </select>
                    </div>
                </div>

                <div class="form-group">
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
                </div>

                <div class="form-group">
                    <label for="ned-package-send-form-barcode" class="col-xs-3">Package Barcode</label>

                    <div class="col-xs-9">
                        <input class="form-control" id="ned-package-send-form-barcode" type="text"
                            placeholder="Package Barcode" />
                    </div>
                </div>
                <!-- the following link should be optimised -->
                <a class="btn btn-danger btn-float-right btn-margin-left" type="a" href="AgentHome.aspx">Cancel</a>
                <button class="btn btn-success btn-float-right" type="submit">Submit</button>

            </div>
        </div>
        <!--panel-body-end-->
    </div>
    <!--panel-end-->

</asp:Content>
