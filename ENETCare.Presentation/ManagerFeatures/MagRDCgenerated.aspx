<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/MagFeatures.master" AutoEventWireup="true" 
    CodeBehind="MagRDCgenerated.aspx.cs" Inherits="ENETCare.Presentation.Manager.MagRDCgenerated" %>

<asp:Content ID="MagRDCgent" ContentPlaceHolderID="SpecificMagFeatureMainContent" runat="server">
    <div class="panel panel-default">
        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Remote Center new Report</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Package</th>
                        <th>Quantity</th>
                        <th>Unit</th>
                        <th>Value (AUD)</th>
                        <th>Location</th>
                        <th>State</th>
                        <th>Expiration Date</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>vaccinations</td>
                        <td>100</td>
                        <td>polio</td>
                        <td>100</td>
                        <td>Headquarter</td>
                        <td>In stock</td>
                        <td>2020/01/01</td>
                        <td>
                        </td>
                    </tr>
                    <tr class="warning">
                        <td>water purification kit</td>
                        <td>1</td>
                        <td>kit</td>
                        <td>59.6</td>
                        <td>Headquarter</td>
                        <td>In stock</td>
                        <td>2015/03/15</td>
                        <td>
                        </td>

                    </tr>
                    <tr class="danger">
                        <td>chloroquine pills</td>
                        <td>500</td>
                        <td>28 / pack</td>
                        <td>201</td>
                        <td>Headquarter</td>
                        <td>In stock</td>
                        <td>2001/01/01</td>
                        <td></td>
                    </tr>
                    <tr class="danger">
                        <td>Polyheme</td>
                        <td>10</td>
                        <td>Liter</td>
                        <td>28.5</td>
                        <td>Headquarter</td>
                        <td>Lost</td>
                        <td>2020/01/01</td>
                        <td></td>
                    </tr>
                </tbody>
            </table>

            <a href="ViewReportMag.aspx" type="a">
                <button class="btn btn-success btn-float-right" type="submit">Submit</button>
            </a>
            <a href="MagRDCRep.aspx" type="a">
                <button class="btn btn-danger btn-float-right" type="submit">Cancle</button>
            </a>
</asp:Content>
