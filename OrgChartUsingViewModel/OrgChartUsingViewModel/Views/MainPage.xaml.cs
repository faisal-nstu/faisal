using System;
using System.ServiceModel.Channels;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.StoreApps;
using OrgChartUsingViewModel.ViewModels;

namespace OrgChartUsingViewModel.Views
{
    public sealed partial class MainPage : VisualStateAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
            ChartViewModel orgChartViewModel = new ChartViewModel();
            this.DataContext = orgChartViewModel;
            OrgFrame.Loaded += OrgFrameOnLoaded;
        }

        private void OrgFrameOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //MessageDialog msg = new MessageDialog("ORgFrame Loaded...");
            //msg.ShowAsync();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                OrgDiagram org = new OrgDiagram();
                org.ChartViewModel = this.DataContext as ChartViewModel;
                OrgFrame.Content = org;
            }
               );
        }
    }
}
