using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.Practices.Prism.StoreApps;

namespace OrgChartUsingViewModel.Models
{
    public class Employee:INotifyPropertyChanged
    {
        
        private string name;
        private double salary;
        private string destination;
        private string imageurl;
        private string doj;
        private string emailid;
        private double contactno;
        private State isexpand;
        private bool issearch = false;
        private bool isfilter = true;
        private double _borderthick = 1;
        private string heatmap = "#FFC34444";
        private string reportingPerson;

        public Employee()
        {
            Models = new ObservableCollection<Employee>();

        }
        public State IsExpand
        {
            get
            {
                return isexpand;
            }
            set
            {
                if (isexpand != value)
                {
                    isexpand = value;
                    OnPropertyChanged(("IsExpand"));
                }
            }
        }

        public bool IsSearched
        {
            get
            {
                return issearch;
            }
            set
            {
                if (issearch != value)
                {
                    issearch = value;
                    OnPropertyChanged(("IsSearched"));
                }
            }
        }

        private ObservableCollection<string> _disp = new ObservableCollection<string>()
        {
            "Managing Director",
            "Project Manager",
            "Project Lead",
            "Senior S/w Engg",
            "S/w Engg",
            "Project Trainee"
        };

        public ObservableCollection<string> Designation
        {
            get
            {
                return _disp;
            }
        }

        private ObservableCollection<string> _gen = new ObservableCollection<string>()
        {
            "Female",
            "Male"
        };

        public ObservableCollection<string> Gender
        {
            get
            {
                return _gen;
            }
        }

        private ObservableCollection<int> _rat = new ObservableCollection<int>()
        {
            1,2,3,4,5
        };

        public ObservableCollection<int> Rating
        {
            get
            {
                return _rat;
            }
        }

        private NodeFocusState isfocus;
        public NodeFocusState IsFocus
        {
            get
            {
                return isfocus;
            }
            set
            {
                if (isfocus != value)
                {
                    isfocus = value;
                    if (value == NodeFocusState.Normal)
                    {
                        BackgroundBrush = new SolidColorBrush(Colors.White);
                    }
                    else if (value == NodeFocusState.MouseHover)
                    {
                        Color c = Color.FromArgb(255, 239, 239, 239);
                        BackgroundBrush = new SolidColorBrush(c);
                    }
                    else if (value == NodeFocusState.Focused)
                    {
                        BackgroundBrush = ColorConverter(RatingColor);
                    }
                    OnPropertyChanged(("IsFocus"));
                }
            }
        }

        private SolidColorBrush ColorConverter(string hexaColor)
        {
            if (hexaColor != null)
            {
                byte r = Convert.ToByte(hexaColor.Substring(1, 2), 16);
                byte g = Convert.ToByte(hexaColor.Substring(3, 2), 16);
                byte b = Convert.ToByte(hexaColor.Substring(5, 2), 16);
                byte a = Convert.ToByte(hexaColor.Substring(7, 2), 16);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(r, g, b, a));
                return myBrush;
            }
            return null;
        }
        public bool IsFiltered
        {
            get
            {
                return isfilter;
            }
            set
            {
                if (isfilter != value)
                {
                    isfilter = value;
                    OnPropertyChanged(("IsFiltered"));
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(("Name"));
                }
            }
        }

        public string ReportingPerson
        {
            get
            {
                return reportingPerson;
            }
            set
            {
                if (reportingPerson != value)
                {
                    reportingPerson = value;
                    OnPropertyChanged(("ReportingPerson"));
                }
            }
        }

        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (salary != value)
                {
                    salary = value;
                    OnPropertyChanged(("Salary"));
                }
            }
        }

        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                if (destination != value)
                {
                    if (value != null)
                    {
                        destination = value;
                        OnPropertyChanged(("Destination"));
                    }
                }
            }
        }

        public string ImageUrl
        {
            get
            {
                return imageurl;
            }
            set
            {
                if (imageurl != value)
                {
                    if (value != null)
                    {
                        imageurl = value;
                        OnPropertyChanged(("ImageUrl"));
                    }
                }
            }
        }


        private bool isedit = false;

        public bool IsEdit
        {
            get
            {
                return isedit;
            }
            set
            {
                if (isedit != value)
                {
                    isedit = value;
                    OnPropertyChanged(("IsEdit"));
                }
            }
        }

        public string Doj
        {
            get
            {
                return doj;
            }
            set
            {
                if (doj != value)
                {
                    doj = value;
                    OnPropertyChanged(("Doj"));
                }
            }
        }

        public string EmailId
        {
            get
            {
                return emailid;
            }
            set
            {
                if (emailid != value)
                {
                    emailid = value;
                    OnPropertyChanged(("EmailId"));
                }
            }
        }

        public double ContactNo
        {
            get
            {
                return contactno;
            }
            set
            {
                if (contactno != value)
                {
                    contactno = value;
                    OnPropertyChanged(("ContactNo"));
                }
            }
        }

        public double BorderThickness
        {
            get
            {
                return _borderthick;
            }
            set
            {
                if (_borderthick != value)
                {
                    _borderthick = value;
                    OnPropertyChanged(("BorderThickness"));
                }
            }

        }

        public string RatingColor
        {
            get
            {
                return heatmap;
            }
            set
            {
                if (heatmap != value)
                {
                    if (value != null)
                    {
                        heatmap = value;
                        //if (RatingUpdated != null)
                        //{
                        //    RatingUpdated.Execute(RatingColor);
                        //}
                        OnPropertyChanged(("RatingColor"));
                    }
                }
            }
        }

        //private ICommand _rating;

        //public ICommand RatingUpdated
        //{
        //    get
        //    {
        //        return _rating;
        //    }
        //    set
        //    {
        //        if (_rating != null)
        //        {
        //            _rating = value;
        //            OnPropertyChanged(("RatingUpdated"));
        //        }
        //    }
        //}

        private ObservableCollection<Employee> models;


        public ObservableCollection<Employee> Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged(("Models"));
            }
        }


        public ICommand BrowseCommand
        {
            get
            {
                return new DelegateCommand<object>(OnClick, args => { return true; });
            }
        }

        private BitmapImage _bit;

        public BitmapImage BitImag
        {
            get
            {
                return _bit;
            }
            set
            {
                if (_bit != value)
                {
                    _bit = value;
                    OnPropertyChanged(("BitImag"));
                }
            }
        }
        private ICommand _path;
        public ICommand PathClickCommand
        {
            get
            {
                return _path;
            }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    OnPropertyChanged(("PathClickCommand"));
                }
            }
        }

        private ICommand _Rating;
        public ICommand RatingCommand
        {
            get
            {
                return _Rating;
            }
            set
            {
                if (_Rating != value)
                {
                    _Rating = value;
                    OnPropertyChanged(("RatingCommand"));
                }
            }
        }

        private ICommand _selection;

        public ICommand Selection
        {
            get
            {
                return _selection;
            }
            set
            {
                if (_selection != value)
                {
                    _selection = value;
                    OnPropertyChanged(("Selection"));
                }
            }
        }

        private void OnPress(object obj)
        {

        }

        private SolidColorBrush _backbrush;
        public SolidColorBrush BackgroundBrush
        {
            get
            {
                return _backbrush;
            }
            set
            {
                if (_backbrush != value)
                {
                    _backbrush = value;
                    OnPropertyChanged(("BackgroundBrush"));
                }
            }
        }


        private async void OnClick(object obj)
        {
            Image im = new Image();
            FileOpenPicker open = new FileOpenPicker();
            open.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            open.ViewMode = PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types
            open.FileTypeFilter.Clear();
            open.FileTypeFilter.Add(".bmp");
            open.FileTypeFilter.Add(".png");
            open.FileTypeFilter.Add(".jpeg");
            open.FileTypeFilter.Add(".jpg");

            // Open a stream for the selected file
            StorageFile file = await open.PickSingleFileAsync();

            // Ensure a file was selected
            if (file != null)
            {
                // Ensure the stream is disposed once the image is loaded
                using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    await BitImag.SetSourceAsync(fileStream);
                }
                ImageUrl = file.Path;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public enum AnimationState
    {
        Normal,
        Animation
    };

    public enum State
    {
        Expand,
        Collapse,
        None
    };

    public enum NodeFocusState
    {
        Normal,
        MouseHover,
        Focused
    };
}
