<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DrillDownChart.WebForm1" %>
<%@ Register Assembly="DevExpress.XtraCharts.v18.2.Web, Version=18.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v18.2, Version=18.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dxc" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ObjectDataSource ID="chartDataSource" runat="server" TypeName="DrillDownChart.Models.DevAV" DataObjectTypeName="DrillDownChart.Models.DevAVDataItem" SelectMethod="GetTotalSales"></asp:ObjectDataSource>
            <dxui:WebChartControl ID="WebChartControl1" runat="server" Height="400px" Width="700px"
                                DataSourceID="chartDataSource"
                                ClientInstanceName="chart"
                                OnBoundDataChanged="WebChartControl1_BoundDataChanged"
                                OnDrillDownStateChanged="WebChartControl1_DrillDownStateChanged"
                                OnDrillDownStateChanging="WebChartControl1_DrillDownStateChanging"
                                SeriesDataMember="ProductCategory"
                                ToolTipEnabled="False" CrosshairEnabled="True">
                <BorderOptions Visibility="True" />
                <CrosshairOptions CrosshairLabelMode="ShowForNearestSeries" />
                <Titles>
                    <dxc:ChartTitle Text="DevAV Total Sales" />
                </Titles>
                <Legend Name="Default Legend"></Legend>
                <SeriesTemplate ArgumentDataMember="Region" ValueDataMembersSerializable="Sales" 
                                LabelsVisibility="False" CrosshairLabelPattern="{S}: ${V:N2}">
                    <ViewSerializable>
                        <dxc:StackedBarSeriesView/>
                    </ViewSerializable>
                    <QualitativeSummaryOptions SummaryFunction="SUM([Sales])"/>
 
                   <SeriesDrillTemplate SeriesDataMember="ProductName" ArgumentDataMember="Region" ValueDataMembersSerializable="Sales" 
                                         CrosshairLabelPattern="{S}: ${V:N2}">
                        <ViewSerializable>
                            <dxc:StackedBarSeriesView/>
                        </ViewSerializable>
                       <ArgumentDrillTemplate SeriesDataMember="ProductCategory" ArgumentDataMember="ProductName" ValueDataMembersSerializable="Sales"
                                           CrosshairLabelPattern="{S}: ${V:N2}">
                            <ViewSerializable>
                                <dxc:StackedAreaSeriesView Transparency="100"/>
                            </ViewSerializable>
                            <SeriesDrillTemplate SeriesDataMember="ProductName" ArgumentDataMember="SaleDate" ValueDataMembersSerializable="Sales"
                                                 CrosshairLabelPattern="{A}: ${V:N2}">
                                <ViewSerializable>
                                    <dxc:StackedAreaSeriesView Transparency="100"/>
                                </ViewSerializable>
                            </SeriesDrillTemplate>
                        </ArgumentDrillTemplate>
                        <SeriesPointDrillTemplate SeriesDataMember="ProductName" ArgumentDataMember="SaleDate" ValueDataMembersSerializable="Sales"
                                              CrosshairLabelPattern="{S}: ${V:N2}">
                            <ViewSerializable>
                                <dxc:StackedAreaSeriesView Transparency="100"/>
                            </ViewSerializable>
                            <SeriesDrillTemplate SeriesDataMember="ProductName" ArgumentDataMember="SaleDate" ValueDataMembersSerializable="Sales"
                                                 CrosshairLabelPattern="{A:d}: ${V:N2}">
                                <ViewSerializable>
                                    <dxc:SplineAreaSeriesView Transparency="100" MarkerVisibility="false"/>
                                </ViewSerializable>
                            </SeriesDrillTemplate>
                        </SeriesPointDrillTemplate>
                        <SeriesDrillTemplate SeriesDataMember="Region" ArgumentDataMember="SaleDate" ValueDataMembersSerializable="Sales"
                                             CrosshairLabelPattern="{A:d}: ${V:N2}">
                                <ViewSerializable>
                                    <dxc:StackedAreaSeriesView Transparency="100"/>
                                </ViewSerializable>
                        </SeriesDrillTemplate>
                    </SeriesDrillTemplate>

                    <ArgumentDrillTemplate SeriesDataMember="ProductCategory" ArgumentDataMember="SaleDate" ValueDataMembersSerializable="Sales"
                                           CrosshairLabelPattern="{S}: ${V:N2}">
                            <ViewSerializable>
                                <dxc:StackedAreaSeriesView Transparency="100"/>
                            </ViewSerializable>
                        <SeriesDrillTemplate SeriesDataMember="ProductName" ArgumentDataMember="SaleDate" ValueDataMembersSerializable="Sales"
                                             CrosshairLabelPattern="{S}: ${V:N2}">
                            <ViewSerializable>
                                <dxc:StackedAreaSeriesView Transparency="100"/>
                            </ViewSerializable>
                            <SeriesDrillTemplate SeriesDataMember="ProductName" ArgumentDataMember="SaleDate" ValueDataMembersSerializable="Sales"
                                                 CrosshairLabelPattern="{A:d}: ${V:N2}">
                                <ViewSerializable>
                                    <dxc:SplineAreaSeriesView Transparency="100" MarkerVisibility="false"/>
                                </ViewSerializable>
                            </SeriesDrillTemplate>
                        </SeriesDrillTemplate>
                    </ArgumentDrillTemplate>

                    <SeriesPointDrillTemplate SeriesDataMember="ProductName" ArgumentDataMember="SaleDate" ValueDataMembersSerializable="Sales"
                                              CrosshairLabelPattern="{S}: ${V:N2}">
                        <ViewSerializable>
                            <dxc:StackedAreaSeriesView Transparency="100"/>
                        </ViewSerializable>
                        <SeriesDrillTemplate SeriesDataMember="ProductName" ArgumentDataMember="SaleDate" ValueDataMembersSerializable="Sales"
                                             CrosshairLabelPattern="{A:d}: ${V:N2}">
                            <ViewSerializable>
                                <dxc:SplineAreaSeriesView Transparency="100" MarkerVisibility="false"/>
                            </ViewSerializable>
                        </SeriesDrillTemplate>
                    </SeriesPointDrillTemplate>
                </SeriesTemplate>
                <DiagramSerializable>                  
                    <dxc:XYDiagram Rotated="true">
                        <AxisX>
                            <GridLines Visible="True"/>
                            <Label/>
                        </AxisX>
                        <AxisY Title-Text="Thousands of USD" Title-Visibility="True" VisibleInPanesSerializable="-1">
                            <Label TextPattern="{V:0,.##}"></Label>
                        </AxisY>
                    </dxc:XYDiagram>
                </DiagramSerializable>
            </dxui:WebChartControl>
        </div>
    </form>
</body>
</html>