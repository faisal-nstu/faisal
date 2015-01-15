using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Diagram;

namespace OrgChartUsingViewModel.ViewModels
{
    public class ChartViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DiagramCollection<OrgNodeViewModel> NodeCollection { get; set; }
        public DiagramCollection<OrgConnectorViewModel> Connectors { get; set; }
        public ChartViewModel()
        {
            NodeCollection = new DiagramCollection<OrgNodeViewModel>();
            Connectors = new DiagramCollection<OrgConnectorViewModel>();
        }

        public object ScrollViewer
        {
            get;
            set;
        }
    }
}
