using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ZGAF_DELR_EXAMEN_2P.Converters
{
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime bornDate = DateTime.Parse(value.ToString());
            int age = DateTime.Now.Year - bornDate.Year;
            if(age == 0)
            {
                age = DateTime.Now.Month - bornDate.Month;
                return "Edad: " + age + " meses";
            }
            return "Edad: " + age + " años";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
