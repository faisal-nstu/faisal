using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFilterApp
{
    public class MainWindowDataContext : BindingBase
    {
        private List<Location> allLocations; 
        //public List<Location> filteredLocation = new List<Location>();
        private string _filterString;

        public string FilterString
        {
            get { return _filterString; }
            set
            {
                if (_filterString != value)
                {
                    _filterString = value;
                    
                    List<Location> filteredLocation = new List<Location>();
                    filteredLocation = allLocations.FindAll(location => location.Name.Contains(FilterString));
                    Locations = filteredLocation;
                    RaisePropertyChanged("FilterString");
                }
            }
        }

        private List<Location> _locations;

        public List<Location> Locations 
        {
            get
            {
                if (_locations == null)
                {
                    return new List<Location>();
                }
                return _locations;
            }
            set
            {
                if (_locations == null || !_locations.SequenceEqual(value))
                {
                    _locations = value;
                    RaisePropertyChanged("Locations");
                }
            }
        }

        public MainWindowDataContext(List<Location> locations)
        {
            allLocations = locations;
            Locations = allLocations;
        }


    }
}
