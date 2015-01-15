using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Microsoft.Practices.Prism.StoreApps;
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.UI.Xaml.Diagram;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Annotation = Syncfusion.UI.Xaml.Diagram.Serializer.Annotation;
using Color = Syncfusion.DocIO.DLS.Color;
using Node = Syncfusion.UI.Xaml.Diagram.Serializer.Node;
using Point = Windows.Foundation.Point;
using Rectangle = Syncfusion.DocIO.DLS.Rectangle;

namespace SyncConnector.Views
{
    public sealed partial class MainPage : VisualStateAwarePage
    {
        
        ObservableCollection<NodeViewModel> nodes = new ObservableCollection<NodeViewModel>();
        //ObservableCollection<Node> nodes = new ObservableCollection<Node>();
        ObservableCollection<ConnectorViewModel> connectors = new ObservableCollection<ConnectorViewModel>();
        private DataTemplate _nodeDataTemplate;
        private NodeViewModel selectedNode;
        public MainPage()
        {
            this.InitializeComponent();

            diagramControl.SnapSettings.SnapConstraints = SnapConstraints.HorizontalLines;
            Gridlines gridlines = new Gridlines()
            {
                SnapInterval = new List<double>() {150,150 },
                LinesInterval = new List<double>() { 150, 150}
            };
            
            diagramControl.SnapSettings.HorizontalGridlines = gridlines;
            diagramControl.SnapSettings.VerticalGridlines = gridlines;
        }


        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            _nodeDataTemplate = this.Resources["NodeDataTemplate"] as DataTemplate;
            //AddNode();
            //NodeViewModel n1 = AddNode();
            //AddConnector();
            //Node n1 = addNode("testNode", 400, 200, "Bangladesh", 4, new Windows.UI.Xaml.Shapes.Rectangle(), "#121212");
//**************************************************************


//********** Node Selected event **********************************************

        }

//****************** ADD NODE  ----   Syncfusion version **********************
        //private Node addNode(String name, double offsetx, double offsety, String label, Int32 level, Shape shape, string pathfill)
        //{
        //    Node node = new Node();
        //    node.ID = Guid.NewGuid();
        //    node.Width = 120;
        //    node.Height = 60;
        //    node.OffsetX = offsetx;
        //    node.OffsetY = offsety;
        //    //node.Content = new TextBlock() { Text = label, TextAlignment = TextAlignment.Center };
        //    node.AnnotationColT = label;
        //    //node.EnumShape = shape;
        //    //node.Fill = pathfill;
        //    nodes.Add(node);
        //    diagramControl.Nodes = nodes;
        //    //(diagramControl.Nodes as ICollection<object>).Add(node);
        //    return node;

        //    //nodes.Add(node as NodeViewModel);
        //    //diagramControl.Nodes = nodes;
        //}


// *************** ADD NODE MY Version
        private NodeViewModel AddNode()
        {
            var node = new NodeViewModel()
            {
                ID = Guid.NewGuid(),
                OffsetX = 200,
                OffsetY = 200,
                SnapToObject = SnapToObject.All,
                Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 10, 10) },
                Constraints = NodeConstraints.Selectable| NodeConstraints.Draggable| NodeConstraints.InheritPortVisibility | NodeConstraints.InheritSnapping | NodeConstraints.SnapToHorizontalLines ,
                ContentTemplate = _nodeDataTemplate,
                Annotations = new ObservableCollection<IAnnotation>()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content = "Edit Label",
                        Mode = ContentEditorMode.Edit,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        EditTemplate=this.Resources["edittemplate"] as DataTemplate,
                        ViewTemplate=this.Resources["viewtemplate"] as DataTemplate
                    }
                },
                Ports = new ObservableCollection<INodePort>()
                {
                    new NodePort()
                    {
                        Width=10,
                        Height=10,
                        NodeOffsetX=10,
                        NodeOffsetY=25,
                        UnitMode=UnitMode.Absolute,
                        Shape=new EllipseGeometry(){RadiusX=10,RadiusY=10},
                        ShapeStyle=this.Resources["portstyle"] as Style,
                        PortVisibility = PortVisibility.Visible,
                        
                    }
                },
                PortVisibility = PortVisibility.Visible
            };

            nodes.Add(node);
            diagramControl.Nodes = nodes;
            diagramControl.PortVisibility = PortVisibility.Visible;
            return node;
        }

        private void AddConnector() 
        {
            ConnectorViewModel con = new ConnectorViewModel()

            {
                Constraints = ConnectorConstraints.Selectable | ConnectorConstraints.EndDraggable | ConnectorConstraints.SnapToLines  | ConnectorConstraints.Thumbs| ConnectorConstraints.Routing,
                ID = Guid.NewGuid(),
                SourcePoint = new Point(500,10),
                //SourceNode = diagramControl.SelectedItems,
                TargetPoint = new Point(600,100)
            };

            // Adding Connection to SfDiagram

            connectors.Add(con);
            diagramControl.Constraints = diagramControl.Constraints | GraphConstraints.Routing;
            diagramControl.Connectors = connectors;
        }

        private void Add_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            AddNode();
        }

        private void Add_Connection_Click(object sender, RoutedEventArgs e)
        {
            AddConnector();
        }


        private async void DiagramControl_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            //var d = diagramControl.SelectedItems;

            //SelectorViewModel selecteditems = (diagramControl.SelectedItems as SelectorViewModel);

            //// Selected Items-Collection for Nodes
            //foreach (NodeViewModel n in (IEnumerable<NodeViewModel>)selecteditems.Nodes)
            //{
            //    if (n.IsSelected)
            //    {
            //        selectedNode = n;
            //    }
            //}
        }




// *********** shapes enumeration **************************************
        public enum Shapes
        {
            None,

            /// <summary>
            /// Rectangle shape
            /// </summary>
            Rectangle,

            /// <summary>
            /// Star shape
            /// </summary>
            Star,

            /// <summary>
            /// Hexagon shape
            /// </summary>
            Hexagon,

            /// <summary>
            /// Octagon shape
            /// </summary>
            Octagon,

            /// <summary>
            /// Pentagon shape
            /// </summary>
            Pentagon,

            /// <summary>
            /// Heptagon shape
            /// </summary>
            Heptagon,

            /// <summary>
            /// Triangle shape
            /// </summary>
            Triangle,

            /// <summary>
            /// Ellipse shape
            /// </summary>
            Ellipse,

            /// <summary>
            /// Plus shape
            /// </summary>
            Plus,

            /// <summary>
            /// Rounded Rectangle
            /// </summary>
            RoundedRectangle,

            /// <summary>
            /// Rounded Square
            /// </summary>
            RoundedSquare,

            /// <summary>
            /// Right Triangle
            /// </summary>
            RightTriangle,

            /// <summary>
            /// ThreeDBox shape
            /// </summary>
            ThreeDBox,

            /// <summary>
            /// FlowChart Process shape
            /// </summary>
            FlowChart_Process,

            /// <summary>
            /// FlowChart Start shape
            /// </summary>
            FlowChart_Start,

            /// <summary>
            /// FlowChart Decision shape
            /// </summary>
            FlowChart_Decision,

            /// <summary>
            /// FlowChart_Predefined shape
            /// </summary>
            FlowChart_Predefined,

            /// <summary>
            /// FlowChart_StoredData shape
            /// </summary>
            FlowChart_StoredData,

            /// <summary>
            /// FlowChart_Document shape
            /// </summary>
            FlowChart_Document,

            /// <summary>
            /// FlowChart_Data shape
            /// </summary>
            FlowChart_Data,

            /// <summary>
            /// FlowChart_InternalStorage shape
            /// </summary>
            FlowChart_InternalStorage,

            /// <summary>
            /// FlowChart_PaperTape shape
            /// </summary>
            FlowChart_PaperTape,

            /// <summary>
            /// FlowChart_SequentialData shape
            /// </summary>
            FlowChart_SequentialData,

            /// <summary>
            /// FlowChart_DirectData shape
            /// </summary>
            FlowChart_DirectData,

            /// <summary>
            /// FlowChart_ManualInput shape
            /// </summary>
            FlowChart_ManualInput,

            /// <summary>
            /// FlowChart_Card shape
            /// </summary>
            FlowChart_Card,

            /// <summary>
            /// FlowChart_Delay shape
            /// </summary>
            FlowChart_Delay,

            /// <summary>
            /// FlowChart_Terminator shape
            /// </summary>
            FlowChart_Terminator,

            /// <summary>
            /// FlowChart_Display shape
            /// </summary>
            FlowChart_Display,

            /// <summary>
            /// FlowChart_LoopLimit shape
            /// </summary>
            FlowChart_LoopLimit,

            /// <summary>
            /// FlowChart_Preparation shape
            /// </summary>
            FlowChart_Preparation,

            /// <summary>
            /// FlowChart_ManualOperation shape
            /// </summary>
            FlowChart_ManualOperation,

            /// <summary>
            /// FlowChart_OffPageReference shape
            /// </summary>
            FlowChart_OffPageReference,

            /// <summary>
            /// FlowChart_Star shape
            /// </summary>
            FlowChart_Star,

            Basic,
            Composition,
            UniDirectional,
            Inherit,
            Pc,
            Gate1,
            Gate2,
            Cloud
        }

// *********** CUSTOM NODE CLASS ***************
        
    }
}
