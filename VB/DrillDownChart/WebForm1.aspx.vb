Imports DevExpress.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraCharts
Imports DrillDownChart.Models
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq

Namespace DrillDownChart
    Partial Public Class WebForm1
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim diagram As XYDiagram = TryCast(WebChartControl1.Diagram, XYDiagram)
            If diagram IsNot Nothing Then
                diagram.AxisX.Label.Font = New Font(diagram.AxisX.Label.Font, FontStyle.Underline)
            End If
            WebChartControl1.DataBind()
            Dim breadcrumbs = WebChartControl1.Breadcrumbs
            breadcrumbs.Border.Color = Color.LightGray
            breadcrumbs.Border.Visibility = DefaultBoolean.True
            breadcrumbs.DXFont = New DXFont("Tahoma", 12.0F, DXFontStyle.Bold)
            breadcrumbs.HomeText = "Home"
        End Sub
        Protected Sub WebChartControl1_BoundDataChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim diagram As XYDiagram = TryCast(WebChartControl1.Diagram, XYDiagram)
            If diagram IsNot Nothing AndAlso WebChartControl1.Series.Count > 0 Then
                diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Automatic
                diagram.AxisX.DateTimeScaleOptions.AggregateFunction = AggregateFunction.Sum
            End If
        End Sub
        Protected Sub WebChartControl1_DrillDownStateChanged(ByVal sender As Object, ByVal e As DrillDownStateChangedEventArgs)
            Dim diagram As XYDiagram = TryCast(WebChartControl1.Diagram, XYDiagram)
            If diagram IsNot Nothing Then
                If TypeOf e.Series(0).View Is StackedBarSeriesView Then
                    diagram.Rotated = True
                    WebChartControl1.CrosshairOptions.ShowArgumentLine = False
                    WebChartControl1.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowForNearestSeries
                Else
                    diagram.Rotated = False
                    WebChartControl1.CrosshairOptions.ShowArgumentLine = True
                    WebChartControl1.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowCommonForAllSeries
                End If
            End If
        End Sub
        Protected Sub WebChartControl1_DrillDownStateChanging(ByVal sender As Object, ByVal e As DrillDownStateChangingEventArgs)
            If e.States.Length <> 0 Then
                Dim categoryValue As Object = Nothing
                If e.States.Last().Parameters.TryGetValue("ProductCategory", categoryValue) Then
                    Dim seriesIndex As Integer = WebChartControl1.Series.IndexOf(WebChartControl1.Series(DirectCast(categoryValue, String)))
                    Dim colorIndex As Integer = seriesIndex Mod WebChartControl1.PaletteRepository(WebChartControl1.PaletteName).Count + 1
                    WebChartControl1.PaletteBaseColorNumber = colorIndex
                End If
                Dim diagram As XYDiagram = TryCast(WebChartControl1.Diagram, XYDiagram)
                If (diagram IsNot Nothing) Then
                    diagram.AxisX.Label.Font = New Font("Tahoma", 8.25F, FontStyle.Regular)
                End If
            Else
                WebChartControl1.PaletteBaseColorNumber = 0
                Dim diagram As XYDiagram = TryCast(WebChartControl1.Diagram, XYDiagram)
                If (diagram IsNot Nothing) Then
                    diagram.AxisX.Label.Font = New Font("Tahoma", 8.25F, FontStyle.Underline)
                End If
            End If
        End Sub
    End Class
End Namespace
