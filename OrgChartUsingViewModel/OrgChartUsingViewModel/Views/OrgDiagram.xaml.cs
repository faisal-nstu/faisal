using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Microsoft.Practices.Prism.StoreApps;
using OrgChartUsingViewModel.Models;
using OrgChartUsingViewModel.ViewModels;
using Syncfusion.Data.Extensions;
using Syncfusion.DocIO.DLS;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.UI.Xaml.Schedule;
using Color = System.Drawing.Color;

namespace OrgChartUsingViewModel.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrgDiagram : Page
    {
        private IGraphInfo graphInfo;
        public OrgDiagram()
        {
            this.InitializeComponent();
            graphInfo = SfDiagram.Info as IGraphInfo;
            SfDiagram.Loaded += SfDiagram_Loaded;
        }

           
        private void SfDiagram_Loaded(object sender, RoutedEventArgs routedEventArgs)
        {
            GetScrollViewer((sender as SfDiagram));
            
            foreach (var item in (sender as SfDiagram).Page.Children.OfType<Node>())
            {
                if (item.GetType() != typeof(Syncfusion.UI.Xaml.Diagram.Selector))
                {
                    if (((item as Node).DataContext as OrgNodeViewModel).Content is Employee)
                    {
                       
                        (item as Node).ManipulationMode = ManipulationModes.System;
                    }
                }
            }
        }

       

        
        private bool GetScrollViewer(DependencyObject sfd)
        {
            if (sfd is ScrollViewer)
            {
                (this.DataContext as ChartViewModel).ScrollViewer = (sfd as ScrollViewer);
                return true;
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(sfd); i++)
            {
                if (GetScrollViewer(VisualTreeHelper.GetChild(sfd, i)))
                {
                    return true;
                }
            }
            return false;
        }

        public ChartViewModel ChartViewModel
        {
            get { return (ChartViewModel)GetValue(ChartViewModelProperty); }
            set { SetValue(ChartViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartViewModelProperty =
            DependencyProperty.Register("ChartViewModel", typeof(ChartViewModel), typeof(OrgDiagram), new PropertyMetadata(null, OnPropertyChangedCallBack));

        private static void OnPropertyChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OrgDiagram diagram = d as OrgDiagram;

            ChartViewModel chartvm = e.NewValue as ChartViewModel;
            diagram.UpdateCollection();
            //chartvm.ShowProperties = new DelegateCommand<object>(diagram.OnShowProperties, args => { return true; });
            //chartvm.Done = new DelegateCommand<object>(diagram.OnDone, args => { return true; });
            //chartvm.Cancel = new DelegateCommand<object>(diagram.OnCancel, args => { return true; });
            //chartvm.Previous = new DelegateCommand<object>(diagram.OnPrevious, args => { return true; });
            //chartvm.Next = new DelegateCommand<object>(diagram.OnNext, args => { return true; });
            //chartvm.Close = new DelegateCommand<object>(diagram.OnClose, args => { return true; });
            //chartvm.Search = new DelegateCommand<object>(diagram.OnSearch, args => { return true; });
            //chartvm.AddUser = new DelegateCommand<object>(diagram.AddUser, args => { return true; });
            //chartvm.CloseAppBar = new DelegateCommand<object>(diagram.Closeappbar, args => { return true; });
        }
        private void UpdateCollection()
        {
            SfDiagram.Nodes = new DiagramCollection<OrgNodeViewModel>();
            SfDiagram.DataSourceSchema.ParentId = "ReportingPerson";
            SfDiagram.DataSourceSchema.Id = "Name";
            SfDiagram.Connectors = new DiagramCollection<OrgConnectorViewModel>();
            
            (SfDiagram.Nodes as DiagramCollection<OrgNodeViewModel>).CollectionChanged += OrgDiagram_CollectionChanged;

            ObservableCollection<Employee> employee = new ObservableCollection<Employee>();
            XDocument loadedData = XDocument.Load(Package.Current.InstalledLocation.Path + "/Employee.xml");


            foreach (var item in loadedData.Descendants("Employee"))
            {
                employee.Add(new Employee()
                {
                    Name = item.Attribute("Name").Value,
                    ContactNo = Convert.ToDouble(item.Attribute("ContactNo").Value),
                    Destination = item.Attribute("Destination").Value,
                    Doj = item.Attribute("Doj").Value,
                    EmailId = item.Attribute("EmailId").Value,
                    ImageUrl = item.Attribute("ImageUrl").Value,
                    RatingColor = item.Attribute("RatingColor").Value,
                    Salary = Convert.ToDouble(item.Attribute("Salary").Value),
                    IsExpand = returnValue(item.Attribute("IsExpand").Value),
                    ReportingPerson = IsCheck(item.Attribute("ReportingPerson"))

                });
            }

            SfDiagram.DataSourceSchema.DataSource = employee;
            SfDiagram.LayoutManager = new Syncfusion.UI.Xaml.Diagram.Layout.LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    HorizontalSpacing = 20,
                    VerticalSpacing = 40,
                    SpaceBetweenSubTrees = 20
                }
            };

        }

        private string IsCheck(XAttribute xAttribute)
        {
            if (xAttribute == null)
            {
                return string.Empty;
            }

            return xAttribute.Value;
        }


        private State returnValue(string p)
        {
            foreach (State s in Enum.GetValues(typeof(State)))
            {
                if (s.ToString() == p)
                {
                    return s;
                }
            }
            return State.None;
        }
        void OrgDiagram_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                if (e.NewItems[0] is OrgNodeViewModel)
                {
                    ChartViewModel.NodeCollection.Add(e.NewItems[0] as OrgNodeViewModel);
                }
            }
        }
    }
}
