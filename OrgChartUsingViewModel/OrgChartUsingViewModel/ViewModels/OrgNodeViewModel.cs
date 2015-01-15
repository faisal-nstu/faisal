using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Syncfusion.DocIO.DLS;
using Syncfusion.UI.Xaml.Diagram;
using Windows.UI.Xaml;
using Border = Windows.UI.Xaml.Controls.Border;
using Color = Windows.UI.Color;
using Style = Windows.UI.Xaml.Style;

namespace OrgChartUsingViewModel.ViewModels
{
    public class OrgNodeViewModel: NodeViewModel
    {
        public OrgNodeViewModel()
        {
            UnitWidth = 165;
            UnitHeight = 85;
            OffsetX = -1000;
            OffsetY = -1000;
            //ContentTemplate = App.Current.Resources["ChartContentTemplate"] as DataTemplate;
            ContentTemplate = App.Current.Resources["TestTemplate"] as DataTemplate;
            
        }
    }

    public class OrgConnectorViewModel: ConnectorViewModel
    {
        public OrgConnectorViewModel()
        {
            SolidColorBrush solid = new SolidColorBrush();
            solid.Color = Color.FromArgb(255, 3, 164, 249);
            this.ConnectorGeometryStyle = GetStyle(solid);
            
        }

        private Style GetStyle(SolidColorBrush solid)
        {
            Style s = new Style();
            s.TargetType = typeof(Windows.UI.Xaml.Shapes.Path);
            s.Setters.Add(new Setter(Windows.UI.Xaml.Shapes.Path.StrokeProperty, solid));
            s.Setters.Add(new Setter(Windows.UI.Xaml.Shapes.Path.StrokeThicknessProperty, 1.20));
            return s;
        }
    }
}
