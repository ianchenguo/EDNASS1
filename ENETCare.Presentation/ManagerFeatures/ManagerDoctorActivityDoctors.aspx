<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerFeatures/ManagerFeatures.master" AutoEventWireup="true" CodeBehind="ManagerDoctorActivityDoctors.aspx.cs" Inherits="ENETCare.Presentation.ManagerFeatures.ManagerDoctorActivityDoctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SpecificManagerFeatureMainContent" runat="server">
    <!--panel-start-->
    <div class="panel panel-default">

        <!--panel-heading-start-->
        <div class="panel-heading">
            <h3 class="panel-title">Doctor List</h3>
        </div>
        <!--panel-heading-end-->

        <!--panel-body-start-->
        <div class="panel-body">

            <asp:GridView ID="DoctorsView"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table  table-hover table-bordered table-striped">

                <Columns>
                    <asp:BoundField DataField="DistributionCentre.Name" 
                        HeaderText="Distribution Centre" 
                        SortExpression="DistributionCentre.Name">
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Fullname" SortExpression="Fullname">
                        <ItemTemplate>
                            <asp:HyperLink ID="Fullname"
                                runat="server"
                                NavigateUrl='<%# "ManagerDoctorActivity.aspx?username=" + Eval("Username") + "&fullname=" + Eval("Fullname")%>'
                                Text='<%# Eval("Fullname") %>'>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:LinkButton ID="Back"
                runat="server"
                CssClass="btn btn-default btn-float-right"
                PostBackUrl="~/ManagerFeatures/ManagerHome.aspx">
                Back
            </asp:LinkButton>
        </div>
    </div>
    <!--panel-end-->
</asp:Content>
