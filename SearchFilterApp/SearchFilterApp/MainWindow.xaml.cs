using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchFilterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Location _searchLocation = new Location();
        List<Location> locations = new List<Location>(); 
        //List<string> cityList = new List<string>(); 
        public MainWindow()
        {
            InitializeComponent();
            TopGrid.DataContext = GetMainWindowContext();
        }

        private MainWindowDataContext GetMainWindowContext()
        {
            List<Location> locations = new List<Location>()
            {
                new Location(){Name = "Dhaka"},
                new Location(){Name = "Chittagong"},
                new Location(){Name = "Comilla"},
                new Location(){Name = "Rajshahi"},
                new Location(){Name = "Dhamrai"},
                new Location(){Name = "AbuDhabi"}
            };
            MainWindowDataContext context = new MainWindowDataContext(locations)
            {
                FilterString = string.Empty,
            };
            
            
            context.Locations = locations;
            return context;

        }
    }
}
