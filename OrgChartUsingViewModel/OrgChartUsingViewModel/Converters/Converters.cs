﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace OrgChartUsingViewModel.Converters
{
    public class StringtoVisiblityConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int? val = value as int?;
            if (val == 0 | val == 2)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class NumerictoVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int? val = value as int?;
            if (val == 1)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToVisibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? val = value as bool?;
            if (val == true)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? val = value as bool?;
            if (val == true)
                return new Thickness(3.2);
            return new Thickness(1.2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? val = value as bool?;
            if (val == true)
            {
                return new SolidColorBrush(Colors.SkyBlue);
            }
            else
            {
                //return new SolidColorBrush(Colors.White);
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Color.FromArgb(255, 179, 179, 179);
                return brush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumtoExpandConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            object val = Enum.ToObject(typeof(State), value);
            if (value.ToString() == State.Expand.ToString())
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumtoCollapseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            object val = Enum.ToObject(typeof(State), value);
            if (value.ToString() == State.Collapse.ToString())
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumtoPathVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            object val = Enum.ToObject(typeof(State), value);
            if (value.ToString() == State.None.ToString())
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    //<TextBlock Text="{Binding SomeDateTime, Converter={StaticResource StringFormatConverter}, ConverterParameter='{}{0:dd MMM yyyy}'}" />
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // No format provided.
            if (parameter == null)
            {
                return value;
            }

            return String.Format((String)parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class EnumtoFocusConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            object val = Enum.ToObject(typeof(NodeFocusState), value);
            SolidColorBrush solid = new SolidColorBrush();
            if (val.ToString() == NodeFocusState.Normal.ToString())
            {
                return new SolidColorBrush(Colors.White);
            }
            else if (value.ToString() == NodeFocusState.MouseHover.ToString())
            {
                solid.Color = Color.FromArgb(255, 239, 239, 239);
                return solid;
            }
            //else 
            //{
            //    if(value.ToString() == NodeFocusState.Focused.ToString())
            //    {
            //        solid.Color = Color.FromArgb(255, 201, 201, 201);
            //        return solid;
            //    }
            //}
            return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedItemConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class FormatConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Retrieve the format string and use it to format the value.
            string formatString = parameter as string;
            if (!string.IsNullOrEmpty(formatString))
            {
                return string.Format(
                    new CultureInfo(language), formatString, value);
            }
            // If the format string is null or empty, simply call ToString()
            // on the value.
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string formatString = parameter as string;
            if (!string.IsNullOrEmpty(formatString))
            {
                return string.Format(
                    new CultureInfo(language), formatString, value);
            }
            // If the format string is null or empty, simply call ToString()
            // on the value.
            return value.ToString();
        }
    }

    public class ItemtoImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string val = value as string;
            if (value.ToString() == "Female")
            {
                return "ms-appx:///Diagram/OrganizationalChartDemo/Resource/female.png";
            }
            else
            {
                return "ms-appx:///Diagram/OrganizationalChartDemo/Resource/male.png";
            }

        }
    }

    public class RatingToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                string i = (string)value;
                int coun = 0;
                switch (i)
                {
                    case "#FFC34444":
                        coun = 1;
                        break;
                    case "#FF68C2DE":
                        coun = 2;
                        break;
                    case "#FF93B85A":
                        coun = 3;
                        break;
                    case "#FFEBB92E":
                        coun = 4;
                        break;
                    case "#FFD46E89":
                        coun = 5;
                        break;
                }
                return coun;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                int i = (int)value;
                string color = string.Empty;
                switch (i)
                {
                    case 1:
                        color = "#FFC34444";
                        break;
                    case 2:
                        color = "#FF68C2DE";
                        break;
                    case 3:
                        color = "#FF93B85A";
                        break;
                    case 4:
                        color = "#FFEBB92E";
                        break;
                    case 5:
                        color = "#FFD46E89";
                        break;
                }
                return color;
            }
            return null;
        }
    }
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
