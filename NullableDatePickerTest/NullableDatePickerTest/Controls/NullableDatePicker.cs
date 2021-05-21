using System;
using Xamarin.Forms;

namespace NullableDatePickerTest.Controls
{
    public class NullableDatePicker : DatePicker
    {
        public static readonly BindableProperty NullableDateProperty = BindableProperty.Create("NullableDate", typeof(DateTime?), typeof(NullableDatePicker), null, BindingMode.TwoWay);
        public static readonly BindableProperty IsDateNullableProperty = BindableProperty.Create("IsDateNullable", typeof(bool), typeof(NullableDatePicker), false);
        public static readonly BindableProperty NullableDatePlaceholderProperty = BindableProperty.Create("NullableDatePlaceholder", typeof(string), typeof(NullableDatePicker), "No Date Selected");
        public static readonly BindableProperty CancelContentProperty = BindableProperty.Create("CancelContent", typeof(string), typeof(NullableDatePicker), "Clear");

        public DateTime? NullableDate
        {
            get { return (DateTime?)GetValue(NullableDateProperty); }
            set { SetValue(NullableDateProperty, value); }
        }

        public bool IsDateNullable
        {
            get { return (bool)GetValue(IsDateNullableProperty); }
            set { SetValue(IsDateNullableProperty, value); }
        }

        public string NullableDatePlaceholder
        {
            get { return (string)GetValue(NullableDatePlaceholderProperty); }
            set { SetValue(NullableDatePlaceholderProperty, value); }
        }
        public string CancelContent
        {
            get { return (string)GetValue(CancelContentProperty); }
            set { SetValue(CancelContentProperty, value); }
        }
    }
}
