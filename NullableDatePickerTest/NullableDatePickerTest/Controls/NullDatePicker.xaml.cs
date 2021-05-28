using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NullableDatePickerTest.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NullDatePicker : ContentView
    {
        #region PROPERTIES
        public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(nameof(SelectedDate), typeof(DateTime?), typeof(NullDatePicker), null, BindingMode.TwoWay);
        public static readonly BindableProperty NoDatePlaceholderProperty = BindableProperty.Create(nameof(NoDatePlaceholder), typeof(string), typeof(NullableDatePicker), "No Date Selected");
        public static readonly BindableProperty DateFormatProperty = BindableProperty.Create(nameof(DateFormat), typeof(string), typeof(NullableDatePicker), "MM/dd/yyyy");
        public static readonly BindableProperty ClearDateTextProperty = BindableProperty.Create(nameof(ClearDateText), typeof(string), typeof(NullableDatePicker), "Clear");

        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public string NoDatePlaceholder
        {
            get { return (string)GetValue(NoDatePlaceholderProperty); }
            set { SetValue(NoDatePlaceholderProperty, value); }
        }

        public string DateFormat
        {
            get { return (string)GetValue(DateFormatProperty); }
            set { SetValue(DateFormatProperty, value); }
        }

        public string ClearDateText
        {
            get { return (string)GetValue(ClearDateTextProperty); }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == SelectedDateProperty.PropertyName)
            {
                if (SelectedDate == null)
                {
                    cDateEntry.Text = null;
                    cDateEntry.Placeholder = NoDatePlaceholder;
                }
                else
                {
                    cDatePicker.Date = SelectedDate.GetValueOrDefault();
                    cDateEntry.Text = SelectedDate.GetValueOrDefault().ToString(DateFormat);
                }
            }
            else if (propertyName == NoDatePlaceholderProperty.PropertyName)
            {
                cDateEntry.Placeholder = NoDatePlaceholder;
            }
            else if (propertyName == ClearDateTextProperty.PropertyName)
            {
                cClearDateButton.Text = ClearDateText;
            }
        }

        #endregion PROPERTIES

        public NullDatePicker()
        {
            InitializeComponent();

            cDatePicker.IsVisible = false;
            cDateEntry.Placeholder = NoDatePlaceholder;
            cClearDateButton.Text = ClearDateText;
        }

        private void cDateEntry_Focused(object sender, FocusEventArgs e)
        {
            cDateEntry.Unfocus();
            cDateEntry.IsVisible = false;
            cDatePicker.IsVisible = true;
            cDatePicker.Focus();
        }

        private void cDatePicker_Focused(object sender, FocusEventArgs e)
        {
            if (SelectedDate == null)
            {
                SelectedDate = cDatePicker.Date;
            }
        }

        private void cDatePicker_Unfocused(object sender, FocusEventArgs e)
        {
            cDateEntry.IsVisible = true;
            cDatePicker.IsVisible = false;
        }

        private void cDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            SelectedDate = e.NewDate;
        }

        private void cClearDateButton_Clicked(object sender, EventArgs e)
        {
            SelectedDate = null;
        }
    }
}