using DevExpress.XtraCharts;
using DrillDownChart.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DrillDownChart {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            XYDiagram diagram = WebChartControl1.Diagram as XYDiagram;
            if (diagram != null) {
                diagram.AxisX.Label.Font = new Font(diagram.AxisX.Label.Font, FontStyle.Underline);
            }
            WebChartControl1.DataBind();
        }
        protected void WebChartControl1_BoundDataChanged(object sender, EventArgs e) {
            XYDiagram diagram = WebChartControl1.Diagram as XYDiagram;
            if (diagram != null && WebChartControl1.Series.Count > 0) {
                diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Automatic;
                diagram.AxisX.DateTimeScaleOptions.AggregateFunction = AggregateFunction.Sum;
            }
        }
        protected void WebChartControl1_DrillDownStateChanged(object sender, DrillDownStateChangedEventArgs e) {
            XYDiagram diagram = WebChartControl1.Diagram as XYDiagram;
            if (diagram != null) {
                if (e.Series[0].View is StackedBarSeriesView) {
                    diagram.Rotated = true;
                    WebChartControl1.CrosshairOptions.ShowArgumentLine = false;
                    WebChartControl1.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowForNearestSeries;
                }
                else {
                    diagram.Rotated = false;
                    WebChartControl1.CrosshairOptions.ShowArgumentLine = true;
                    WebChartControl1.CrosshairOptions.CrosshairLabelMode = CrosshairLabelMode.ShowCommonForAllSeries;
                }
            }
        }

        protected void WebChartControl1_DrillDownStateChanging(object sender, DrillDownStateChangingEventArgs e) {
            if (e.States.Length != 0) {
                object categoryValue = null;
                if (e.States.Last().Parameters.TryGetValue("ProductCategory", out categoryValue)) {
                    int seriesIndex = WebChartControl1.Series.IndexOf(WebChartControl1.Series[(string)categoryValue]);
                    int colorIndex = seriesIndex % WebChartControl1.PaletteRepository[WebChartControl1.PaletteName].Count + 1;
                    WebChartControl1.PaletteBaseColorNumber = colorIndex;
                }
                if (WebChartControl1.Diagram is XYDiagram diagram) {
                    diagram.AxisX.Label.Font = new Font("Tahoma", 8.25f, FontStyle.Regular);
                }
            }
            else {
                WebChartControl1.PaletteBaseColorNumber = 0;
                if (WebChartControl1.Diagram is XYDiagram diagram) {
                    diagram.AxisX.Label.Font = new Font("Tahoma", 8.25f, FontStyle.Underline);
                }
            }
        }
    }
}
