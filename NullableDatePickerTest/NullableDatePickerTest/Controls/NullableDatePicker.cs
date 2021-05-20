using System;
using Xamarin.Forms;

namespace NullableDatePickerTest.Controls
{
    public class NullableDatePicker : DatePicker
    {
        public static readonly BindableProperty NullableDateProperty = BindableProperty.Create("NullableDate", typeof(DateTime?), typeof(NullableDatePicker), null, BindingMode.TwoWay);
        public static readonly BindableProperty NullPlaceholderProperty = BindableProperty.Create("NullPlaceholder", typeof(string), typeof(NullableDatePicker), null);

        public DateTime? NullableDate
        {
            get { return (DateTime?)GetValue(NullableDateProperty); }
            set { SetValue(NullableDateProperty, value); }
        }

        public string NullPlaceholder
        {
            get { return (string)GetValue(NullPlaceholderProperty); }
            set { SetValue(NullPlaceholderProperty, value); }
        }
    }
}
